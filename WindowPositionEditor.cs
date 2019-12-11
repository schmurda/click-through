using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ClickThrough
{
    public class WindowPositionEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (!(provider?.GetService(typeof(IWindowsFormsEditorService)) is IWindowsFormsEditorService svc) ||
                !(value is WindowPosition pos)) return value;

            using (var placeholder = new PlaceholderWindow())
            {
                if (svc.ShowDialog(placeholder) == DialogResult.OK)
                {
                    placeholder.Confirm += (sender, args) => 
                        pos = ((PlaceholderWindow) sender).GetWindowPosition();
                }
            }

            return value;
        }
    }
}
