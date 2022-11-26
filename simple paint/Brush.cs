using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    internal class Octoflower : Brush
    {
        public Octoflower(Color cColor, int size) : base(cColor, size)
        {

        }

        public override void Draw(Bitmap image, int x, int y)
        {
            //r = 2*sin( 5*p)
                      
            double a=0;
            for (double y0 = y - Size; y0<y+Size; ++y)
            {
                for (double x0 = x - Size; x0 < x + Size; ++x0)
                {
                    double r =  Math.Cos(a);
                    double g =  Math.Sin(a);
                    image.SetPixel((int)r, (int)g, cColor);
                    a += Math.PI;

                }
            }
            
        }
    }
}
