using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Punkty
{
    class Punkt
    {
        public double x, y;
        public Punkt() { x = 0; y = 0; }
        public Punkt(double a, double b) { x = a;y = b; }
        public static Punkt operator +(Punkt pierwszy, Punkt drugi) { return new Punkt(pierwszy.x + drugi.x, pierwszy.y + drugi.y); }
    }
}
