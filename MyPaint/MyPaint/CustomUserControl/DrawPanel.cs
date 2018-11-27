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
    public partial class DrawPanel : UserControl
    {
        string _drawLabel;
        public string DrawLabel { get => _drawLabel; }

        Button curButton;

        public DrawPanel()
        {
            InitializeComponent();

            curButton = penButton;
            curButton.BackColor = SystemColors.ActiveBorder;
            _drawLabel = (string)curButton.Tag;
        }

        //Khi nhấn chuột vào 1 DrawIcon thì sẽ hiển thị chìm, gán DrawLabel
        //Và icon trước đó sẽ hiển thị nổi.
        private void DrawButton_Click(object sender, EventArgs e)
        {
            Button drawButton = sender as Button;
            curButton.BackColor = SystemColors.InactiveBorder;
            drawButton.BackColor = SystemColors.ActiveBorder;
            curButton = drawButton;
           _drawLabel = (string)curButton.Tag;
        }
    }
}
