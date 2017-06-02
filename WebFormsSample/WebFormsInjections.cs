using System.Web.UI;
using System.Web.UI.WebControls;
using Omu.ValueInjecter;

namespace WebFormsSample
{
    public class TextBoxToString : KnownSourceValueInjection<Control>
    {
        protected override void Inject(Control request, object target)
        {
            var targetProps = target.GetProps();
            for (var index = 0; index < targetProps.Count; index++)
            {
                var targetProp = targetProps[index];
                if (targetProp.PropertyType != typeof(string)) continue;

                var control = request.FindControl("txt" + targetProp.Name);
                if (control == null || control.GetType() != typeof(TextBox)) continue;

                targetProp.SetValue(target, ((TextBox)control).Text);
            }
        }
    }

    public class StringToTextBox : KnownTargetValueInjection<Control>
    {
        protected override void Inject(object source, ref Control target)
        {
            var sourceProps = source.GetProps();
            for (var index = 0; index < sourceProps.Count; index++)
            {
                var sourceProp = sourceProps[index];
                if (sourceProp.PropertyType != typeof(string)) continue;

                var control = target.FindControl("txt" + sourceProp.Name);
                if (control == null || control.GetType() != typeof(TextBox)) continue;

                ((TextBox) control).Text = (string) sourceProp.GetValue(source);
            }
        }
    }

    
}