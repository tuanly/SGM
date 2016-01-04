using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SGM_Core.Utils
{
    public class SGMHelper
    {
        private static Dictionary<Control, ToolTip> map = new Dictionary<Control,ToolTip>();

        private static string tooltipFontFace = "Arial";
        private static int tooltipFontSize = 12;
        private static Font tooltipFont = new Font(tooltipFontFace, tooltipFontSize);
        private static Color tooltipBgColor = Color.Red;
        private static SolidBrush tooltipFgColor = new SolidBrush(Color.White);

        public static void ShowToolTip(Control target, String text)
        {
            if (!map.ContainsKey(target))
            {
                ToolTip t = new ToolTip();
                //t.ToolTipIcon = ToolTipIcon.Info;
                t.OwnerDraw = true;
                t.Draw += new DrawToolTipEventHandler(toolTip_Draw);
                t.Popup += new PopupEventHandler(toolTip_Popup);
                map.Add(target, t);
                target.GotFocus += new EventHandler(target_Focus);
                target.LostFocus += new EventHandler(target_LostFocus);
            }
            if (string.IsNullOrEmpty(text))
                map[target].Hide(target);
            else
                map[target].Show(text, target);
            
        }

        private static void toolTip_Popup(object sender, PopupEventArgs e)
        {
            Size sz = TextRenderer.MeasureText(((ToolTip)sender).GetToolTip(e.AssociatedControl), new Font(tooltipFontFace, tooltipFontSize));
            sz.Height += 4;
            sz.Width += 4;
            e.ToolTipSize = sz;
        }

        private static void toolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            ToolTip t = (ToolTip)sender;
            t.BackColor = tooltipBgColor;
            e.DrawBackground();
            e.DrawBorder();
            e.Graphics.DrawString(e.ToolTipText, tooltipFont, tooltipFgColor, new PointF(1, 1));
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
                    map[c].Show("Giá trị?", c);
            }
            
        }
    }
}
