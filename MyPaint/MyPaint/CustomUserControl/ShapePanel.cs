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
        private static string _shapeLabel { get; set; }
        public static string ShapeLabel => _shapeLabel;

        Button CurButton;

        public ShapePanel()
        {
            InitializeComponent();
        }

        // Khi chọn Button mới, nếu Button trước đó thuộc ToolPanel, hủy chọn Button đó
        // Và cập nhật Button vừa chọn (FocusedButton và Label)

        private void ShapeButton_MouseDown(object sender, MouseEventArgs e)
        {
            Button SelectedButton = sender as Button;
            if (CurButton != null)
            {
                CurButton.BackColor = SystemColors.InactiveBorder;
                CurButton = SelectedButton;
            }

            SelectedButton.BackColor = SystemColors.ActiveBorder;
            _shapeLabel = (string) SelectedButton.Tag;
        }

        // Khi rời Button (nếu không chọn Button đổi màu) thì hủy Button vừa rời

        private void ShapeButton_Leave(object sender, EventArgs e)
        {
            if (!ColorPanel.isEnter)
            {
                Button LeftButton = sender as Button;
                LeftButton.BackColor = SystemColors.InactiveBorder;
                _shapeLabel = null;
            }
        }
    }
}