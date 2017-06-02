﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Omu.ValueInjecter;

namespace WinFormsFlattenSample
{

    public class SameNameFlat : ValueInjection
    {
        protected override void Inject(object source, object target)
        {
            foreach (PropertyDescriptor targetProp in target.GetProps())
            {
                var endpoints = UberFlatter.Flat(targetProp.Name, source);
                if (endpoints.Count() == 0) continue;

                var desc = endpoints.First();

                var result = Convert.ChangeType(desc.Property.GetValue(desc.Component), targetProp.PropertyType);
                targetProp.SetValue(target, result);
            }
        }
    }

    public class SameNameUnflat : ValueInjection
    {
        protected override void Inject(object source, object target)
        {
            foreach (PropertyDescriptor sourceProp in source.GetProps())
            {
                var endpoints = UberFlatter.Unflat(sourceProp.Name, target);
                if (endpoints.Count() == 0) continue;

                var desc = endpoints.First();

                var prop = sourceProp.GetValue(source);
                var result = prop == null ? prop : Convert.ChangeType(prop, desc.Property.PropertyType);
                desc.Property.SetValue(desc.Component, result);
            }
        }
    }

    public class TextBoxToString : KnownSourceValueInjection<Control>
    {
        protected override void Inject(Control request, object target)
        {
            foreach (var control in request.GetChildControls())
            {
                if (control.Text == string.Empty) continue;

                var endpoints = UberFlatter.Unflat(control.Name.RemovePrefix("txt"), target);
                if(endpoints.Count() == 0) continue;

                var desc = endpoints.First();


                var c = TypeDescriptor.GetConverter(desc.Property.PropertyType);
                try
                {
                    desc.Property.SetValue(desc.Component, c.ConvertFrom(control.Text));
                }
                catch
                {
                    //add form validaton and remove this 
                }
            }
        }
    }

    public class StringToTextBox : KnownTargetValueInjection<Control>
    {
        protected override void Inject(object source, ref Control target)
        {
            foreach (var txt in target.GetChildControls())
            {
                var es = UberFlatter.Flat(txt.Name.RemovePrefix("txt"), source);
                if (es.Count() == 0) continue;
                var desc = es.First();
                txt.Text = (desc.Property.GetValue(desc.Component) ?? "").ToString();
            }
        }
    }

    public class DateTimePickerToDateTime : KnownSourceValueInjection<Control>
    {
        protected override void Inject(Control request, object target)
        {
            foreach (DateTimePicker dt in request.GetChildControls<DateTimePicker>())
            {
                var es = UberFlatter.Unflat(dt.Name.RemovePrefix("dt"), target);
                if(es.Count() == 0) continue;
                var desc = es.First();
                desc.Property.SetValue(desc.Component, dt.Value);
            }
        }
    }

    public class DateTimeToDateTimePicker : KnownTargetValueInjection<Control>
    {
        protected override void Inject(object source, ref Control target)
        {
            foreach (DateTimePicker dt in target.GetChildControls<DateTimePicker>())
            {
                var es = UberFlatter.Flat(dt.Name, source);
                if(es.Count() == 0) continue;
                var desc = es.First();
                dt.Value = (DateTime)desc.Property.GetValue(desc.Component);
            }
        }
    }
}