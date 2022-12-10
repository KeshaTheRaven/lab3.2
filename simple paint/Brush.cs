using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Metadata;
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
        public abstract void Draw(Bitmap image, int x, int y);

    }
    class QuadBrush : Brush
    {
        public QuadBrush(Color cColor, int size) : base(cColor, size) { }
        public override void Draw(Bitmap image, int x, int y)
        {
            for (int y0 = y - Size; y0 < y + Size; ++y0)
            {
                for (int x0 = x - Size; x0 < x + Size; ++x0)
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




            for (int y0 = y - Size; y0 < y + Size; ++y0)
            {
                for (int x0 = x - Size; x0 < x + Size; ++x0)
                {
                    image.SetPixel(x0, y - x + x0, cColor);
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
            int a = 2 * Size;
            double R = 0;
            double alpha = 0;
            double beta = 0;
            int x0 = x;
            int y0 = y;
            double t = 0.15;

    
            int x1 = 0;
            int y1 = 0;
            double V = 0;
            double C = 0;
            double D = 0;
            float b = 0;

            for (double n = 0; n < 2 * Math.PI; n += t)
            {

                R = a * Math.Sin(8 * n);
                alpha = y + Math.Sin(n) * R;
                beta = x + Math.Cos(n) * R;
                y0 = (int)alpha;
                x0 = (int)beta;
                image.SetPixel(x0, y0, cColor);
                y1 = y0;
                x1 = x0;


                if (x1<x0)
                {
                    for(int x2 = x1; x2 < x0; x2++)
                    image.SetPixel(x0, y1-x0+x1, cColor);
                }

               






                //for (int x2 = x1; x2 < x0; x2++)
                //{
                //    y2 = ((x1 - x0) + (y1 - x0)) / (y1 - y0) + x0;
                //    image.SetPixel(x2, y2, cColor);

                //}

                //while (x1 < x0 & y1 < y0)
                //{
                //    x1 = (y0 - y2) * (x2 - x0) / (y2 - y0) + x0;
                //    y1 = (x0 - x2) + (y2 - x0) / (x2 - x0) + y0;
                //    image.SetPixel(x1, y0, cColor);

                //}



                //if (n>1) {
                //    for (int i = 0; i <  Size; i++)
                //    {
                //        double e = alpha - x2;
                //        double r = y0 - y2;
                //        Math.Pow(e, 2);
                //        Math.Pow(r, 2);
                //        C = Math.Sqrt(e + r);
                //        D = e / r;
                //        b = (x2 * y0 + y2 * x0) / (x2 - x0);
                //        V = x1 * D + b;
                //        y = (int)V;

                //        image.SetPixel(x1, y1, cColor);
                //        x1 = (int)((V - b) / D);
                //    } }

                //double e = x0 - x2;
                //double r = y0 - y2;
                //Math.Pow(e, 2);
                //Math.Pow(r, 2);
                //C = Math.Sqrt(e + r);
                //D = e / r;
                //b = (x2 * y0 + y2 * x1) / (x2 - x0);



                //for (int i = y2; i < y0; i++)
                //{

                //    y1 = (int)(x1 * C + b);
                //    x1 = (int)((y1 - b) / C);
                //    image.SetPixel(x2, y1, cColor);

                //    e = x0 - x2;
                //    r = y0 - y2;
                //    Math.Pow(e, 2);
                //    Math.Pow(r, 2);
                //    C = Math.Sqrt(e + r);
                //    D = e / r;
                //    b = (x2 * y0 + y2 * x2) / (x2 - x0);




                //}








            }
        }
    }

}