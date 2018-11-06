using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public class PopupTextForm : Form
    {
        private Action _onAccept;
        private Control _control;
        private Point _point;

        public PopupTextForm(Control control, Point point, Action onAccept)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.KeyPreview = true;
            _point = point;
            _control = control;
            _onAccept = onAccept;

        }

        protected override void OnLoad(EventArgs e)
        {
            this.Controls.Add(_control);
            _control.Location = new Point(0, 0);
            this.Size = new Size(150, 25);
            this.Location = _point;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        protected override void OnDeactivate(EventArgs e)
        {
            _onAccept();
            this.Close();
        }
    }
}