namespace Signal_one
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Charts = new System.Windows.Forms.TabControl();
            this.SourceSignalTab = new System.Windows.Forms.TabPage();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.OpenFile = new System.Windows.Forms.Button();
            this.GenerateTestSignal = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.openFileSignal = new System.Windows.Forms.OpenFileDialog();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SamplingFrequencySignal = new System.Windows.Forms.NumericUpDown();
            this.SignalDuration = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Charts.SuspendLayout();
            this.SourceSignalTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SamplingFrequencySignal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SignalDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // Charts
            // 
            this.Charts.Controls.Add(this.SourceSignalTab);
            this.Charts.Controls.Add(this.tabPage2);
            this.Charts.Location = new System.Drawing.Point(12, 85);
            this.Charts.Name = "Charts";
            this.Charts.SelectedIndex = 0;
            this.Charts.Size = new System.Drawing.Size(911, 403);
            this.Charts.TabIndex = 1;
            // 
            // SourceSignalTab
            // 
            this.SourceSignalTab.Controls.Add(this.chart1);
            this.SourceSignalTab.Location = new System.Drawing.Point(4, 22);
            this.SourceSignalTab.Name = "SourceSignalTab";
            this.SourceSignalTab.Padding = new System.Windows.Forms.Padding(3);
            this.SourceSignalTab.Size = new System.Drawing.Size(903, 377);
            this.SourceSignalTab.TabIndex = 0;
            this.SourceSignalTab.Text = "Исходный сигнал";
            this.SourceSignalTab.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart1.Legends.Add(legend4);
            this.chart1.Location = new System.Drawing.Point(6, 3);
            this.chart1.Name = "chart1";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(829, 355);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(903, 377);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // OpenFile
            // 
            this.OpenFile.Location = new System.Drawing.Point(12, 12);
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(116, 67);
            this.OpenFile.TabIndex = 2;
            this.OpenFile.Text = "Открыть файл";
            this.OpenFile.UseVisualStyleBackColor = true;
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // GenerateTestSignal
            // 
            this.GenerateTestSignal.Location = new System.Drawing.Point(134, 12);
            this.GenerateTestSignal.Name = "GenerateTestSignal";
            this.GenerateTestSignal.Size = new System.Drawing.Size(142, 67);
            this.GenerateTestSignal.TabIndex = 3;
            this.GenerateTestSignal.Text = "Генерация тестовых сигналов  сигнала";
            this.GenerateTestSignal.UseVisualStyleBackColor = true;
            this.GenerateTestSignal.Click += new System.EventHandler(this.GenerateTestSignal_Click);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(657, 10);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(147, 67);
            this.Start.TabIndex = 4;
            this.Start.Text = "button3";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // openFileSignal
            // 
            this.openFileSignal.FileName = "*.txt";
            this.openFileSignal.InitialDirectory = "c:\\Users\\1\\Downloads\\STsOS\\8PI61COS\\";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(530, 36);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(590, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // SamplingFrequencySignal
            // 
            this.SamplingFrequencySignal.Location = new System.Drawing.Point(291, 25);
            this.SamplingFrequencySignal.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.SamplingFrequencySignal.Name = "SamplingFrequencySignal";
            this.SamplingFrequencySignal.Size = new System.Drawing.Size(152, 20);
            this.SamplingFrequencySignal.TabIndex = 7;
            // 
            // SignalDuration
            // 
            this.SignalDuration.Location = new System.Drawing.Point(291, 64);
            this.SignalDuration.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.SignalDuration.Name = "SignalDuration";
            this.SignalDuration.Size = new System.Drawing.Size(152, 20);
            this.SignalDuration.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Частота сигнала";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(288, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Продолжительность сигнала";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 535);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SignalDuration);
            this.Controls.Add(this.SamplingFrequencySignal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.GenerateTestSignal);
            this.Controls.Add(this.OpenFile);
            this.Controls.Add(this.Charts);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Charts.ResumeLayout(false);
            this.SourceSignalTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SamplingFrequencySignal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SignalDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl Charts;
        private System.Windows.Forms.TabPage SourceSignalTab;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button OpenFile;
        private System.Windows.Forms.Button GenerateTestSignal;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.OpenFileDialog openFileSignal;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown SamplingFrequencySignal;
        private System.Windows.Forms.NumericUpDown SignalDuration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

