using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Robotik_Objekterkennung
{
    class Parallelisierung
    {
        // Gruppierungen
        private List<List<Punkt>> group = new List<List<Punkt>>();

        // Ecken
        private List<Punkt> corners = null;

        // Mittelpunkte
        private List<Punkt> centersDices = new List<Punkt>();
        private List<Punkt> centerConvert = new List<Punkt>();

        // Threads
        private List<Thread> threads = new List<Thread>();

        // Konfiguration
        private double maxArea, minArea, range;
        private double maxAreaConvert, minAreaConvert, rangeConvert;
        private double radius;
        private int groupSize;

        private Boolean fin = false;

        public Parallelisierung(double maxArea, double minArea, double range, 
            double maxAreaConvert, double minAreaConvert, double rangeConvert,
            double radius, int groupSize)
        {
            this.maxArea = maxArea;
            this.minArea = minArea;
            this.range = range;
            this.radius = radius;
            this.groupSize = groupSize;
            this.maxAreaConvert = maxAreaConvert;
            this.minAreaConvert = minAreaConvert;
            this.rangeConvert = rangeConvert;
        }
        // Eckdaten laden
        public void setCorners(List<Punkt> corners)
        {
            this.corners = corners;
        }

        // iteratives Gruppieren
        public void createGroups()
        {
            int index = 0;
            while (groupCorners(corners, index) == true)
            {
                index++;
                if (corners.Count <= index)
                {
                    index = 0;
                }
                else if (corners.Count < 4)
                {
                    break;
                }
            }        
        }

        // Gruppieren der Ecken
        private Boolean groupCorners(List<Punkt> corners, int index)
        {
            List<Punkt> tmpList = new List<Punkt>();
            for (int j = 0; j < corners.Count; j++)
            {
                if (index != j)
                {
                    double x = corners[index].getX() - corners[j].getX();
                    double y = corners[index].getY() - corners[j].getY();
                    double distance = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

                    if (distance < radius)
                    {
                        tmpList.Add(corners[j]);                     
                    }

                    //if (tmpList.Count >= groupSize-1)
                    //{
                    //    tmpList.Add(corners[index]);
                    //    group.Add(tmpList);
                    //    for (int i = 0; i < tmpList.Count; i++)
                    //    {
                    //        corners.Remove(tmpList[i]);
                    //    }
                    //    return true;
                    //}
                }
            }
            if (tmpList.Count == 0)
            {
                return false;
            }
            else
            {
                tmpList.Add(corners[index]);
                group.Add(tmpList);
                for (int i = 0; i < tmpList.Count; i++)
                {
                    corners.Remove(tmpList[i]);
                }
                return true; 
            }
        }

        // Berechnung der Mittelpunkte
        public void calculateCenters(int countThreads){
            for (int i = 0; i < group.Count; i++)
            {
                Thread t = new Thread(new ParameterizedThreadStart(startCentering));
                t.Start(group[i]);
                threads.Add(t);
                while (threads.Count == countThreads)
                {
                    Thread.Sleep(100);
                    for (int j = 0; j < threads.Count; j++)
                    {
                        if (!threads[j].IsAlive)
                        {
                            threads.RemoveAt(j);
                        }
                    }
                }
            }
            while (threads.Count > 0)
            {
                Thread.Sleep(100);
                for (int j = 0; j < threads.Count; j++)
                {
                    if (!threads[j].IsAlive)
                    {
                        threads.RemoveAt(j);
                    }
                }
            }
            if (fin == false)
            {
                // Gruppen neu bilden
                reGroupCorners();
                if (group.Count == 1)
                {
                    fin = true;
                }
                calculateCenters(countThreads);
            }        
        }

        private void startCentering(object element)
        {
            List<Punkt> points = (List<Punkt>)element;
            calcCenters(points);  
        }

        private Boolean calcCenters(List<Punkt> points)
        {
            for (int i = 0; i < points.Count; i++)
            {
                for (int j = 0; j < points.Count; j++)
                {
                    for (int k = 0; k < points.Count; k++)
                    {
                        for (int l = 0; l < points.Count; l++)
                        {
                            if ((i != j) && (i != k) && (i != l) && (j != k)
                                && (j != l) && (k != l))
                            {
                                List<Punkt> tmpList = new List<Punkt>();
                                tmpList.Add(points[i]);
                                tmpList.Add(points[j]);
                                tmpList.Add(points[k]);
                                tmpList.Add(points[l]);
                                double r = Funktionen.calculateRange(tmpList);
                                double area = Funktionen.calcAreaPolygon(tmpList);
                                if ((area >= minArea) && (area <= maxArea) && (r <= range)){
                                    Punkt center = Funktionen.calcCenterCube(tmpList);
                                    lock (centersDices)
                                    {
                                        centersDices.Add(center);            
                                    }
                                    for (int z = 0; z < tmpList.Count; z++)
                                    {
                                        points.Remove(tmpList[z]);
                                    }
                                    tmpList.Clear();
                                    return true;
                                    
                                } else if ((area >= minAreaConvert) && (area <= maxAreaConvert)
                                    && (r <= rangeConvert))
                                {
                                    Punkt center = Funktionen.calcCenterCube(tmpList);
                                    lock (centerConvert)
                                    {
                                        centerConvert.Add(center);
                                    }
                                    for (int z = 0; z < tmpList.Count; z++)
                                    {
                                        points.Remove(tmpList[z]);
                                    }
                                    tmpList.Clear();
                                    return true;
                                }
                                tmpList.Clear();
                                tmpList = null;
                            }
                        }
                    }
                }
            }
            return false;
        }

        // Gruppen neu erstellen
        private void reGroupCorners()
        {
            for (int i = 0; i < group.Count; i++)
            {
                for (int j = 0; j < group[i].Count; j++)
                {
                    corners.Add(group[i][j]);       
                }
            }

            // Gruppen leeren
            group.Clear();
            // Radius erhöhen
            radius = radius + 50;
            // neu gruppieren lassen
            createGroups();
        }

        // exportieren der Mittelpunkte in eine CSV-Datei
        public void exportCenters(string filename)
        {
            using (StreamWriter sw = new StreamWriter(@filename))
            {
                for (int i = 0; i < centersDices.Count; i++)
                {
                    String x = Convert.ToString(centersDices[i].getX());
                    String y = Convert.ToString(centersDices[i].getY());

                    String line = x + ";" + y;
                    sw.WriteLine(line);
                }
                sw.Close();
            }
        }


        // gibt die Mittelpunkt zur Konvertierung wieder
        public List<Punkt> getCentersConvert()
        {
            return this.centerConvert;
        }
    }
}
