
namespace GameOfLifeGui
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.chromosomeNum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnColor = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownMutation = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCroosover = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownKeepBestRation = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMaxIterations = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.upperPnl = new System.Windows.Forms.Panel();
            this.btnAddFromFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownNewGenerationration = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chromosomeNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMutation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCroosover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKeepBestRation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxIterations)).BeginInit();
            this.upperPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNewGenerationration)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 263);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1805, 890);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1042, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 58);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add To Chart";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chromosomeNum
            // 
            this.chromosomeNum.Location = new System.Drawing.Point(230, 9);
            this.chromosomeNum.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.chromosomeNum.Name = "chromosomeNum";
            this.chromosomeNum.Size = new System.Drawing.Size(120, 29);
            this.chromosomeNum.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "chromosome Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Color";
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnColor.Location = new System.Drawing.Point(98, 60);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(82, 44);
            this.btnColor.TabIndex = 5;
            this.btnColor.Text = "Color";
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(149, 126);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(134, 29);
            this.tbName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Name";
            // 
            // numericUpDownMutation
            // 
            this.numericUpDownMutation.DecimalPlaces = 2;
            this.numericUpDownMutation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownMutation.Location = new System.Drawing.Point(761, 13);
            this.numericUpDownMutation.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMutation.Name = "numericUpDownMutation";
            this.numericUpDownMutation.Size = new System.Drawing.Size(111, 29);
            this.numericUpDownMutation.TabIndex = 8;
            this.numericUpDownMutation.Value = new decimal(new int[] {
            4,
            0,
            0,
            65536});
            // 
            // numericUpDownCroosover
            // 
            this.numericUpDownCroosover.DecimalPlaces = 2;
            this.numericUpDownCroosover.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownCroosover.Location = new System.Drawing.Point(761, 68);
            this.numericUpDownCroosover.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCroosover.Name = "numericUpDownCroosover";
            this.numericUpDownCroosover.Size = new System.Drawing.Size(111, 29);
            this.numericUpDownCroosover.TabIndex = 9;
            this.numericUpDownCroosover.Value = new decimal(new int[] {
            7,
            0,
            0,
            65536});
            // 
            // numericUpDownKeepBestRation
            // 
            this.numericUpDownKeepBestRation.DecimalPlaces = 2;
            this.numericUpDownKeepBestRation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownKeepBestRation.Location = new System.Drawing.Point(761, 130);
            this.numericUpDownKeepBestRation.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownKeepBestRation.Name = "numericUpDownKeepBestRation";
            this.numericUpDownKeepBestRation.Size = new System.Drawing.Size(111, 29);
            this.numericUpDownKeepBestRation.TabIndex = 10;
            this.numericUpDownKeepBestRation.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // numericUpDownMaxIterations
            // 
            this.numericUpDownMaxIterations.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownMaxIterations.Location = new System.Drawing.Point(761, 195);
            this.numericUpDownMaxIterations.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownMaxIterations.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownMaxIterations.Name = "numericUpDownMaxIterations";
            this.numericUpDownMaxIterations.Size = new System.Drawing.Size(111, 29);
            this.numericUpDownMaxIterations.TabIndex = 11;
            this.numericUpDownMaxIterations.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(570, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "mutation Prob";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(570, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "Crossover Prob";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(570, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 25);
            this.label6.TabIndex = 14;
            this.label6.Text = "Keep Best Ration";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(570, 199);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 25);
            this.label7.TabIndex = 15;
            this.label7.Text = "Max Iterations";
            // 
            // upperPnl
            // 
            this.upperPnl.Controls.Add(this.label8);
            this.upperPnl.Controls.Add(this.numericUpDownNewGenerationration);
            this.upperPnl.Controls.Add(this.btnAddFromFile);
            this.upperPnl.Controls.Add(this.label7);
            this.upperPnl.Controls.Add(this.label6);
            this.upperPnl.Controls.Add(this.label5);
            this.upperPnl.Controls.Add(this.label4);
            this.upperPnl.Controls.Add(this.numericUpDownMaxIterations);
            this.upperPnl.Controls.Add(this.numericUpDownKeepBestRation);
            this.upperPnl.Controls.Add(this.numericUpDownCroosover);
            this.upperPnl.Controls.Add(this.numericUpDownMutation);
            this.upperPnl.Controls.Add(this.label3);
            this.upperPnl.Controls.Add(this.tbName);
            this.upperPnl.Controls.Add(this.btnColor);
            this.upperPnl.Controls.Add(this.label2);
            this.upperPnl.Controls.Add(this.label1);
            this.upperPnl.Controls.Add(this.chromosomeNum);
            this.upperPnl.Controls.Add(this.button1);
            this.upperPnl.Location = new System.Drawing.Point(24, 17);
            this.upperPnl.Name = "upperPnl";
            this.upperPnl.Size = new System.Drawing.Size(1242, 233);
            this.upperPnl.TabIndex = 16;
            // 
            // btnAddFromFile
            // 
            this.btnAddFromFile.Location = new System.Drawing.Point(1042, 107);
            this.btnAddFromFile.Name = "btnAddFromFile";
            this.btnAddFromFile.Size = new System.Drawing.Size(146, 61);
            this.btnAddFromFile.TabIndex = 17;
            this.btnAddFromFile.Text = "Add from file";
            this.btnAddFromFile.UseVisualStyleBackColor = true;
            this.btnAddFromFile.Click += new System.EventHandler(this.btnAddFromFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(198, 25);
            this.label8.TabIndex = 19;
            this.label8.Text = "Ne Generation Ration";
            // 
            // numericUpDownNewGenerationration
            // 
            this.numericUpDownNewGenerationration.DecimalPlaces = 2;
            this.numericUpDownNewGenerationration.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownNewGenerationration.Location = new System.Drawing.Point(230, 177);
            this.numericUpDownNewGenerationration.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNewGenerationration.Name = "numericUpDownNewGenerationration";
            this.numericUpDownNewGenerationration.Size = new System.Drawing.Size(111, 29);
            this.numericUpDownNewGenerationration.TabIndex = 18;
            this.numericUpDownNewGenerationration.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1869, 1197);
            this.Controls.Add(this.upperPnl);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chromosomeNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMutation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCroosover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKeepBestRation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxIterations)).EndInit();
            this.upperPnl.ResumeLayout(false);
            this.upperPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNewGenerationration)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown chromosomeNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownMutation;
        private System.Windows.Forms.NumericUpDown numericUpDownCroosover;
        private System.Windows.Forms.NumericUpDown numericUpDownKeepBestRation;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxIterations;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel upperPnl;
        private System.Windows.Forms.Button btnAddFromFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDownNewGenerationration;
    }
}

