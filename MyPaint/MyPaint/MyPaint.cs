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
using System.IO;

namespace Paint
{
    public partial class MyPaint : Form
    {
        private DrawBox drawBox;
        private bool _isSaved;
        private bool _isOpenYet;
        private string _filePath;

        public static Color LeftColor;
        public static Color RightColor;
        public static string DrawType;
        public static string DrawStyle;
        public static int PenWidth;

        public MyPaint()
        {
            InitializeComponent();
            KeyPreview = true;

            drawBox = DrawBoxPanel.DrawBox;
            _isSaved = false;
            _isOpenYet = false;

            drawBox.MouseDown += DrawBox_UpdateDrawing;
            drawBox.MouseMove += DrawBox_MouseMove;
            drawBox.MouseLeave += DrawBox_MouseLeave;
            drawBox.SizeChanged += DrawBox_SizeChange;
            
            DrawBoxSize.Text = drawBox.Size.ToString();
            StyleComboBox.SelectedIndex = 0;
        }

        #region DrawBox Event
        private void DrawBox_UpdateDrawing(object sender, MouseEventArgs e)
        {
            LeftColor = colorPanel.LeftColor;
            RightColor = colorPanel.RightColor;
            DrawStyle = StyleComboBox.Text;

            if (shapePanel.ShapeLabel != null)
                DrawType = shapePanel.ShapeLabel;
            else DrawType = toolPanel.ToolLabel;
        }
        
        private void DrawBox_SizeChange(object sender, EventArgs e)
        {
            RightColor = colorPanel.RightColor;
            DrawBoxSize.Text = drawBox.Size.ToString();
        }

        private void DrawBox_MouseMove(object sender, MouseEventArgs e)
        {
            MouseLocation.Text = e.Location.ToString();
        }

        private void DrawBox_MouseLeave(object sender, EventArgs e)
        {
            MouseLocation.Text = null;
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
                saveDlg.Filter = @"PNG (*.png)|*.png|Bitmap|*.bmp|JPEG|*.jpeg|JPG|*.jpg|Tiff Image|*.tiff|Wmf Image|*.wmf|All file|*.*";
                if (saveDlg.ShowDialog() == DialogResult.OK)
                {
                    this.Text = Path.GetFileName(saveDlg.FileName) + " - MyPaint";
                    _filePath = saveDlg.FileName;
                    _isSaved = true;
                    Bitmap _bmp = new Bitmap(drawBox.Width, drawBox.Height);
                    drawBox.DrawToBitmap(_bmp, new Rectangle(0, 0, drawBox.Width, drawBox.Height));
                    _bmp.Save(_filePath);
                }
            }

            else
            {
                if (System.IO.File.Exists(_filePath))
                    System.IO.File.Delete(_filePath);
                Bitmap _bmp = new Bitmap(drawBox.Width, drawBox.Height);
                drawBox.DrawToBitmap(_bmp, new Rectangle(0, 0, drawBox.Width, drawBox.Height));
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
            Bitmap bmp = new Bitmap(drawBox.Width, drawBox.Height);
            drawBox.Image = (Image)bmp;
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
            openDlg.Filter = @"All file|*.*|Bitmap Image|*.bmp|JPEG Image|*.jpeg|JPG Image|*.jpg|Png Image|*.png|Tiff Image|*.tiff|Wmf Image|*.wmf";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {

                Byte[] bytes = File.ReadAllBytes(openDlg.FileName);
                MemoryStream stream = new MemoryStream(bytes);
                Image img = Image.FromStream(stream);
                drawBox.Image = img;
                drawBox.Size = img.Size;
                DrawBoxPanel.Refresh();
                _isSaved = true;
                _isOpenYet = true;
                drawBox.CheckOpen();
                _filePath = openDlg.FileName;
                this.Text = Path.GetFileName(openDlg.FileName) + " - MyPaint";
            }
        }
        //Hàm trả về bằng true khi Open ảnh mới 
        protected bool isOpen()
        {
            if (_isOpenYet == true)
                return drawBox.IsOpen = true;
            else
                return drawBox.IsOpen = false;
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
            saveDlg.Filter = @"PNG (*.png)|*.png|Bitmap|*.bmp|JPEG|*.jpeg|JPG|*.jpg|Tiff Image|*.tiff|Wmf Image|*.wmf|All file|*.*";
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                this.Text = Path.GetFileName(saveDlg.FileName) + " - MyPaint";
                _filePath = saveDlg.FileName;
                _isSaved = true;
            }
        }
        #endregion

        #region Edit MenuStrip
        private void EditUndo_Click(object sender, EventArgs e)
        {
            drawBox.Undo();
            DrawBoxPanel.Invalidate();
        }

        private void EditRedo_Click(object sender, EventArgs e)
        {
            drawBox.Redo();
            DrawBoxPanel.Invalidate();
        }
        #endregion
    }
}