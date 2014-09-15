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

        private string inifile = "D:\\Objekterkennung\\Objekterkennung.ini";
        private string python;


        public Form1()
        {
            InitializeComponent();
            readIniFile();
        }
        // Fenster schließen
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // zeigt das Bild der Objekterkennung an
        private void btView_Click(object sender, EventArgs e)
        {

        }
        // führt die Objekterkennung aus - C++ Applikation wird gestartet
        private void btDetector_Click(object sender, EventArgs e)
        {

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
                        if ((line[0] != '#') && (line[0] != ' ')){
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
                        } 
                    }
                }
            } catch (Exception e){

            }
        }
        // Python Skript für die Mittelpunktberechnung aufrufen
        private void btCenter_Click(object sender, EventArgs e)
        {
            // Python Prozess anlegen
            ProcessStartInfo startInfo = new ProcessStartInfo(python);
            //startInfo.WindowStyle = ProcessWindowStyle.Minimized;

            startInfo.Arguments = pythonApp + " " + input_corners;
            Process.Start(startInfo);
             
            // Wartet auf den Prozess
            while (Process.GetProcessesByName("pythonw").Length != 0)
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
             
        }
    }
}
