using System.ComponentModel;
using System.Windows.Forms;
using Omu.ValueInjecter;

namespace WinFormsSample
{
    public class TextBoxToString : KnownSourceValueInjection<Form>
    {
        protected override void Inject(Form form, object target)
        {
            var targetProps = target.GetProps();
            foreach (var control in form.Controls)
            {
                if (control.GetType() != typeof(TextBox)) continue;
                var txt = control as TextBox;

                var targetProp = targetProps.GetByName(txt.Name.Replace("txt", ""));
                if (targetProp == null || targetProp.PropertyType != typeof(string)) continue;

                targetProp.SetValue(target, txt.Text);
            }
        }
    }

    public class StringToTextBox : KnownTargetValueInjection<Form>
    {
        protected override void Inject(object source, ref Form form)
        {
            var sourceProps = source.GetProps();
            for (var i = 0; i < sourceProps.Count; i++)
            {
                var sourceProp = sourceProps[i];

                var textBox = form.Controls["txt" + sourceProp.Name] as TextBox;
                if (textBox == null) continue;

                textBox.Text = (string)sourceProp.GetValue(source);
            }
        }

    }
}
