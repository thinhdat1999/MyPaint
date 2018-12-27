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
        private string FilePath;

        public static Color LeftColor { get; private set; }
        public static Color RightColor { get; private set; }
        public static string DrawType;
        public static string DrawStyle { get; private set; }
        public static int PenWidth { get; private set; }

        public MyPaint()
        {
            // Khởi tạo các component cho form, đặt một số event cho DrawBox

            InitializeComponent();

            drawBox = DrawBoxPanel.DrawBox;
            drawBox.MouseDown += DrawBox_UpdateDrawing;
            drawBox.MouseMove += DrawBox_MouseMove;
            drawBox.MouseLeave += DrawBox_MouseLeave;
            drawBox.SizeChanged += DrawBox_SizeChange;

            DrawBoxSize.Text = drawBox.Size.ToString();
            DrawType = "Pen";
            cbStyle.SelectedIndex = 0;
        }

        #region DrawBox Event
        private void DrawBox_UpdateDrawing(object sender, MouseEventArgs e)
        {
            // Nhấn chuột vào vùng DrawBox: cập nhật các thông số để vẽ hình
            // Các thông số cập nhật: màu, kiểu vẽ, độ dày nét vẽ
            // Riêng Picker thì cập nhật lại màu trong ColorPanel

            LeftColor = colorPanel.LeftColor;
            RightColor = colorPanel.RightColor;
            DrawStyle = cbStyle.Text;
            PenWidth = (int)nudWidth.Value;

            if (DrawType == "Picker")
            {
                Bitmap bmp = new Bitmap(drawBox.Image);
                Color color = bmp.GetPixel(e.Location.X, e.Location.Y);

                if (e.Button == MouseButtons.Left)
                    colorPanel.LeftColor = color;

                else if (e.Button == MouseButtons.Right)
                    colorPanel.RightColor = color;
            }
        }

        private void DrawBox_SizeChange(object sender, EventArgs e)
        {
            // Resize DrawBox: cập nhật lại màu 2 và thông số Size tại Text

            RightColor = colorPanel.RightColor;
            DrawBoxSize.Text = drawBox.Size.ToString();
            DrawBoxPanel.Invalidate();
        }

        // Cập nhật tọa độ chuột khi di chuột trên DrawBox

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

        private void FileNew_Click(object sender, EventArgs e)
        {
            // Tạo File vẽ mới - Hỏi Save File trước khi thực hiện
            // Tạo DrawBox mới: tô màu nền trắng, xóa list Undo, Redo và FilePath

            var AskForSave = MessageBox.Show(@"Do you want to Save this Image?", @"Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (AskForSave == DialogResult.Cancel)
                return;

            else if (AskForSave == DialogResult.Yes)
            {
                FileSave_Click(null, null);
            }

            drawBox.Size = new Size(700, 300);
            drawBox.Image = new Bitmap(drawBox.Width, drawBox.Height);
            drawBox.ClearUndoRedo();
            Region region = new Region(new Rectangle(0, 0, drawBox.Width, drawBox.Height));
            Graphics _g = Graphics.FromImage(drawBox.Image);
            _g.FillRegion(new SolidBrush(Color.White), region);

            FilePath = null;
            this.Text = "MyPaint";
        }

        // Mở một file hình - tương tự Save (hỏi lưu trước khi Open)
        private void FileOpen_Click(object sender, EventArgs e)
        {
            var AskForSave = MessageBox.Show(@"Do you want to Save this Image?", @"Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (AskForSave == DialogResult.Cancel)
                return;

            else if (AskForSave == DialogResult.Yes)
                FileSave_Click(null, null);

            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = @"Image files (*.jpg, *.jpeg, *.wmf, *.tiff, *.png) | *.jpg; *.jpeg; *.wmf; *.tiff; *.png";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                //Mở file hình bằng memoryStream để tránh lỗi generic khi lưu do mở file
                Byte[] bytes = File.ReadAllBytes(openDlg.FileName);
                MemoryStream stream = new MemoryStream(bytes);
                Image img = Image.FromStream(stream);
                drawBox.Size = img.Size;
                drawBox.Image = img;
                drawBox.ClearUndoRedo();
                FilePath = openDlg.FileName;
                this.Text = Path.GetFileName(openDlg.FileName) + " - MyPaint";
            }
        }

        // Thoát Form - Hỏi lưu hình trước khi thoát
        private void FileExit_Click(object sender, EventArgs e)
        {
            var AskForSave = MessageBox.Show(@"Do you want to Save this Image?", @"Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (AskForSave == DialogResult.Cancel)
                return;

            else if (AskForSave == DialogResult.Yes)
                FileSave_Click(null, null);

            this.Close();
        }

        private void FileSave_Click(object sender, EventArgs e)
        {
            if (FilePath == null)
            {
                SaveFileDialog saveDlg = new SaveFileDialog();
                saveDlg.Filter = @"PNG (*.png)|*.png|Bitmap|*.bmp|JPEG|*.jpeg|JPG|*.jpg|Tiff Image|*.tiff|Wmf Image|*.wmf|All file|*.*";
                if (saveDlg.ShowDialog() == DialogResult.OK)
                {
                    this.Text = Path.GetFileName(saveDlg.FileName) + " - MyPaint";
                    FilePath = saveDlg.FileName;
                    Bitmap bmp = new Bitmap(drawBox.Width, drawBox.Height);
                    drawBox.DrawToBitmap(bmp, new Rectangle(0, 0, drawBox.Width, drawBox.Height));
                    bmp.Save(FilePath);
                }
            }

            else
            {
                if (File.Exists(FilePath))
                    File.Delete(FilePath);
                Bitmap bmp = new Bitmap(drawBox.Width, drawBox.Height);
                drawBox.DrawToBitmap(bmp, new Rectangle(0, 0, drawBox.Width, drawBox.Height));
                bmp.Save(FilePath);
            }
        }

        // Save As -> mở SaveDialog (không cần kiểm điều kiện)
        private void FileSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = @"PNG (*.png)|*.png|Bitmap|*.bmp|JPEG|*.jpeg|JPG|*.jpg|Tiff Image|*.tiff|Wmf Image|*.wmf|All file|*.*";
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                this.Text = Path.GetFileName(saveDlg.FileName) + " - MyPaint";
                FilePath = saveDlg.FileName;
            }
        }
        #endregion

        #region Edit MenuStrip
        private void EditUndo_Click(object sender, EventArgs e)
        {
            drawBox.Undo();
        }

        private void EditRedo_Click(object sender, EventArgs e)
        {
            drawBox.Redo();
        }
        #endregion
    }
}