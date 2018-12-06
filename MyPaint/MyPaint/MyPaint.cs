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
using System.IO;

namespace Paint
{
    public partial class MyPaint : Form
    {
        private DrawBox _drawBox;
        private bool _isSaved;
        private bool _isOpenYet;
        private string _filePath;

        public MyPaint()
        {
            InitializeComponent();
            KeyPreview = true;

            _drawBox = new DrawBox(DrawBoxPanel.Size);
            _isSaved = false;
            _isOpenYet = false;

            DrawBoxPanel.Controls.Add(_drawBox);
            DrawBoxSize.Text = _drawBox.Size.Height + " x " + _drawBox.Size.Width + "px";

            _drawBox.MouseDown += _drawBox_MouseDown;
            _drawBox.MouseMove += _drawBox_MouseMove;
            _drawBox.MouseLeave += _drawBox_MouseLeave;
        }

        #region Mouse Event
        private void _drawBox_MouseDown(object sender, MouseEventArgs e)
        {
            _isSaved = false;
            _drawBox.DrawColor = colorPanel.LeftColor;

            if (ShapePanel.FocusedButton != null)
            {
                _drawBox.DrawType = shapePanel.ShapeLabel;
            }
            else _drawBox.DrawType = toolPanel.ToolLabel;
        }

        private void _drawBox_MouseMove(object sender, MouseEventArgs e)
        {
            MouseLocation.Text = "X: " + e.Location.X.ToString() + "px  Y: " + e.Location.Y.ToString() + "px";
        }

        private void _drawBox_MouseLeave(object sender, EventArgs e)
        {
            MouseLocation.Text = null;
        }
        #endregion

        #region Keyboard Event
        //Khi thả nút shift
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Shift) _drawBox.isShiftPress = true;
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (!e.Shift) _drawBox.isShiftPress = false;
        }
        #endregion

        #region File MenuStrip
        // Hỏi trước khi Save
        private void AskForSave()
        {
            if (!_isSaved)
            {
                if (MessageBox.Show(@"Do you want to Save this Image?", @"Save",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    SaveImage();
                }
            }
        }

        // Save hình (kiểm tra trường hợp: đã có filePath và chưa có)
        private void SaveImage()
        {
            if (_filePath == null)
            {
                SaveFileDialog saveDlg = new SaveFileDialog();
                saveDlg.Filter = @"Bitmap Image|*.bmp|JPEG Image|*.jpeg|Png Image|*.png|Tiff Image|*.tiff|Wmf Image|*.wmf";

                if (saveDlg.ShowDialog() == DialogResult.OK)
                {
                    this.Text = Path.GetFileName(saveDlg.FileName) + " - MyPaint";
                    _filePath = saveDlg.FileName;
                    _isSaved = true;
                }
            }

            else
            {
                Bitmap _bmp = new Bitmap(_drawBox.Width, _drawBox.Height);
                _drawBox.DrawToBitmap(_bmp, new Rectangle(0, 0, _drawBox.Width, _drawBox.Height));
                _bmp.Save(_filePath);
                _isSaved = true;
            }
            _isOpenYet = false;
            isOpen();
        }

        // Tạo File vẽ mới - tạo bitmap mới gắn vào vùng DrawBox
        private void FileNew_Click(object sender, EventArgs e)
        {
            AskForSave();
            Bitmap bmp = new Bitmap(_drawBox.Width, _drawBox.Height);
            _drawBox.Image = (Image)bmp;
            _filePath = null;
            _isOpenYet = true;
            isOpen();
            _isSaved = false;
            this.Text = "MyPaint";
        }

        // Mở một file hình - tương tự Save (hỏi lưu trước khi Open)
        private void FileOpen_Click(object sender, EventArgs e)
        {
            AskForSave();

            var openDlg = new OpenFileDialog();
            openDlg.Filter = @"Bitmap Image|*.bmp|JPEG Image|*.jpeg|JPG Image|*.jpg|Png Image|*.png|Tiff Image|*.tiff|Wmf Image|*.wmf|All file|*.";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                var img = Image.FromFile(openDlg.FileName);
                _drawBox.Image = img;
                _isSaved = true;
                _isOpenYet = true;
                isOpen();
                _filePath = openDlg.FileName;
                this.Text = Path.GetFileName(openDlg.FileName) + " - MyPaint";
            }

            _isOpenYet = false;
            isOpen();
        }
        //Hàm trả về bằng true khi Open ảnh mới 
        protected bool isOpen()
        {
            if (_isOpenYet == true)
                return _drawBox.IsOpen = true;
            else
                return _drawBox.IsOpen = false;
        }

        // Thoát Form - Hỏi lưu hình trước khi thoát
        private void FileExit_Click(object sender, EventArgs e)
        {
            AskForSave();
            this.Close();
        }

        // Save hình
        private void FileSave_Click(object sender, EventArgs e)
        {
            SaveImage();
        }

        // Save As -> mở SaveDialog (không cần kiểm điều kiện)
        private void FileSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = @"Bitmap Image|*.bmp|JPEG Image|*.jpeg|JPG Image|*.jpg|Png Image|*.png|Tiff Image|*.tiff|Wmf Image|*.wmf|All file|*.";

            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                this.Text = Path.GetFileName(saveDlg.FileName) + " - MyPaint";
                _filePath = saveDlg.FileName;
                _isSaved = true;               
            }
        }

        // Click vào dấu X để tắt Form

        private void MyPaint_FormClosed(object sender, FormClosedEventArgs e)
        {
            AskForSave();
        }
        #endregion

        #region Edit MenuStrip
        private void EditUndo_Click(object sender, EventArgs e)
        {
            _drawBox.Undo();
        }

        private void EditRedo_Click(object sender, EventArgs e)
        {
            _drawBox.Redo();
        }
        #endregion

    }
}