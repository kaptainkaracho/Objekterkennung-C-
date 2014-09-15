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
            this.btDetector = new System.Windows.Forms.Button();
            this.btCenter = new System.Windows.Forms.Button();
            this.btSync = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.btView = new System.Windows.Forms.Button();
            this.scatterPlot = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.scatterPlot)).BeginInit();
            this.SuspendLayout();
            // 
            // btDetector
            // 
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
            this.btCenter.Location = new System.Drawing.Point(1050, 105);
            this.btCenter.Name = "btCenter";
            this.btCenter.Size = new System.Drawing.Size(108, 23);
            this.btCenter.TabIndex = 1;
            this.btCenter.Text = "Mittelpunkt";
            this.btCenter.UseVisualStyleBackColor = true;
            this.btCenter.Click += new System.EventHandler(this.btCenter_Click);
            // 
            // btSync
            // 
            this.btSync.Location = new System.Drawing.Point(1050, 150);
            this.btSync.Name = "btSync";
            this.btSync.Size = new System.Drawing.Size(108, 23);
            this.btSync.TabIndex = 2;
            this.btSync.Text = "Sync.";
            this.btSync.UseVisualStyleBackColor = true;
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(1050, 570);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(108, 23);
            this.btClose.TabIndex = 4;
            this.btClose.Text = "Schließen";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btView
            // 
            this.btView.Location = new System.Drawing.Point(1051, 59);
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
            this.scatterPlot.Location = new System.Drawing.Point(12, 12);
            this.scatterPlot.Name = "scatterPlot";
            this.scatterPlot.Size = new System.Drawing.Size(1033, 581);
            this.scatterPlot.TabIndex = 6;
            this.scatterPlot.Text = "scatter";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 605);
            this.Controls.Add(this.scatterPlot);
            this.Controls.Add(this.btView);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btSync);
            this.Controls.Add(this.btCenter);
            this.Controls.Add(this.btDetector);
            this.Name = "Form1";
            this.Text = "Robotik - Objekterkennung";
            ((System.ComponentModel.ISupportInitialize)(this.scatterPlot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btDetector;
        private System.Windows.Forms.Button btCenter;
        private System.Windows.Forms.Button btSync;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btView;
        private System.Windows.Forms.DataVisualization.Charting.Chart scatterPlot;
    }
}

