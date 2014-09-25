namespace Robotik_Objekterkennung
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.btDetector = new System.Windows.Forms.Button();
            this.btCenter = new System.Windows.Forms.Button();
            this.btSync = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.btView = new System.Windows.Forms.Button();
            this.scatterPlot = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tbInifile = new System.Windows.Forms.TextBox();
            this.btInifile = new System.Windows.Forms.Button();
            this.btInitialize = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.scatterPlotTrans = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.btConvert = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.scatterPlot)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scatterPlotTrans)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btDetector
            // 
            this.btDetector.Enabled = false;
            this.btDetector.Location = new System.Drawing.Point(1050, 12);
            this.btDetector.Name = "btDetector";
            this.btDetector.Size = new System.Drawing.Size(108, 23);
            this.btDetector.TabIndex = 0;
            this.btDetector.Text = "Objekterkennung";
            this.btDetector.UseVisualStyleBackColor = true;
            this.btDetector.Click += new System.EventHandler(this.btDetector_Click);
            // 
            // btCenter
            // 
            this.btCenter.Enabled = false;
            this.btCenter.Location = new System.Drawing.Point(1049, 102);
            this.btCenter.Name = "btCenter";
            this.btCenter.Size = new System.Drawing.Size(108, 23);
            this.btCenter.TabIndex = 1;
            this.btCenter.Text = "Mittelpunkt";
            this.btCenter.UseVisualStyleBackColor = true;
            this.btCenter.Click += new System.EventHandler(this.btCenter_Click);
            // 
            // btSync
            // 
            this.btSync.Enabled = false;
            this.btSync.Location = new System.Drawing.Point(1050, 512);
            this.btSync.Name = "btSync";
            this.btSync.Size = new System.Drawing.Size(108, 23);
            this.btSync.TabIndex = 2;
            this.btSync.Text = "Sync.";
            this.btSync.UseVisualStyleBackColor = true;
            this.btSync.Click += new System.EventHandler(this.btSync_Click);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(1050, 600);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(108, 23);
            this.btClose.TabIndex = 4;
            this.btClose.Text = "Schließen";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btView
            // 
            this.btView.Enabled = false;
            this.btView.Location = new System.Drawing.Point(1050, 56);
            this.btView.Name = "btView";
            this.btView.Size = new System.Drawing.Size(107, 23);
            this.btView.TabIndex = 5;
            this.btView.Text = "View";
            this.btView.UseVisualStyleBackColor = true;
            this.btView.Click += new System.EventHandler(this.btView_Click);
            // 
            // scatterPlot
            // 
            chartArea1.Name = "ChartArea1";
            this.scatterPlot.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.scatterPlot.Legends.Add(legend1);
            this.scatterPlot.Location = new System.Drawing.Point(6, 6);
            this.scatterPlot.Name = "scatterPlot";
            this.scatterPlot.Size = new System.Drawing.Size(1011, 543);
            this.scatterPlot.TabIndex = 6;
            this.scatterPlot.Text = "scatter";
            this.scatterPlot.MouseMove += new System.Windows.Forms.MouseEventHandler(this.scatterPlot_MouseMove);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(1050, 570);
            this.progressBar.MarqueeAnimationSpeed = 0;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(108, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 7;
            this.progressBar.Visible = false;
            // 
            // tbInifile
            // 
            this.tbInifile.Location = new System.Drawing.Point(13, 603);
            this.tbInifile.Name = "tbInifile";
            this.tbInifile.Size = new System.Drawing.Size(909, 20);
            this.tbInifile.TabIndex = 8;
            // 
            // btInifile
            // 
            this.btInifile.Location = new System.Drawing.Point(929, 600);
            this.btInifile.Name = "btInifile";
            this.btInifile.Size = new System.Drawing.Size(115, 23);
            this.btInifile.TabIndex = 9;
            this.btInifile.Text = "Ini-Datei";
            this.btInifile.UseVisualStyleBackColor = true;
            this.btInifile.Click += new System.EventHandler(this.btInifile_Click);
            // 
            // btInitialize
            // 
            this.btInitialize.Location = new System.Drawing.Point(1050, 541);
            this.btInitialize.Name = "btInitialize";
            this.btInitialize.Size = new System.Drawing.Size(107, 23);
            this.btInitialize.TabIndex = 10;
            this.btInitialize.Text = "Initialisiere";
            this.btInitialize.UseVisualStyleBackColor = true;
            this.btInitialize.Click += new System.EventHandler(this.btInitialize_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(13, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1031, 581);
            this.tabControl.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.scatterPlot);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1023, 555);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Mittelpunkt";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.scatterPlotTrans);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1023, 555);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "transformierte Koordinaten";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // scatterPlotTrans
            // 
            chartArea2.Name = "ChartArea1";
            this.scatterPlotTrans.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.scatterPlotTrans.Legends.Add(legend2);
            this.scatterPlotTrans.Location = new System.Drawing.Point(3, 3);
            this.scatterPlotTrans.Name = "scatterPlotTrans";
            this.scatterPlotTrans.Size = new System.Drawing.Size(1017, 549);
            this.scatterPlotTrans.TabIndex = 0;
            this.scatterPlotTrans.Text = "Transformierte Koordinaten";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.picBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1023, 555);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Erkannte Ecken - Grafik";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // picBox
            // 
            this.picBox.Location = new System.Drawing.Point(7, 7);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(1010, 542);
            this.picBox.TabIndex = 0;
            this.picBox.TabStop = false;
            // 
            // btConvert
            // 
            this.btConvert.Enabled = false;
            this.btConvert.Location = new System.Drawing.Point(1050, 147);
            this.btConvert.Name = "btConvert";
            this.btConvert.Size = new System.Drawing.Size(107, 23);
            this.btConvert.TabIndex = 12;
            this.btConvert.Text = "Konvertiere";
            this.btConvert.UseVisualStyleBackColor = true;
            this.btConvert.Click += new System.EventHandler(this.btConvert_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 635);
            this.Controls.Add(this.btConvert);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btInitialize);
            this.Controls.Add(this.btInifile);
            this.Controls.Add(this.tbInifile);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btView);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btSync);
            this.Controls.Add(this.btCenter);
            this.Controls.Add(this.btDetector);
            this.Name = "Form1";
            this.Text = "Robotik - Objekterkennung";
            ((System.ComponentModel.ISupportInitialize)(this.scatterPlot)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scatterPlotTrans)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btDetector;
        private System.Windows.Forms.Button btCenter;
        private System.Windows.Forms.Button btSync;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btView;
        private System.Windows.Forms.DataVisualization.Charting.Chart scatterPlot;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox tbInifile;
        private System.Windows.Forms.Button btInifile;
        private System.Windows.Forms.Button btInitialize;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Button btConvert;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataVisualization.Charting.Chart scatterPlotTrans;
    }
}

