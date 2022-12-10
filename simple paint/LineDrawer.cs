using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_paint
{
    static class LineDrawer
    {

        public static void DrawLine(Bitmap bitmap, int x1, int y1, int x2, int y2, Color cColor)
        {
            double k = 0;
            int y = 0;
            int x;
            k = 1.0 * (y2 - y1) / (x2 - x1);
            if (x1>x2)
            {
                (x1, x2) = (x2, x1);
                (y1, y2) = (y2, y1);                
            }
            if (x1 == x2)
            {   while (y < y2)
                    {
                    y = y1 - x1 + x2;
                    bitmap.SetPixel(x1, y, cColor);
                    }
                
            }
            
            for (x = x1; x <= x2 - x1; x++)
            {
                y = (int)Math.Round((k * x + y1));
                bitmap.SetPixel(x1 + x, y, cColor);
            }
            if (y1 == y2)
            {
                while (x < x2)
                {
                    x = x1 - y1 + y2;
                    bitmap.SetPixel(x, y1, cColor);
                }
            }


            double k2 = 0;
            
            k2 = 1.0 * (x2 - x1) / (y2 - y1);
            if (y1 < y2)
            {
                
                int lastX = x1;

                for (y = y1; y <= y2 - y1; y++)
                {
                    x = (int)Math.Round((k2 * y + x1));
                    bitmap.SetPixel(x, y1 + y, cColor);
                }
            }
        }
    }
}
