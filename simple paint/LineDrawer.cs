using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_paint
{
    static class LineDrawer
    {
        
        public static void DrawLine(Bitmap bitmap, int x1,int y1, int x2, int y2, Color cColor)
        {
            double k = 0;
            int y = 0;
            int x;
            k = 1.0 * (y2 - y1) / (x2 - x1);
            if (x1<x2)
            {
                int lastY = y1;
                for (x = 0; x <= x2-x1; x++)
                {        
                    
                    y = (int)Math.Round((k * x + y1));
                    bitmap.SetPixel(x1+x, y, cColor);
                }
            }
            else
            {
                for (int i = y2; i > y1; i++)
                {

                    int x0 = 0;
                    x0 = (int)((i - y1) / k);
                    bitmap.SetPixel(x0, i, cColor);



                }
            }

            double k2 = 0;
            x = 0;
            k2 = 1.0 * (x2 - x1) / (y2 - y1);
            if (y1 < y2)
            {
                int lastX = x1;
                for (y = 0; y <= y2 - y1; y++)
                {
                    x = (int)Math.Round((k2 * y + x1));
                    bitmap.SetPixel(x, y1 + y, cColor);
                }
            }
        }
    }
}
