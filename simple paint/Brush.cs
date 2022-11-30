using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simple_paint
{
    abstract class Brush
    {
        public static int W, H;
        public static void GetSize(int w, int h)
        {
            W = w;
            H = h;
        }
        public Color cColor { get; set; }
        public int Size { get; set; }
        public Brush(Color cColor,
                     int size)
        {
            this.cColor = cColor;
            Size = size;
        }
        public abstract void Draw (Bitmap image, int x, int y);
        
    }
    class QuadBrush : Brush
    {
        public QuadBrush (Color cColor, int size) : base(cColor, size) { }
        public override void Draw(Bitmap image, int x, int y)
        {
            for (int y0 = y-Size; y0 < y+Size; ++y0)
            {
                for (int x0 = x-Size; x0 < x+Size; ++x0)
                {
                    image.SetPixel(x0, y0, cColor);
                }
            }

        }

        
    }
    internal class Circle : Brush
    {
        public Circle(Color cColor, int size) : base(cColor, size)
        {

        }

        public override void Draw(Bitmap image, int x, int y)
        {
            int R = Size;

            for (int y0 = y - Size; y0 < y + Size; ++y0)
            {
                for (int x0 = x - Size; x0 < x + Size; ++x0)
                {

                    if (((x - x0) * (x - x0)) + ((y - y0) * (y - y0)) < (Size * Size))
                    {
                        try
                        {
                            image.SetPixel(x0, y0, cColor);
                        }
                        catch (Exception)
                        {


                        }
                    }



                }

            }
        }
    }
    internal class Eraser : Brush
    {
        public Eraser(Color cColor, int size) : base(cColor, size) { }
        public override void Draw(Bitmap image, int x, int y)
        {
            for (int y0 = y - Size; y0 < y + Size; ++y0)
            {
                for (int x0 = x - Size; x0 < x + Size; ++x0)
                {
                    image.SetPixel(x0, y0, Color.White);
                }
            }
        }
    }
    internal class Spray : Brush
    {

        public Spray(Color cColor, int size) : base(cColor, size)
        {

        }



        public override void Draw(Bitmap image, int x, int y)
        {
            Random rnd = new Random();
            for (int y0 = y - Size; y0 < y + Size; ++y0)
            {
                for (int x0 = x - Size; x0 < x + Size; ++x0)
                {
                    int randomNumber2 = rnd.Next(1, 25);
                    if (randomNumber2 == 5)
                    {
                        if (x0 > 0 & y0 > 0 & x0 < W & y0 < H)
                        {
                            image.SetPixel(x0, y0, cColor);
                        }



                    }



                }

            }
        }
    }
    internal class CrocodileStramp : Brush
    {
        public CrocodileStramp(Color cColor, int size) : base(cColor, size)
        {

        }

        public override void Draw(Bitmap image, int x, int y)
        {
            //r = 2*sin( 5*p)

            int n = 5;               // число вершин
            double R = Size, r = Size*2;   // радиусы
            double alpha = 0;        // поворот
            double a = alpha, da = Math.PI / n, l;
            for (int k = 0; k < 2 * n + 1; k++)
            {
                for (int y0 = y - Size; y0 < y + Size; ++y0)
                {
                    for (int x0 = x - Size; x0 < x + Size; ++x0)
                    {
                        l = k % 2 == 0 ? r : R;
                        int T = (int)(x0 + l * Math.Cos(a));
                        int Y= (int)(y0 + l * Math.Sin(a));
                        a += da;

                        image.SetPixel(T, Y, cColor);
                    }
                }
            }

            
        }
    }
    internal class octoFlower : Brush
    {
        public octoFlower(Color cColor, int size) : base(cColor, size)
        {

        }

        public override void Draw(Bitmap image, int x, int y)
        {
            //r = 2*sin( 5*p)

            int n = 6;               // число вершин
            double R = Size, r = Size * 2;   // радиусы
            double alpha = 0;        // поворот



            PointF[] points = new PointF[2 * n + 1];
            double a = alpha, da = Math.PI / n, l;
            for (int k = 0; k < 2 * n + 1; k++)
            {
                for (int y0 = y - Size; y0 < y + Size; ++y0)
                {
                    for (int x0 = x - Size; x0 < x + Size; ++x0)
                    {

                        l = k % 2 == 0 ? r : R;
                        int X = (int)(Math.Cos(x)/Size);
                        int Y = (int)(Math.Sin(y) / Size);
                        a += da;

                        image.SetPixel(X, Y, cColor);
                    }

                }
            }


        }
    }
}
