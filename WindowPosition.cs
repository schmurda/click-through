using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickThrough
{
    [Editor(typeof(WindowPositionEditor), typeof(UITypeEditor))]
    public class WindowPosition
    {
        public Point Location { get; set; }
        public Size Size { get; set; }

        public static bool Intersect(WindowPosition pos, int x, int y)
        {
            return x >= pos.Location.X 
                   && x <= pos.Location.X + pos.Size.Width 
                   && y >= pos.Location.Y 
                   && y <= pos.Location.Y + pos.Size.Height;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Location, Size);
        }
    }
}
