﻿using System;
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
    public partial class ColorPanel : UserControl
    {
        public Color LeftColor => leftColorButton.BackColor;
        public Color RightColor => rightColorButton.BackColor;
        private static bool _isEnter { get; set; }

        public static bool isEnter => _isEnter;

        public ColorPanel()
        {
            InitializeComponent();
        }

        //Nhấn chuột trái/phải vào ô màu sẽ đổi màu được chọn tương ứng
        private void colorButton_MouseClick(object sender, MouseEventArgs e)
        {
            ColorButton colorButton = sender as ColorButton;

            if (e.Button == MouseButtons.Left)
            {
                leftColorButton.BackColor = colorButton.BackColor;
            }

            else if (e.Button == MouseButtons.Right)
            {
                rightColorButton.BackColor = colorButton.BackColor;
            }
        }

        //Nhấn đúp chuột trái/phải vào ô màu sẽ đổi màu trong ô và màu được chọn tương ứng
        private void colorButton_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ColorButton colorButton = sender as ColorButton;
            ColorDialog colorDlg = new ColorDialog();

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                colorButton.BackColor = colorDlg.Color;

                if (e.Button == MouseButtons.Left)
                {
                    leftColorButton.BackColor = colorButton.BackColor;
                }

                else if (e.Button == MouseButtons.Right)
                {
                    rightColorButton.BackColor = colorButton.BackColor;
                }
            }
        }

        private void MouseEnter(object sender, EventArgs e)
        {
            _isEnter = true;
        }

        private void MouseLeave(object sender, EventArgs e)
        {
            _isEnter = false;
        }
    }
}
