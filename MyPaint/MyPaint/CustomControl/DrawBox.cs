using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    class DrawBox : PictureBox
    {
        private PictureBox pictureBox;
        private Bitmap DrawArea;

        private Stack<Bitmap> UndoList;
        private Stack<Bitmap> RedoList;

        private bool _isDrawing = false;
        private bool _isClear = true;

        public bool isDrawing { get => _isDrawing; }
        public bool isClear { get => _isClear; }

        //Constructor tạo DrawBox
        public DrawBox()
        {
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;

            _isDrawing = false;
            _isClear = true;

            UndoList = new Stack<Bitmap>();
            RedoList = new Stack<Bitmap>();
        }

        //PictureBox sẽ tải lại hình cũ khi cập nhật vẽ hình mới liên tục
        public void UpdatePictureBox()
        {
            if (DrawArea != null)
            {
                BackgroundImage = DrawArea.Clone(new Rectangle(0, 0, Width, Height), DrawArea.PixelFormat);
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            _isDrawing = true;
            _isClear = false;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _isDrawing = false;
            UpdatePictureBox();
        }

        //Thực hiện Undo, nếu DrawBox chưa trống thì chèn Bitmap hiện tại vào Redo để có thể hoàn tác
        public void Undo()
        {
            if (!_isClear)
            {
                RedoList.Push(new Bitmap(BackgroundImage));
            }

            if (UndoList.Count > 0 && UndoList.Peek() != null)
            {
                DrawArea = new Bitmap(UndoList.Pop(), Size);
            }
            else
            {
                DrawArea = new Bitmap(Width, Height);
                _isClear = true;
            }
        }
        
        //Thực hiện Redo, nếu DrawBox chưa trống thì chèn Bitmap hiện tại vào Redo để có thể hoàn tác
        public void Redo()
        {
            if (!_isClear)
            {
                UndoList.Push(new Bitmap(BackgroundImage));
            }

            if (RedoList.Count > 0 && RedoList.Peek() != null)
            {
                DrawArea = new Bitmap(RedoList.Pop(), Size);
                _isClear = false;
            }
        }
    }
}
