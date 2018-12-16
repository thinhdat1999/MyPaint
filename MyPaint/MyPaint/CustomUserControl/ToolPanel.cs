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
        Button CurButton;

        public string ToolLabel => _toolLabel;

        public ToolPanel()
        {
            InitializeComponent();
        }

        // Khi chọn Button mới, nếu Button trước đó thuộc ShapePanel, hủy chọn Button đó
        // Và cập nhật Button vừa chọn (FocusedButton và Label)

        private void ToolButton_MouseDown(object sender, EventArgs e)
        {
            Button SelectedButton = sender as Button;

            if (CurButton != null)
            {
                CurButton.BackColor = SystemColors.InactiveBorder;
                CurButton = SelectedButton;
            }
            
            SelectedButton.BackColor = SystemColors.ActiveBorder;
            _toolLabel = (string) SelectedButton.Tag;
        }

        // Khi rời Button (nếu không chọn Button đổi màu) thì hủy Button vừa rời

        private void ToolButton_Leave(object sender, EventArgs e)
        {
            if (!ColorPanel.isEnter)
            {
                Button LeftButton = sender as Button;
                LeftButton.BackColor = SystemColors.InactiveBorder;
                _toolLabel = null;
            }
        }
    }
}