using System;
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
        private string _filename = "";
        private bool _Save ;

        //Khởi tạo các giá trị khi load form
        public MyPaint()
        {
            InitializeComponent();
            Text = "MY PAINT :\">";
            KeyPreview = true;
            ActiveControl = PenButton;

            drawBox = new DrawBox(DrawBoxLayoutPanel.Size);
            drawBox.MouseDown += drawBox_MouseDown;
            DrawBoxLayoutPanel.Controls.Add(drawBox);
        }

        private void drawBox_MouseDown(object sender, MouseEventArgs e)
        {
            drawBox.BorderColor = PaintColorPanel.GetCurrentColor();
        }

        #region Click Button
        private void PenButton_Click(object sender, EventArgs e)
        {
            drawBox.ShapeType = 0;
        }
        private void RectangleButton_Click(object sender, EventArgs e)
        {
            drawBox.ShapeType = 1;
        }

        private void EllipseButton_Click(object sender, EventArgs e)
        {
            drawBox.ShapeType = 2;
        }
        private void LineButton_Click(object sender, EventArgs e)
        {
            drawBox.ShapeType = 3;
        }
        private void TextBoxButton_Click(object sender, EventArgs e)
        {
            drawBox.ShapeType = 4;
        }
        #endregion

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
            //var tmpBitmap = drawBox.GetBitmap();
            Image img = drawBox.Image;
           // switch (_filename)
          //  {
              //  case "":
                  //  {
                        SaveFileDialog saveFileDlg = new SaveFileDialog();
                        saveFileDlg.Filter = "Images|*.png|*.bmp|*.jpg|All files(*.*)|*.*";
                        ImageFormat format = ImageFormat.Bmp;
                        if(saveFileDlg.ShowDialog()==DialogResult.OK)
                        {
                            string ext = System.IO.Path.GetExtension(saveFileDlg.FileName); 
                                switch (ext)
                            {
                                case ".jpg":
                                    format = ImageFormat.Jpeg;
                                    break;
                                case ".bmp":
                                    format = ImageFormat.Bmp;
                                    break;
                            }
                            img.Save(saveFileDlg.FileName, format);
                     //   }
                      //  {
                         //   Filter = @"Image files (*.bmp)|*.bitmap|*.png|*.jpg|All files (*.*)|*.*",
                       //     FileName = "MyPicture.bmp"
                      //  };
                    //    if (saveFileDlg.ShowDialog() != DialogResult.OK) return;
                    //    _filename = saveFileDlg.FileName;
                     //   img.Save(saveFileDialog1.FileName, ImageFormat.Bmp);            
                   // }
                   // break;
              //  default:
                  //  {
                  //      img.Save(_filename, ImageFormat.Bmp);
                  //  }
                  //  break;
            }

        }

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
                    break;
            }
        }

      

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

        private void DrawBoxLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Askforsave();
        }

        private void FileSave_Click(object sender, EventArgs e)
        {
            SaveImage();
        }
    }
}