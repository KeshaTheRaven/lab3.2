﻿using System;
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
        public Color brushColor { get; set; }
        public int Size { get; set; }
        public Brush(Color BrushColor,
                     int size)
        {
            brushColor = BrushColor;
            Size = size;
        }
        public abstract void Draw (Bitmap image, int x, int y);
        
    }
    class QuadBrush : Brush
    {
        public QuadBrush (Color brushColor, int size) : base(brushColor, size) { }
        public override void Draw(Bitmap image, int x, int y)
        {
            for (int y0 = y-Size; y0 < y+Size; ++y0)
            {
                for (int x0 = x-Size; x0 < x+Size; ++x0)
                {
                    image.SetPixel(x0, y0, brushColor);
                }
            }

        }

        
    }
    internal class Circle : Brush
    {
        public Circle(Color BrushColor, int size) : base(BrushColor, size)
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
                            image.SetPixel(x0, y0, brushColor);
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
        public Eraser(Color brushColor, int size) : base(brushColor, size) { }
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

        public Spray(Color BrushColor, int size) : base(BrushColor, size)
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
                            image.SetPixel(x0, y0, brushColor);
                        }



                    }



                }

            }
        }
    }
}
