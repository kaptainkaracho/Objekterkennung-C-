using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
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

        // Berechnet die Distanz zwischen zwei Punkten
        public static double calculateEukDistance(Punkt p1, Punkt p2)
        {
            return Math.Sqrt(Math.Pow(p1.getX() - p2.getX(), 2) + Math.Pow(p1.getY() - p2.getY(), 2));
        }

        // Matrix 
        public static double[] calcVecABCD(Punkt oP1, Punkt oP2, Punkt rP1, Punkt rP2)
        {
            // Matrixattribute
            double x1 = oP1.getX(), y1 = oP1.getY(), x2 = oP2.getX(), y2 = oP2.getY();
            double rx1 = rP1.getX(), ry1 = rP1.getY(), rx2 = rP2.getX(), ry2 = rP2.getY();

            // Vektor u
            double[] u = new double[] { rx1, ry1, rx2, ry2 };

            double[] m1 = new double[] { x1, y1, 1, 0 };
            double[] m2 = new double[] {-1 * y1, x1, 0, 1};
            double[] m3 = new double[] { x2, y2, 1, 0 };
            double[] m4 = new double[] {-1* y2, x2, 0, 1};

            List<double[]> tmp = new List<double[]>();
            tmp.Add(m1);
            tmp.Add(m2);
            tmp.Add(m3);
            tmp.Add(m4);

            // Matrix M
            double[][] M = new double[4][];
            for (int i = 0; i < tmp.Count; i++){
                M[i] = new double[4];
                for (int j = 0; j < tmp[i].Length; j++){
                    M[i][j] = tmp[i][j];
                }
            }

            // inverse Matrix M
            double[][] M1 = inverse2DMatrix(M);

            // invM multipliziert mit u
            double[] v = multiplyMatrix1D(M1, u);

            // Zielvektor v
            return v;
        }

        public static double[][] inverse2DMatrix(double[][] A)
        {
            int n = A.Length;
            //e will represent each column in the identity matrix
            double[] e;
            //x will hold the inverse matrix to be returned
            double[][] x = new double[n][];
            for (int i = 0; i < n; i++)
            {
                x[i] = new double[A[i].Length];
            }
            /*
            * solve will contain the vector solution for the LUP decomposition as we solve
            * for each vector of x.  We will combine the solutions into the double[][] array x.
            * */
            double[] solve;

            //Get the LU matrix and P matrix (as an array)
            Tuple<double[][], int[]> results = LUPDecomposition(A);

            double[][] LU = results.Item1;
            int[] P = results.Item2;

            /*
            * Solve AX = e for each column ei of the identity matrix using LUP decomposition
            * */
            for (int i = 0; i < n; i++)
            {
                e = new double[A[i].Length];
                e[i] = 1;
                solve = LUPSolve(LU, P, e);
                for (int j = 0; j < solve.Length; j++)
                {
                    x[j][i] = solve[j];
                }
            }
            return x;   
        }

        public static double[] LUPSolve(double[][] LU, int[] pi, double[] b)
        {
            int n = LU.Length - 1;
            double[] x = new double[n + 1];
            double[] y = new double[n + 1];
            double suml = 0;
            double sumu = 0;
            double lij = 0;

            /*
            * Solve for y using formward substitution
            * */
            for (int i = 0; i <= n; i++)
            {
                suml = 0;
                for (int j = 0; j <= i - 1; j++)
                {
                    /*
                    * Since we've taken L and U as a singular matrix as an input
                    * the value for L at index i and j will be 1 when i equals j, not LU[i][j], since
                    * the diagonal values are all 1 for L.
                    * */
                    if (i == j)
                    {
                        lij = 1;
                    }
                    else
                    {
                        lij = LU[i][j];
                    }
                    suml = suml + (lij * y[j]);
                }
                y[i] = b[pi[i]] - suml;
            }
            //Solve for x by using back substitution
            for (int i = n; i >= 0; i--)
            {
                sumu = 0;
                for (int j = i + 1; j <= n; j++)
                {
                    sumu = sumu + (LU[i][j] * x[j]);
                }
                x[i] = (y[i] - sumu) / LU[i][i];
            }
            return x;
        }

        public static Tuple<double[][], int[]> LUPDecomposition(double[][] A)
        {
            int n = A.Length - 1;
            /*
            * pi represents the permutation matrix.  We implement it as an array
            * whose value indicates which column the 1 would appear.  We use it to avoid 
            * dividing by zero or small numbers.
            * */
            int[] pi = new int[n + 1];
            double p = 0;
            int kp = 0;
            int pik = 0;
            int pikp = 0;
            double aki = 0;
            double akpi = 0;

            //Initialize the permutation matrix, will be the identity matrix
            for (int j = 0; j <= n; j++)
            {
                pi[j] = j;
            }

            for (int k = 0; k <= n; k++)
            {
                /*
                * In finding the permutation matrix p that avoids dividing by zero
                * we take a slightly different approach.  For numerical stability
                * We find the element with the largest 
                * absolute value of those in the current first column (column k).  If all elements in
                * the current first column are zero then the matrix is singluar and throw an
                * error.
                * */
                p = 0;
                for (int i = k; i <= n; i++)
                {
                    if (Math.Abs(A[i][k]) > p)
                    {
                        p = Math.Abs(A[i][k]);
                        kp = i;
                    }
                }
                if (p == 0)
                {
                    throw new Exception("singular matrix");
                }
                /*
                * These lines update the pivot array (which represents the pivot matrix)
                * by exchanging pi[k] and pi[kp].
                * */
                pik = pi[k];
                pikp = pi[kp];
                pi[k] = pikp;
                pi[kp] = pik;

                /*
                * Exchange rows k and kpi as determined by the pivot
                * */
                for (int i = 0; i <= n; i++)
                {
                    aki = A[k][i];
                    akpi = A[kp][i];
                    A[k][i] = akpi;
                    A[kp][i] = aki;
                }

                /*
                    * Compute the Schur complement
                    * */
                for (int i = k + 1; i <= n; i++)
                {
                    A[i][k] = A[i][k] / A[k][k];
                    for (int j = k + 1; j <= n; j++)
                    {
                        A[i][j] = A[i][j] - (A[i][k] * A[k][j]);
                    }
                }
            }
            return Tuple.Create(A, pi);
        }

        // Matrixmultiplikation
        public static double[] multiplyMatrix1D(double[][] A, double[] b)
        {
            // Zielvektor
            double[] c = new double[b.Length];

            for (int i = 0; i < b.Length; i++)
            {
                c[i] = 0;
                for (int j = 0; j < A[i].Length; j++)
                {
                    c[i] = c[i] + A[i][j] * b[j];        
                }
            }

            return c;
        }

        // transformiert Koordinaten anhand von zwei Punkten - gibt List mit transformierten Punkten zurück
        public static List<Punkt> transformCoordinates2P(Punkt oP1, Punkt oP2, Punkt rP1, Punkt rP2, List<Punkt> oPoints)
        {
            // Vektor v (Elemente a, b, c und d)
            double[] v = calcVecABCD(oP1, oP2, rP1, rP2);
        
            // Transformationsgleichungen
            List<Punkt> rPoints = new List<Punkt>();
            for (int i = 0; i < oPoints.Count; i++)
            {
                double x = calculateXValue(v, oPoints[i]);
                double y = calculateYValue(v, oPoints[i]);
                rPoints.Add(new Punkt(x, y));
            }

            return rPoints;
        }

        private static double calculateXValue(double[] v, Punkt point)
        {
            return v[0] * point.getX() + v[1] * point.getY() + v[2];
        }

        private static double calculateYValue(double[] v, Punkt point)
        {
            return v[1] * point.getX() - v[0] * point.getY() + v[3];
        }
    }
}
