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
        public static Button FocusedButton;

        public string ShapeLabel { get => _shapeLabel; }

        public ShapePanel()
        {
            InitializeComponent();
        }

        // Khi chọn Button mới, nếu Button trước đó thuộc ToolPanel, hủy chọn Button đó
        // Và cập nhật Button vừa chọn (FocusedButton và Label)

        private void ShapeButton_MouseDown(object sender, MouseEventArgs e)
        {
            Button SelectedButton = sender as Button;

            if (ToolPanel.FocusedButton != null)
            {
                ToolPanel.FocusedButton.BackColor = SystemColors.InactiveBorder;
                ToolPanel.FocusedButton = null;
            }

            SelectedButton.BackColor = SystemColors.ActiveBorder;
            _shapeLabel = (string) SelectedButton.Tag;

            FocusedButton = SelectedButton;
        }

        // Khi rời Button (nếu không chọn Button đổi màu) thì hủy Button vừa rời

        private void ShapeButton_Leave(object sender, EventArgs e)
        {
            Button LeftButton = sender as Button;

            if (FocusedButton != null && !ColorPanel.isEnter)
            {
                LeftButton.BackColor = SystemColors.InactiveBorder;
                FocusedButton = null;
                _shapeLabel = null;
            }
        }
    }
}