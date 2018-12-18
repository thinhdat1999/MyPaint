using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    //Tạo PopupTextBox : Bản chất là TextBox, nhưng khi nhấn Escape hoặc chuột ra vùng khác sẽ tự biến mất
    //Và để lại nội dung văn bản trên PictureBox
    class PopupTextBox : Form
    {
        private Point _point;
        private Action _onResized;
        private Action _onTextChanged;

        RichTextBox textBox;
        Rectangle typeRect;
        public PopupTextBox(string txt, Rectangle layoutRect, Point location, Action onResized, Action onTextChanged)
        {

            this.FormBorderStyle = FormBorderStyle.None;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            TransparencyKey = Color.Transparent;
            ForeColor = Color.Black;


            typeRect = layoutRect;

            textBox = new RichTextBox();
            textBox.Size = typeRect.Size;
            if (txt != null) textBox.AppendText(txt);              
            textBox.BorderStyle = BorderStyle.None;
            textBox.ScrollBars = RichTextBoxScrollBars.None;
            textBox.ContentsResized += TextDrawing_OnContentResized;

            _point = location;
            _point.Offset(2, 2);
            _onResized = onResized;
            _onTextChanged = onTextChanged;
            this.ShowInTaskbar = false;
            this.KeyPreview = true;
        }

        public string TextToDraw { get => textBox.Text; }

        private void TextDrawing_OnContentResized(object sender, ContentsResizedEventArgs e)
        {
            if (e.NewRectangle.Size.Height > textBox.Size.Height)
            {
                textBox.Size = e.NewRectangle.Size;
                this.Size = textBox.Size;
                _onResized();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Controls.Add(textBox);
            textBox.Location = new Point(0, 0);
            this.Size = textBox.Size;
            this.Location = _point;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            _onTextChanged();
        }
    }
}
