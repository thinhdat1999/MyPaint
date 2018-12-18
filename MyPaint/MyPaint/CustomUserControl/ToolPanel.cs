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
    public partial class ToolPanel : UserControl
    {
        string _toolLabel;
        public static Button CurButton;
        public static bool isEnter;

        public string ToolLabel => _toolLabel;

        public ToolPanel()
        {
            InitializeComponent();
            ToolButton_MouseDown(PenButton, null);
            CurButton = PenButton;
        }

        // Khi chọn Button mới, nếu Button trước đó thuộc ShapePanel, hủy chọn Button đó
        // Và cập nhật Button vừa chọn (FocusedButton và Label)

        private void ToolButton_MouseDown(object sender, EventArgs e)
        {
            if (CurButton != null)
            {
                CurButton.BackColor = SystemColors.InactiveBorder;
            }

            if (ShapePanel.CurButton != null)
            {
                ShapePanel.CurButton.BackColor = SystemColors.InactiveBorder;
                ShapePanel.CurButton = null;
            }

            CurButton = sender as Button;
            CurButton.BackColor = SystemColors.ActiveBorder;
            MyPaint.DrawType = (string)CurButton.Tag;
        }

        // Khi rời Button (nếu không chọn Button đổi màu) thì hủy Button vừa rời

        private void ToolButton_Leave(object sender, EventArgs e)
        {
            if (ShapePanel.isEnter)
            {
                Button LeftButton = sender as Button;
                LeftButton.BackColor = SystemColors.InactiveBorder;
                _toolLabel = null;
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