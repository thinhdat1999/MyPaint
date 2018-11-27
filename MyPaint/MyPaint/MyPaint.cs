﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Paint
{
    public partial class MyPaint : Form
    {
        private DrawBox drawBox;

        public MyPaint()
        {
            InitializeComponent();
            Text = "MY PAINT :\">";
            KeyPreview = true;

            drawBox = new DrawBox(DrawBoxPanel.Size);
            DrawBoxPanel.Controls.Add(drawBox);
            DrawBoxSize.Text = drawBox.Size.Height + " x " + drawBox.Size.Width + "px";

            drawBox.MouseDown += drawBox_MouseDown;
            drawBox.MouseMove += drawBox_MouseMove;
            drawBox.MouseLeave += drawBox_MouseLeave;
        }

        #region Mouse Location
        private void drawBox_MouseDown(object sender, MouseEventArgs e)
        {
            drawBox.DrawColor = colorPanel1.LeftColor;
            drawBox.DrawType = drawPanel.DrawLabel;
        }

        private void drawBox_MouseMove(object sender, MouseEventArgs e)
        {
            MouseLocation.Text = "X: " + e.Location.X.ToString() + "px  Y: " + e.Location.Y.ToString() + "px";
        }

        private void drawBox_MouseLeave(object sender, EventArgs e)
        {
            MouseLocation.Text = null;
        }
        #endregion

        #region Keyboard Event
        //Tạo sự kiện Undo, Redo khi nhấn các tổ hợp phím Ctrl + Z, Ctrl + Y, Shift
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
            {
                drawBox.Undo();
            }
            else if (e.Control && e.KeyCode == Keys.Y)
            {
                drawBox.Redo();
            }
            else if (e.Shift) drawBox.isShiftPress = true;
        }

        //Khi thả nút shift
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (!e.Shift) drawBox.isShiftPress = false;
        }
        #endregion

        //Lưu
        private void Askforsave()
        {
            var result = MessageBox.Show(@"Do you want to Save this Image?", @"Save",
                                                     MessageBoxButtons.YesNoCancel,
                                                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            switch (result)
            {
                case DialogResult.Yes:
                    SaveImage();
                    Close();
                    break;
                case DialogResult.No:
                    Close();
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }
        private void SaveImage()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Images|*.png|*.bmp|*.jpg|All files(*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                int width = Convert.ToInt32(drawBox.Width);
                int height = Convert.ToInt32(drawBox.Height);
                Bitmap bmp = new Bitmap(width, height);
                drawBox.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));               
                bmp.Save(sfd.FileName, ImageFormat.Jpeg);
            }
        }
        //New Click
        private void FileNew_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(@"Do you want to save this Image?", @"Save",
                                                          MessageBoxButtons.YesNoCancel,
                                                          MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            switch (result)
            {
                case DialogResult.Yes:
                    SaveImage();
                    break;
                case DialogResult.No:
                    Bitmap DrawBitmap = new Bitmap(Width, Height);
                    drawBox.Image = (Image)DrawBitmap;
                    break;
            }
        }
        //Open Click
        private void FileOpen_Click(object sender, EventArgs e)
        {
            var openDlg = new OpenFileDialog
            {
                Filter = @"Image files (*.bmp)|*.bmp|All files (*.*)|*.*"
            };
            switch (openDlg.ShowDialog())
            {
                case DialogResult.OK:
                    {
                        var img = Image.FromFile(openDlg.FileName);
                        drawBox.Image = img;
                    }
                break;
            }

        }
        //Exit Click
        private void FileExit_Click(object sender, EventArgs e)
        {
            Askforsave();
        }
        //Save Click
        private void FileSave_Click(object sender, EventArgs e)
        {
            SaveImage();
        }
    }
}