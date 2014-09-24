using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robotik_Objekterkennung
{
    class Funktionen
    {
        // berechnet den Flächeninhalt eines Polygons
        static public double calcAreaPolygon(List<Punkt> inputPoints)
        {
            List<Punkt> points = new List<Punkt>();
            // transferieren der Punktdaten
            for (int i = 0; i < inputPoints.Count; i++)
            {
                points.Add(inputPoints[i]);
            }

            // Liste mit sortierten Punkten
            List<Punkt> calcPoints = new List<Punkt>();
            Punkt tmpPoint = null;

            // Punkt 1
            double a = 100000.00;
            for (int i = 0; i < points.Count; i++)
            {
                // suche nach der geringsten Distanz zum Ursprung
                double t = Math.Sqrt(Math.Pow(points[i].getX(), 2) + Math.Pow(points[i].getY(), 2));
                if (t < a) {
                    a = t;
                    tmpPoint = points[i];
                }
            }

            calcPoints.Add(tmpPoint);
            points.Remove(tmpPoint);

            tmpPoint = null;
            
            // Punkt 2
            Punkt y_min = new Punkt(100000.0, 10000.0);
            tmpPoint = new Punkt(100000.0, 100000.0);

            for (int i = 0; i < points.Count; i++)
            {
                if (y_min.getY() > points[i].getY())
                {
                    y_min = points[i];
                }
            }

            for (int i = 0; i < points.Count; i++)
            {
                if (points[i] != y_min)
                {
                    if (tmpPoint.getX() > points[i].getX())
                    {
                        tmpPoint = points[i];
                    }
                }
            }

            calcPoints.Add(tmpPoint);
            points.Remove(tmpPoint);

            tmpPoint = null;
            y_min = null;

            // Punkt 3
            y_min = new Punkt(100000.0, 10000.0);
            tmpPoint = new Punkt(0.0, 0.0);

            for (int i = 0; i < points.Count; i++)
            {
                if (y_min.getY() > points[i].getY())
                {
                    y_min = points[i];
                }
            }

            for (int i = 0; i < points.Count; i++)
            {
                if (points[i] != y_min)
                {
                    if (tmpPoint.getX() < points[i].getX())
                    {
                        tmpPoint = points[i];
                    }
                }
            }

            calcPoints.Add(tmpPoint);
            points.Remove(tmpPoint);

            tmpPoint = null;

            // Punkt 4
            calcPoints.Add(points[0]);

            // Berechnung der Fläche anhand eines Polygonzuges
            double area = (calcPoints[0].getY() + calcPoints[1].getY()) * (calcPoints[0].getX() - calcPoints[1].getX()) +
                (calcPoints[1].getY() + calcPoints[2].getY()) * (calcPoints[1].getX() - calcPoints[2].getX()) +
                (calcPoints[2].getY() + calcPoints[3].getY()) * (calcPoints[2].getX() - calcPoints[3].getX()) +
                (calcPoints[3].getY() + calcPoints[0].getY()) * (calcPoints[3].getX() - calcPoints[0].getX());

            if (area < 0)
            {
                area = area * -1;
            }

            return area / 2;
        }

        // berechnet den Mittelpunkt eines Viereckes
        static public Punkt calcCenterCube(List<Punkt> inputPoints)
        {
            List<Punkt> points = new List<Punkt>();
            // transferieren der Punktdaten
            for (int i = 0; i < inputPoints.Count; i++)
            {
                points.Add(inputPoints[i]);    
            }

            // Liste mit sortierten Punkten
            List<Punkt> calcPoints = new List<Punkt>();
            Punkt tmpPoint = null;

            // Punkt 1
            double a = 100000.00;
            for (int i = 0; i < points.Count; i++)
            {
                // suche nach der geringsten Distanz zum Ursprung
                double t = Math.Sqrt(Math.Pow(points[i].getX(), 2) + Math.Pow(points[i].getY(), 2));
                if (t < a)
                {
                    a = t;
                    tmpPoint = points[i];
                }
            }

            calcPoints.Add(tmpPoint);
            points.Remove(tmpPoint);

            tmpPoint = null;

            // Punkt 2
            Punkt y_min = new Punkt(100000.0, 10000.0);
            tmpPoint = new Punkt(100000.0, 100000.0);

            for (int i = 0; i < points.Count; i++)
            {
                if (y_min.getY() > points[i].getY())
                {
                    y_min = points[i];
                }
            }

            for (int i = 0; i < points.Count; i++)
            {
                if (points[i] != y_min)
                {
                    if (tmpPoint.getX() > points[i].getX())
                    {
                        tmpPoint = points[i];
                    }
                }
            }

            calcPoints.Add(tmpPoint);
            points.Remove(tmpPoint);

            tmpPoint = null;
            y_min = null;

            // Punkt 3
            y_min = new Punkt(100000.0, 10000.0);
            tmpPoint = new Punkt(0.0, 0.0);

            for (int i = 0; i < points.Count; i++)
            {
                if (y_min.getY() > points[i].getY())
                {
                    y_min = points[i];
                }
            }

            for (int i = 0; i < points.Count; i++)
            {
                if (points[i] != y_min)
                {
                    if (tmpPoint.getX() < points[i].getX())
                    {
                        tmpPoint = points[i];
                    }
                }
            }

            calcPoints.Add(tmpPoint);
            points.Remove(tmpPoint);

            tmpPoint = null;

            // Punkt 4
            calcPoints.Add(points[0]);

            // Gerade 1
            double m1 = 0.0;
            if ((calcPoints[0].getY() == calcPoints[2].getY()) || (calcPoints[0].getX() == calcPoints[2].getX())){
                m1 = 0.0;
            }
            else
            {
                m1 = (calcPoints[0].getY() - calcPoints[2].getY()) / (calcPoints[0].getX() - calcPoints[2].getX());
            }
            double b1 = calcPoints[0].getY() - calcPoints[0].getX() * m1;

            // Gerade 2
            double m2 = 0.0;
            if ((calcPoints[1].getY() == calcPoints[3].getY()) || (calcPoints[1].getX() == calcPoints[3].getX()))
            {
                m2 = 0.0;
            }
            else
            {
                m2 = (calcPoints[1].getY() - calcPoints[3].getY()) / (calcPoints[1].getX() - calcPoints[3].getX());
            }
            double b2 = calcPoints[1].getY() - calcPoints[1].getX() * m2;

            // Berechnung des Schnittpunktes
            double xs = m1 - m2;
            double bs = b2 - b1;
            double x = bs / xs;
            double y = x * m1 + b1;
            return new Punkt(x, y);
        }

        public static double calculateRange(List<Punkt> points)
        {
            double d1 = Math.Sqrt(Math.Pow(points[0].getX() - points[1].getX(), 2) +
                Math.Pow(points[0].getY() - points[1].getY(), 2));
            double d2 = Math.Sqrt(Math.Pow(points[1].getX() - points[2].getX(), 2) +
                Math.Pow(points[1].getY() - points[2].getY(), 2));
            double d3 = Math.Sqrt(Math.Pow(points[2].getX() - points[3].getX(), 2) +
                Math.Pow(points[2].getY() - points[3].getY(), 2));
            double d4 = Math.Sqrt(Math.Pow(points[3].getX() - points[0].getX(), 2) +
                Math.Pow(points[3].getY() - points[0].getY(), 2));

            return d1 + d2 + d3 + d4;
        }

        public static double calculateEukDistance(Punkt p1, Punkt p2)
        {
            return Math.Sqrt(Math.Pow(p1.getX() - p2.getX(), 2) + Math.Pow(p1.getY() - p2.getY(), 2));
        }
    }
}
