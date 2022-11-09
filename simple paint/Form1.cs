using System.Windows.Forms;

namespace simple_paint
{
    
    public partial class Form1 : Form
    {
        int _x;
        int _y;
        bool _mouseClicked = false;
        Color SelectedColor
        {
            get { return Color.Red; }
        }
        int SelectedSize
        {
            get { return trackBar1.Value; }
        }
        

        Brush _selectedBrush ;
        Color DefaultColor
        {
            get { return Color.White; }
        }
        public Form1()
        {
            InitializeComponent();
            if (_selectedBrush == null) //программа жаловалась на Null в кисти и я сделал так чтобы она перестала это
            {
                _selectedBrush = new QuadBrush(SelectedColor, SelectedSize);
            }
            
            CreateBlank(pictureBox1.Width, pictureBox1.Height);
        }

        void CreateBlank(int width, int height)
        {
            var oldImage = pictureBox1.Image;
            var bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    bmp.SetPixel(i, j, DefaultColor);
                }
            }

            pictureBox1.Image = bmp;
            if (oldImage != null) { oldImage.Dispose(); }

        }
        private void kvadr_Click(object sender, EventArgs e)
        {
            _selectedBrush = new QuadBrush(SelectedColor, SelectedSize);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(_selectedBrush == null)
            {
                //brush тип не выбрана кисть
                return;
            }
            _x = e.X > 0 ? e.X : 0;
            _y = e.Y > 0 ? e.Y : 0;
            _selectedBrush.Draw((Bitmap)pictureBox1.Image, x: _x, y: _y);
            pictureBox1.Refresh();
            _mouseClicked = true;


        }

        private void pictureBox1_Mouseup(object sender, MouseEventArgs e)
        {
            _mouseClicked = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            _x = e.X > 0 ? e.X :0;
            _y = e.Y > 0 ? e.Y :0;
            if (_mouseClicked)
            {
                _selectedBrush.Draw( (Bitmap)pictureBox1.Image, _x, _y);
                pictureBox1.Refresh();
            }
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void drawPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void krug_Click(object sender, EventArgs e)
        {
            _selectedBrush = new Circle(SelectedColor, SelectedSize);
        }
    }
}