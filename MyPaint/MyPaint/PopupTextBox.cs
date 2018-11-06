using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    //Tạo PopupTextBox : Bản chất là TextBox, nhưng khi nhấn Escape hoặc chuột ra vùng khác sẽ tự biến mất
    //Và để lại nội dung văn bản trên PictureBox
    class PopupTextBox : RichTextBox
    {
        private bool _isFocused = true;
        public bool isFocused { get => _isFocused; }
        public PopupTextBox(Rectangle rect)
        {
            Size = rect.Size;
            Location = rect.Location;
            BorderStyle = BorderStyle.Fixed3D;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                MyPaint._g.DrawString(Text, DefaultFont, MyPaint._brush, Location);
                Dispose();
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            MyPaint._g.DrawString(Text, DefaultFont, MyPaint._brush, Location);
            Dispose();
        }
    }
}
