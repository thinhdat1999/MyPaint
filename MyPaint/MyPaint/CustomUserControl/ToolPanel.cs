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
        public static Button FocusedButton;

        public string ToolLabel { get => _toolLabel; }

        public ToolPanel()
        {
            InitializeComponent();
        }

        // Khi chọn Button mới, nếu Button trước đó thuộc ShapePanel, hủy chọn Button đó
        // Và cập nhật Button vừa chọn (FocusedButton và Label)

        private void ToolButton_MouseDown(object sender, EventArgs e)
        {
            Button SelectedButton = sender as Button;

            if (ShapePanel.FocusedButton != null)
            {
                ShapePanel.FocusedButton.BackColor = SystemColors.InactiveBorder;
                ShapePanel.FocusedButton = null;
            }
            
            SelectedButton.BackColor = SystemColors.ActiveBorder;
            _toolLabel = (string) SelectedButton.Tag;

            FocusedButton = SelectedButton;
        }

        // Khi rời Button (nếu không chọn Button đổi màu) thì hủy Button vừa rời

        private void ToolButton_Leave(object sender, EventArgs e)
        {
            Button LeftButton = sender as Button;

            if (FocusedButton != null && !ColorPanel.isEnter)
            {
                FocusedButton.BackColor = SystemColors.InactiveBorder;
                FocusedButton = null;
                _toolLabel = null;
            }
        }
    }
}