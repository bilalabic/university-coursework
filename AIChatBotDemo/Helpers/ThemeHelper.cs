using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AIChatBotDemo.Helpers
{
    public static class ThemeHelper
    {
        public static class Light
        {
            public static Color Background = Color.FromArgb(249, 250, 251);
            public static Color Surface = Color.White;
            public static Color Sidebar = Color.FromArgb(243, 244, 246);
            public static Color SidebarHover = Color.FromArgb(229, 231, 235);
            public static Color Primary = Color.FromArgb(59, 130, 246);
            public static Color PrimaryHover = Color.FromArgb(37, 99, 235);
            public static Color Secondary = Color.FromArgb(107, 114, 128);
            public static Color Text = Color.FromArgb(17, 24, 39);
            public static Color TextSecondary = Color.FromArgb(107, 114, 128);
            public static Color Border = Color.FromArgb(229, 231, 235);
            public static Color UserBubble = Color.FromArgb(59, 130, 246);
            public static Color AiBubble = Color.White;
            public static Color Success = Color.FromArgb(34, 197, 94);
            public static Color Error = Color.FromArgb(239, 68, 68);
            public static Color InputBg = Color.White;
        }

        public static class Dark
        {
            public static Color Background = Color.FromArgb(17, 24, 39);
            public static Color Surface = Color.FromArgb(31, 41, 55);
            public static Color Sidebar = Color.FromArgb(31, 41, 55);
            public static Color SidebarHover = Color.FromArgb(55, 65, 81);
            public static Color Primary = Color.FromArgb(59, 130, 246);
            public static Color PrimaryHover = Color.FromArgb(96, 165, 250);
            public static Color Secondary = Color.FromArgb(156, 163, 175);
            public static Color Text = Color.FromArgb(249, 250, 251);
            public static Color TextSecondary = Color.FromArgb(156, 163, 175);
            public static Color Border = Color.FromArgb(55, 65, 81);
            public static Color UserBubble = Color.FromArgb(59, 130, 246);
            public static Color AiBubble = Color.FromArgb(55, 65, 81);
            public static Color Success = Color.FromArgb(34, 197, 94);
            public static Color Error = Color.FromArgb(239, 68, 68);
            public static Color InputBg = Color.FromArgb(55, 65, 81);
        }

        public static void ApplyTheme(Control control, bool isDark)
        {
            control.BackColor = isDark ? Dark.Background : Light.Background;
            control.ForeColor = isDark ? Dark.Text : Light.Text;
            ApplyToChildren(control.Controls, isDark);
        }

        private static void ApplyToChildren(Control.ControlCollection controls, bool isDark)
        {
            foreach (Control c in controls)
            {
                c.ForeColor = isDark ? Dark.Text : Light.Text;

                if (c is TabControl tc)
                {
                    tc.BackColor = isDark ? Dark.Surface : Light.Surface;
                }
                else if (c is TabPage tp)
                {
                    tp.BackColor = isDark ? Dark.Surface : Light.Surface;
                }
                else if (c is RichTextBox r)
                {
                    r.BackColor = isDark ? Dark.InputBg : Light.InputBg;
                    r.ForeColor = isDark ? Dark.Text : Light.Text;
                }
                else if (c is TextBox t)
                {
                    t.BackColor = isDark ? Dark.InputBg : Light.InputBg;
                    t.ForeColor = isDark ? Dark.Text : Light.Text;
                    t.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (c is ListBox l)
                {
                    l.BackColor = isDark ? Dark.Sidebar : Light.Sidebar;
                    l.ForeColor = isDark ? Dark.Text : Light.Text;
                    l.BorderStyle = BorderStyle.None;
                }
                else if (c is ComboBox cb)
                {
                    cb.BackColor = isDark ? Dark.InputBg : Light.InputBg;
                    cb.ForeColor = isDark ? Dark.Text : Light.Text;
                    cb.FlatStyle = FlatStyle.Flat;
                }
                else if (c is Button btn)
                {
                    StyleButton(btn, isDark);
                }
                else if (c is GroupBox gb)
                {
                    gb.ForeColor = isDark ? Dark.Text : Light.Text;
                }
                else if (c is Panel p)
                {
                    p.BackColor = isDark ? Dark.Surface : Light.Surface;
                }
                else if (c is Label lbl)
                {
                    lbl.ForeColor = isDark ? Dark.Text : Light.Text;
                }

                if (c.HasChildren) ApplyToChildren(c.Controls, isDark);
            }
        }

        public static void StyleButton(Button btn, bool isDark, bool isPrimary = false)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            if (isPrimary || btn.BackColor == Light.Primary || btn.BackColor == Color.FromArgb(33, 150, 243))
            {
                btn.BackColor = isDark ? Dark.Primary : Light.Primary;
                btn.ForeColor = Color.White;
                btn.FlatAppearance.MouseOverBackColor = isDark ? Dark.PrimaryHover : Light.PrimaryHover;
            }
            else if (btn.BackColor == Color.FromArgb(244, 67, 54) || btn.BackColor == Light.Error)
            {
                btn.BackColor = isDark ? Dark.Error : Light.Error;
                btn.ForeColor = Color.White;
            }
            else
            {
                btn.BackColor = isDark ? Dark.Surface : Light.Surface;
                btn.ForeColor = isDark ? Dark.Text : Light.Text;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = isDark ? Dark.Border : Light.Border;
            }
        }

        public static string GetChatCss(bool isDark)
        {
            var bg = isDark ? "#111827" : "#f9fafb";
            var userBg = isDark ? "#3b82f6" : "#3b82f6";
            var aiBg = isDark ? "#374151" : "#ffffff";
            var text = isDark ? "#f9fafb" : "#111827";
            var textSecondary = isDark ? "#9ca3af" : "#6b7280";
            var codeBg = isDark ? "#1f2937" : "#f3f4f6";
            var border = isDark ? "#374151" : "#e5e7eb";

            return $@"
* {{ margin: 0; padding: 0; box-sizing: border-box; }}
body {{ 
    font-family: 'Segoe UI', -apple-system, BlinkMacSystemFont, sans-serif; 
    font-size: 14px; 
    background: {bg}; 
    color: {text}; 
    padding: 20px;
    line-height: 1.6;
}}
.message {{ 
    margin-bottom: 16px; 
    padding: 14px 18px; 
    border-radius: 16px; 
    max-width: 75%;
    word-wrap: break-word;
    box-shadow: 0 1px 3px rgba(0,0,0,0.1);
    animation: fadeIn 0.3s ease;
}}
@keyframes fadeIn {{
    from {{ opacity: 0; transform: translateY(10px); }}
    to {{ opacity: 1; transform: translateY(0); }}
}}
.user {{ 
    background: linear-gradient(135deg, {userBg} 0%, #2563eb 100%);
    color: white;
    margin-left: auto;
    border-bottom-right-radius: 4px;
}}
.assistant {{ 
    background: {aiBg}; 
    border: 1px solid {border};
    border-bottom-left-radius: 4px;
}}
pre {{ 
    background: {codeBg}; 
    padding: 14px; 
    border-radius: 10px; 
    overflow-x: auto;
    margin: 10px 0;
    border: 1px solid {border};
}}
code {{ 
    font-family: 'Cascadia Code', 'Fira Code', Consolas, monospace; 
    font-size: 13px;
}}
:not(pre) > code {{
    background: {codeBg};
    padding: 2px 6px;
    border-radius: 4px;
}}
.timestamp {{ 
    font-size: 11px; 
    color: {textSecondary}; 
    margin-top: 8px;
    opacity: 0.8;
}}
.user .timestamp {{ color: rgba(255,255,255,0.7); }}
img {{ 
    max-width: 280px; 
    border-radius: 12px; 
    margin: 10px 0;
    box-shadow: 0 2px 8px rgba(0,0,0,0.15);
}}
a {{ color: #3b82f6; text-decoration: none; }}
a:hover {{ text-decoration: underline; }}
ul, ol {{ padding-left: 20px; margin: 8px 0; }}
blockquote {{
    border-left: 3px solid #3b82f6;
    padding-left: 12px;
    margin: 10px 0;
    color: {textSecondary};
}}
table {{
    border-collapse: collapse;
    margin: 10px 0;
    width: 100%;
}}
th, td {{
    border: 1px solid {border};
    padding: 8px 12px;
    text-align: left;
}}
th {{ background: {codeBg}; }}
.typing::after {{
    content: '▋';
    animation: blink 1s infinite;
}}
@keyframes blink {{
    0%, 50% {{ opacity: 1; }}
    51%, 100% {{ opacity: 0; }}
}}
::-webkit-scrollbar {{ width: 8px; }}
::-webkit-scrollbar-track {{ background: transparent; }}
::-webkit-scrollbar-thumb {{ background: {border}; border-radius: 4px; }}
::-webkit-scrollbar-thumb:hover {{ background: {textSecondary}; }}";
        }
    }
}
