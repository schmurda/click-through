using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickThrough
{
    public struct WindowPosition
    {
        public static WindowPosition LeftMonitor = new WindowPosition
        {
            X = -493,
            Y = 747,
            Width = 500,
            Height = 300
        };

        public static WindowPosition RightMonitor = new WindowPosition
        {
            X = 1913,
            Y = 747,
            Width = 500,
            Height = 500
        };

        public int X;
        public int Y;
        public int Width;
        public int Height;

        public static bool Intersect(WindowPosition pos, int x, int y)
        {
            return x >= pos.X && x <= pos.X + pos.Width && y >= pos.Y && y <= pos.Y + pos.Height;
        }
    }
}
