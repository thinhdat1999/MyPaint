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
        public PopupTextBox(Size size, Point location)
        {
            Size = size;
            Location = location;
            BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
