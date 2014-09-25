using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Robotik_Objekterkennung
{
    public partial class Form1 : Form
    {
        // Ini-Datei
        private string detectorApp;
        private string pythonApp;
        private string input_corners;
        private string output_corners;
        private string pictureoutput;
        private string transOutput;

        private string inifile;
        private string python;

        private int port;
        private string ipadress;

        private double maxAreaCentering;
        private double maxAreaConverting;
        private double minAreaCentering;
        private double minAreaConverting;
        private double rangeCentering;
        private double rangeConverting;

        private int groupSize;
        private double radius;
        private double height;

        private List<Punkt> convertPoints = new List<Punkt>();
        private List<Punkt> synPoints;
        private Punkt referencePoint1 = null;
        private Punkt referencePoint2 = null;

        public Form1()
        {
            InitializeComponent();
            tbInifile.Text = "D:\\Objekterkennung\\Objekterkennung.ini";
        }

        // Fenster schließen
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // zeigt das Bild der Objekterkennung an
        private void btView_Click(object sender, EventArgs e)
        {
            picBox.Image = null;
            picBox.Load(pictureoutput);
        }

        // führt die Objekterkennung aus - C++ Applikation wird gestartet
        private void btDetector_Click(object sender, EventArgs e)
        {
            progressBar.MarqueeAnimationSpeed = 150;
            // Detector Prozess anlegen
            ProcessStartInfo startInfo = new ProcessStartInfo(detectorApp);
            //startInfo.WindowStyle = ProcessWindowStyle.Minimized;

            startInfo.Arguments = inifile;
            int processID = Process.Start(startInfo).Id;

            // Wartet auf den Prozess
            while (ProcessExists(processID))
            {
                Thread.Sleep(100);
            }

            // wenn Ecken erkannt wurden, wird der View-Button aktiviert
            btView.Enabled = true;

            progressBar.MarqueeAnimationSpeed = 0; 
        }

        // importieren der Initialisierungsdefinitionen
        private void readIniFile()
        {
            double ref1X = 0 , ref1Y = 0 , ref2X = 0, ref2Y = 0;
            try
            {
                string line;
                using (StreamReader sr = new StreamReader(inifile))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        if ((line[0] != '#') && (line[0] != ' '))
                        {
                            string[] split = line.Split('=');
                            if (split[0] == "OBJEKTERKENNUNGAPP")
                            {
                                detectorApp = split[1];
                            }
                            else if (split[0] == "PYTHONAPP")
                            {
                                pythonApp = split[1];
                            }
                            else if (split[0] == "INPUT_CORNERS")
                            {
                                input_corners = split[1];
                            }
                            else if (split[0] == "OUTPUT_CORNERS")
                            {
                                output_corners = split[1];
                            }
                            else if (split[0] == "PICTUREOUTPUT")
                            {
                                pictureoutput = split[1];
                            }
                            else if (split[0] == "PYTHON")
                            {
                                python = split[1];
                            }
                            else if (split[0] == "PORT")
                            {
                                port = Convert.ToInt16(split[1]);
                            }
                            else if (split[0] == "IPADRESS")
                            {
                                ipadress = split[1];
                            }
                            else if (split[0] == "Max_Area_Center")
                            {
                                maxAreaCentering = Convert.ToDouble(split[1]);
                            }
                            else if (split[0] == "Min_Area_Center")
                            {
                                minAreaCentering = Convert.ToDouble(split[1]);
                            }
                            else if (split[0] == "Max_Area_Convert")
                            {
                                maxAreaConverting = Convert.ToDouble(split[1]);
                            }
                            else if (split[0] == "Min_Area_Convert")
                            {
                                minAreaConverting = Convert.ToDouble(split[1]);
                            }
                            else if (split[0] == "Range_Center")
                            {
                                rangeCentering = Convert.ToDouble(split[1]);
                            }
                            else if (split[0] == "Range_Convert")
                            {
                                rangeConverting = Convert.ToDouble(split[1]);
                            }
                            else if (split[0] == "GROUPSIZE")
                            {
                                groupSize = Convert.ToInt16(split[1]);
                            }
                            else if (split[0] == "HEIGHT")
                            {
                                height = Convert.ToDouble(split[1]);
                            }
                            else if (split[0] == "RADIUS")
                            {
                                radius = Convert.ToDouble(split[1]);
                            }
                            else if (split[0] == "REFERENZ_1_X")
                            {
                                ref1X = Convert.ToDouble(split[1]);
                            }
                            else if (split[0] == "REFERENZ_1_Y")
                            {
                                ref1Y = Convert.ToDouble(split[1]);
                            }
                            else if (split[0] == "REFERENZ_2_X")
                            {
                                ref2X = Convert.ToDouble(split[1]);
                            }
                            else if (split[0] == "REFERENZ_2_Y")
                            {
                                ref2Y = Convert.ToDouble(split[1]);
                            }
                            else if (split[0] == "TRANS_CENTERS")
                            {
                                transOutput = split[1];
                            }
                        }
                    }
                }
                referencePoint1 = new Punkt(ref1X, ref1Y);
                referencePoint2 = new Punkt(ref2X, ref2Y);
            }
            catch (Exception e)
            {

            }
        }

        // Mittelpunktberechnung aufrufen
        private void btCenter_Click(object sender, EventArgs e)
        {
            // Parallelisiertes Rechnen 
            Parallelisierung parallelisierung = new Parallelisierung(maxAreaCentering,
                minAreaCentering, rangeCentering, maxAreaConverting, minAreaConverting,
                rangeConverting, radius, groupSize);

            List<Punkt> corners = new List<Punkt>();
            string line;
            try
            { 
                using (StreamReader sr = new StreamReader(input_corners))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        line = line.Replace('.', ',');
                        String[] split = line.Split(';');
                        Punkt point = new Punkt(Convert.ToDouble(split[0]), Convert.ToDouble(split[1]));
                        corners.Add(point);
                    }
                }
            } catch (Exception ex){}

            // Gruppen bilden
            parallelisierung.setCorners(corners);
            parallelisierung.createGroups();

            // Berechnung der Mittelpunkte
            parallelisierung.calculateCenters(3);

            // speichern der Mittelpunkte
            parallelisierung.exportCenters(output_corners);

            // lese Ergebnis ein
            List<double[]> dataCenters = new List<double[]>();
            using (StreamReader sr = new StreamReader(output_corners))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    line = line.Replace('.', ',');
                    String[] split = line.Split(';');
                    double[] tmp = new double[2];
                    tmp[0] = Convert.ToDouble(split[0]);
                    tmp[1] = Convert.ToDouble(split[1]);
                    dataCenters.Add(tmp);
                }

            }

            // lese Referenz ein (Eckdaten)
            List<double[]> dataCorners = new List<double[]>();
            using (StreamReader sr = new StreamReader(input_corners))
            {

                while ((line = sr.ReadLine()) != null)
                {
                    line = line.Replace('.', ',');
                    String[] split = line.Split(';');
                    double[] tmp = new double[2];
                    tmp[0] = Convert.ToDouble(split[0]);
                    tmp[1] = Convert.ToDouble(split[1]);
                    dataCorners.Add(tmp);
                }

            }

            // Erstellen des Scatter Plots
            // Ecken
            Series series1 = new Series();
            series1.Name = "Corner Points";
            series1.ChartType = SeriesChartType.Point;
            // Mittelpunkte
            Series series2 = new Series();
            series2.Name = "Center Points";
            series2.ChartType = SeriesChartType.Point;
            // Mittelpunkte - Konvertierung
            Series series3 = new Series();
            series3.Name = "Center Big Cubes";
            series3.ChartType = SeriesChartType.Point;

            scatterPlot.Series.Clear(); // leert alle alten Reihen

            // Series 1 & 2
            for (int i = 0; i < dataCorners.Count(); i++)
            {
                series1.Points.AddXY(dataCorners[i][0], dataCorners[i][1]);
            }

            for (int i = 0; i < dataCenters.Count(); i++)
            {
                series2.Points.AddXY(dataCenters[i][0], dataCenters[i][1]);
            }

            scatterPlot.Series.Add(series1);
            scatterPlot.Series.Add(series2);

            // Series 3
            List<Punkt> data = parallelisierung.getCentersConvert();
            for (int i = 0; i < data.Count; i++)
            {
                series3.Points.AddXY(data[i].getX(), data[i].getY());
                convertPoints.Add(data[i]);
            }
            scatterPlot.Series.Add(series3);

            // schaltet das Synchronisieren frei
            btConvert.Enabled = true;

            progressBar.MarqueeAnimationSpeed = 0;
            progressBar.Visible = false;
        }

        // Gibt es den Prozess (anhand PID)?
        private bool ProcessExists(int id)
        {
            return Process.GetProcesses().Any(x => x.Id == id);
        }

        private void btInitialize_Click(object sender, EventArgs e)
        {
            // Überprüfe, ob eine Datei angegeben wurde
            if (tbInifile.Text != "")
            {
                progressBar.MarqueeAnimationSpeed = 150;
                inifile = tbInifile.Text;
                readIniFile();
                progressBar.MarqueeAnimationSpeed = 0;
                // Button aktivieren
                btDetector.Enabled = true;
                btCenter.Enabled = true;
            }
        }

        // OpenFileDialog um den Dateipfad zur Initialisierungsdatei zu finden
        private void btInifile_Click(object sender, EventArgs e)
        {
            progressBar.MarqueeAnimationSpeed = 150;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "D:\\";
            openFileDialog.Filter = "ini files (*.ini)|*.ini|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbInifile.Text = openFileDialog.FileName;
            }
            progressBar.MarqueeAnimationSpeed = 0;
        }

        private Point? prevPosition = null;
        private ToolTip tooltip = new ToolTip();

        private void scatterPlot_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = scatterPlot.HitTest(pos.X, pos.Y, false,
                                            ChartElementType.DataPoint);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    var prop = result.Object as DataPoint;
                    if (prop != null)
                    {
                        var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                        var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

                        // check if the cursor is really close to the point (2 pixels around the point)
                        if (Math.Abs(pos.X - pointXPixel) < 2 &&
                            Math.Abs(pos.Y - pointYPixel) < 2)
                        {
                            tooltip.Show("X=" + prop.XValue + ", Y=" + prop.YValues[0], this.scatterPlot,
                                            pos.X, pos.Y - 15);
                        }
                    }
                }
            }
        }

        private void btConvert_Click(object sender, EventArgs e)
        {
            if (convertPoints.Count == 2)
            {
                // Punkt 1
                Punkt p1 = convertPoints[0];
                // Punkt 2
                Punkt p2 = convertPoints[1];

                // euklidische Länge - Big Cubes Detektorkoordinaten
                double d1 = Funktionen.calculateEukDistance(p1, p2);
                // euklidische Länge - Referenzkoordinaten
                double d2 = Funktionen.calculateEukDistance(referencePoint1, referencePoint2);

                // Verhältnis zur Umrechnung der Koordinaten
                double relation = d1 / d2;

                // Mittelpunkte laden
                List<Punkt> dataCenters = new List<Punkt>();
                String line;
                using (StreamReader sr = new StreamReader(output_corners))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        line = line.Replace('.', ',');
                        String[] split = line.Split(';');
                        Punkt point = new Punkt(Convert.ToDouble(split[0]),
                            Convert.ToDouble(split[1])); 
                        dataCenters.Add(point);
                    }

                }

                // Umrechnung auf Millimeter
                List<Punkt> centerMilli = new List<Punkt>();
                for (int i = 0; i < dataCenters.Count; i++)
                {
                    Punkt point = new Punkt(dataCenters[i].getX() / relation,
                        dataCenters[i].getY() / relation);
                    centerMilli.Add(point);
                }
                dataCenters.Clear();
                dataCenters = null;

                Punkt p1Milli = new Punkt(p1.getX() / relation,
                    p1.getY() / relation);
                Punkt p2Milli = new Punkt(p2.getX() / relation,
                    p2.getY() / relation);

                // An Roboterkoordinaten anpassen
                List<Punkt> rPoints = Funktionen.transformCoordinates2P(p1Milli,
                    p2Milli, referencePoint1, referencePoint2, centerMilli);

                // speichern der transformierten Punkten
                using (StreamWriter sw = new StreamWriter(transOutput))
                {
                    for (int i = 0; i < rPoints.Count; i++)
                    {
                        line = Convert.ToString(rPoints[i].getX()) + ";"
                            + Convert.ToString(rPoints[i].getY());
                        sw.WriteLine(line);
                        line = "";
                    }
                    sw.Close();
                }

                // ins Klassenattribute verschieben
                this.synPoints = rPoints;

                Series series1 = new Series();
                series1.Name = "Transformierte Mittelpunkte";
                series1.ChartType = SeriesChartType.Point;

                Series series2 = new Series();
                series2.Name = "Referenzpunkte";
                series2.ChartType = SeriesChartType.Point;

                for (int i = 0; i < rPoints.Count; i++)
                {
                    series1.Points.AddXY(rPoints[i].getX(), rPoints[i].getY());
                }

                series2.Points.AddXY(referencePoint1.getX(), referencePoint1.getY());
                series2.Points.AddXY(referencePoint2.getX(), referencePoint2.getY());

                scatterPlotTrans.Series.Clear();
                scatterPlotTrans.Series.Add(series1);
                scatterPlotTrans.Series.Add(series2);

                MessageBox.Show("Punkte wurden transformiert.");

                // Synchronisation (Datenaustausch) freischalten
                btSync.Enabled = true;
            }
            else
            {
                MessageBox.Show("Zu wenig oder zu viele Referenzpunkte: Bitte führen Sie die Mittelpunkts" +
                    "berechnung erneut mit anderen Größe aus");
            }            
        }
    }
}
