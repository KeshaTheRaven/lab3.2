using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_paint
{
    abstract class Brush
    {
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
}
