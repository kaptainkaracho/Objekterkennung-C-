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

        private string inifile;
        private string python;

        private int port;
        private string ipadress;

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
                        }
                    }
                }
            }
            catch (Exception e)
            {

            }
        }
        // Python Skript für die Mittelpunktberechnung aufrufen
        private void btCenter_Click(object sender, EventArgs e)
        {
            progressBar.Visible = true;
            progressBar.MarqueeAnimationSpeed = 150;
            // Python Prozess anlegen
            ProcessStartInfo startInfo = new ProcessStartInfo(pythonApp);
            //startInfo.WindowStyle = ProcessWindowStyle.Minimized;

            startInfo.Arguments = input_corners;
            startInfo.UseShellExecute = false;
            int processID = Process.Start(startInfo).Id;

            // Wartet auf den Prozess
            while (ProcessExists(processID))
            {
                Thread.Sleep(100);
            }

            // lese Ergebnis ein
            List<double[]> dataCenters = new List<double[]>();
            String line;
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

            scatterPlot.Series.Clear(); // leert alle alten Reihen

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

            // schaltet das Synchronisieren frei
            btSync.Enabled = true;

            progressBar.MarqueeAnimationSpeed = 0;
            progressBar.Visible = false;
        }
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
    }
}
