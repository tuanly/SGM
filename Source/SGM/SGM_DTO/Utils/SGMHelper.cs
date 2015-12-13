using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SGM_Core.Utils
{
    public class SGMHelper
    {
        private static Dictionary<Control, ToolTip> map = new Dictionary<Control,ToolTip>();

        public static void ShowToolTip(Control target, String text)
        {
            if (!map.ContainsKey(target))
            {
                ToolTip t = new ToolTip();
               // t.ToolTipIcon = ToolTipIcon.Info;
                map.Add(target, t);
                target.GotFocus += new EventHandler(target_Focus);
                target.LostFocus += new EventHandler(target_LostFocus);
            }
            if (string.IsNullOrEmpty(text))
                map[target].Hide(target);
            else
                map[target].Show(text, target);
            
        }

        public static void HideTooltip(Control target)
        {
            if (map.ContainsKey(target))
                map[target].Hide(target);
        }

        public static void Clear()
        {
            map.Clear();
        }

        private static void target_Focus(object sender, EventArgs e)
        {
            Control c = (Control) sender;
            HideTooltip(c);
        }

        private static void target_LostFocus(object sender, EventArgs e)
        {
            Control c = (Control) sender;
            if (c is TextBox)
            {
                if (string.IsNullOrEmpty(c.Text))
                    map[c].Show("???", c);
            }
            
        }
    }
}
