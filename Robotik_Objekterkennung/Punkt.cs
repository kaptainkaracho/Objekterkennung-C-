using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robotik_Objekterkennung
{
    class Punkt
    {
        private double x;
        private double y;

        public Punkt(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double getX(){
            return x;
        }

        public double getY()
        {
            return y;
        }
    }
}
