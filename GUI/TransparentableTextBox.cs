using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public class TransparentTextBox : TextBox
    {
        public TransparentTextBox()
        {
            // Bật cờ hỗ trợ nền trong suốt
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            this.BorderStyle = BorderStyle.None;
        }

        // Ép Windows hiểu đây là Control xuyên thấu
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20; // WS_EX_TRANSPARENT
                return cp;
            }
        }

        // FIX LỖI NHẤP NHÁY: Chỉ yêu cầu Parent vẽ lại nền khi nội dung chữ thay đổi
        // Không dùng vòng lặp WM_PAINT nữa
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (this.Parent != null)
            {
                this.Parent.Invalidate(this.Bounds, false);
            }
        }
    }
}