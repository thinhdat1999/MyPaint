using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class ShapePanel : UserControl
    {
        string _shapeLabel;
        public static Button CurButton;
        public static bool isEnter;

        public string ShapeLabel => _shapeLabel;

        public ShapePanel()
        {
            InitializeComponent();
        }

        // Khi chọn Button mới, nếu Button trước đó thuộc ToolPanel, hủy chọn Button đó
        // Và cập nhật Button vừa chọn (FocusedButton và Label)

        private void ShapeButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (CurButton != null)
            {
                CurButton.BackColor = SystemColors.InactiveBorder;
            }

            if (ToolPanel.CurButton != null)
            {
                ToolPanel.CurButton.BackColor = SystemColors.InactiveBorder;
                ToolPanel.CurButton = null;
            }

            CurButton = sender as Button;
            CurButton.BackColor = SystemColors.ActiveBorder;
            MyPaint.DrawType = (string) CurButton.Tag;
        }

        // Khi rời Button (nếu không chọn Button đổi màu) thì hủy Button vừa rời

        private void ShapeButton_Leave(object sender, EventArgs e)
        {
            if (ToolPanel.isEnter)
            {
                Button LeftButton = sender as Button;
                LeftButton.BackColor = SystemColors.InactiveBorder;
                _shapeLabel = null;
            }
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            isEnter = true;
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            isEnter = false;
        }
    }
}