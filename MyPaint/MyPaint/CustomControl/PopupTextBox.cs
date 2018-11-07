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
                this.Hide();
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            this.Hide();
        }
    }
}
