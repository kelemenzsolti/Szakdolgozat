
namespace ECGSegmentation
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
            this.PlotButton = new System.Windows.Forms.Button();
            this.UpDown = new System.Windows.Forms.NumericUpDown();
            this.LowPass = new System.Windows.Forms.Button();
            this.Reset = new System.Windows.Forms.Button();
            this.HighPass = new System.Windows.Forms.Button();
            this.Derivative = new System.Windows.Forms.Button();
            this.Squaring = new System.Windows.Forms.Button();
            this.Integration = new System.Windows.Forms.Button();
            this.Preprocessing = new System.Windows.Forms.Button();
            this.Detection = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.UpDownData = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.Threshold = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Accuracy = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Accuracy)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.chart1.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(44)))));
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(199)))), ((int)(((byte)(130)))));
            chartArea1.AxisY.InterlacedColor = System.Drawing.Color.Black;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(199)))), ((int)(((byte)(130)))));
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            chartArea1.Name = "ChartArea1";
            chartArea1.ShadowColor = System.Drawing.Color.DimGray;
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 53);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chart1.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(199)))), ((int)(((byte)(130)))))};
            this.chart1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series1.ChartArea = "ChartArea1";
            series1.LabelBackColor = System.Drawing.Color.White;
            series1.LabelBorderColor = System.Drawing.Color.White;
            series1.Legend = "Legend1";
            series1.MarkerBorderColor = System.Drawing.Color.White;
            series1.MarkerColor = System.Drawing.Color.White;
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1080, 589);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // PlotButton
            // 
            this.PlotButton.FlatAppearance.BorderSize = 0;
            this.PlotButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlotButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.PlotButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(199)))), ((int)(((byte)(130)))));
            this.PlotButton.Location = new System.Drawing.Point(1100, 15);
            this.PlotButton.Name = "PlotButton";
            this.PlotButton.Size = new System.Drawing.Size(110, 50);
            this.PlotButton.TabIndex = 1;
            this.PlotButton.Text = "Plot";
            this.PlotButton.UseVisualStyleBackColor = true;
            this.PlotButton.Click += new System.EventHandler(this.PlotButton_Click);
            // 
            // UpDown
            // 
            this.UpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.UpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.UpDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(199)))), ((int)(((byte)(130)))));
            this.UpDown.Increment = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.UpDown.Location = new System.Drawing.Point(715, 20);
            this.UpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.UpDown.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.UpDown.Name = "UpDown";
            this.UpDown.Size = new System.Drawing.Size(110, 19);
            this.UpDown.TabIndex = 2;
            this.UpDown.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.UpDown.ValueChanged += new System.EventHandler(this.UpDown_ValueChanged);
            // 
            // LowPass
            // 
            this.LowPass.Enabled = false;
            this.LowPass.FlatAppearance.BorderSize = 0;
            this.LowPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LowPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.LowPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(199)))), ((int)(((byte)(130)))));
            this.LowPass.Location = new System.Drawing.Point(1100, 95);
            this.LowPass.Name = "LowPass";
            this.LowPass.Size = new System.Drawing.Size(110, 60);
            this.LowPass.TabIndex = 3;
            this.LowPass.Text = "LowPass";
            this.LowPass.UseVisualStyleBackColor = true;
            this.LowPass.Click += new System.EventHandler(this.LowPass_Click);
            // 
            // Reset
            // 
            this.Reset.FlatAppearance.BorderSize = 0;
            this.Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Reset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(199)))), ((int)(((byte)(130)))));
            this.Reset.Location = new System.Drawing.Point(1097, 616);
            this.Reset.Name = "Reset";
            this.Reset.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Reset.Size = new System.Drawing.Size(117, 23);
            this.Reset.TabIndex = 4;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // HighPass
            // 
            this.HighPass.Enabled = false;
            this.HighPass.FlatAppearance.BorderSize = 0;
            this.HighPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HighPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.HighPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(199)))), ((int)(((byte)(130)))));
            this.HighPass.Location = new System.Drawing.Point(1100, 160);
            this.HighPass.Name = "HighPass";
            this.HighPass.Size = new System.Drawing.Size(110, 60);
            this.HighPass.TabIndex = 5;
            this.HighPass.Text = "HighPass";
            this.HighPass.UseVisualStyleBackColor = true;
            this.HighPass.Click += new System.EventHandler(this.HighPass_Click);
            // 
            // Derivative
            // 
            this.Derivative.Enabled = false;
            this.Derivative.FlatAppearance.BorderSize = 0;
            this.Derivative.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Derivative.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Derivative.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(199)))), ((int)(((byte)(130)))));
            this.Derivative.Location = new System.Drawing.Point(1100, 225);
            this.Derivative.Name = "Derivative";
            this.Derivative.Size = new System.Drawing.Size(110, 60);
            this.Derivative.TabIndex = 6;
            this.Derivative.Text = "Derivative";
            this.Derivative.UseVisualStyleBackColor = true;
            this.Derivative.Click += new System.EventHandler(this.Derivative_Click);
            // 
            // Squaring
            // 
            this.Squaring.Enabled = false;
            this.Squaring.FlatAppearance.BorderSize = 0;
            this.Squaring.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Squaring.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Squaring.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(199)))), ((int)(((byte)(130)))));
            this.Squaring.Location = new System.Drawing.Point(1100, 290);
            this.Squaring.Name = "Squaring";
            this.Squaring.Size = new System.Drawing.Size(110, 60);
            this.Squaring.TabIndex = 7;
            this.Squaring.Text = "Squaring";
            this.Squaring.UseVisualStyleBackColor = true;
            this.Squaring.Click += new System.EventHandler(this.Squaring_Click);
            // 
            // Integration
            // 
            this.Integration.Enabled = false;
            this.Integration.FlatAppearance.BorderSize = 0;
            this.Integration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Integration.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Integration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(199)))), ((int)(((byte)(130)))));
            this.Integration.Location = new System.Drawing.Point(1100, 355);
            this.Integration.Name = "Integration";
            this.Integration.Size = new System.Drawing.Size(110, 60);
            this.Integration.TabIndex = 8;
            this.Integration.Text = "Integration";
            this.Integration.UseVisualStyleBackColor = true;
            this.Integration.Click += new System.EventHandler(this.Integration_Click);
            // 
            // Preprocessing
            // 
            this.Preprocessing.Enabled = false;
            this.Preprocessing.FlatAppearance.BorderSize = 0;
            this.Preprocessing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Preprocessing.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Preprocessing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(199)))), ((int)(((byte)(130)))));
            this.Preprocessing.Location = new System.Drawing.Point(1100, 420);
            this.Preprocessing.Name = "Preprocessing";
            this.Preprocessing.Size = new System.Drawing.Size(110, 60);
            this.Preprocessing.TabIndex = 9;
            this.Preprocessing.Text = "Preprocessing";
            this.Preprocessing.UseVisualStyleBackColor = true;
            this.Preprocessing.Click += new System.EventHandler(this.Preprocessing_Click);
            // 
            // Detection
            // 
            this.Detection.Enabled = false;
            this.Detection.FlatAppearance.BorderSize = 0;
            this.Detection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Detection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Detection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(199)))), ((int)(((byte)(130)))));
            this.Detection.Location = new System.Drawing.Point(1100, 485);
            this.Detection.Name = "Detection";
            this.Detection.Size = new System.Drawing.Size(110, 60);
            this.Detection.TabIndex = 10;
            this.Detection.Text = "Detection";
            this.Detection.UseVisualStyleBackColor = true;
            this.Detection.Click += new System.EventHandler(this.Detection_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(199)))), ((int)(((byte)(130)))));
            this.textBox1.Location = new System.Drawing.Point(1220, 15);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(120, 625);
            this.textBox1.TabIndex = 11;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(199)))), ((int)(((byte)(130)))));
            this.textBox2.Location = new System.Drawing.Point(1352, 15);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(120, 625);
            this.textBox2.TabIndex = 12;
            // 
            // UpDownData
            // 
            this.UpDownData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.UpDownData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UpDownData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.UpDownData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(199)))), ((int)(((byte)(130)))));
            this.UpDownData.Location = new System.Drawing.Point(150, 20);
            this.UpDownData.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.UpDownData.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UpDownData.Name = "UpDownData";
            this.UpDownData.Size = new System.Drawing.Size(110, 19);
            this.UpDownData.TabIndex = 14;
            this.UpDownData.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UpDownData.ValueChanged += new System.EventHandler(this.UpDownData_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(199)))), ((int)(((byte)(130)))));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Choose Dataset:";
            // 
            // Threshold
            // 
            this.Threshold.Enabled = false;
            this.Threshold.FlatAppearance.BorderSize = 0;
            this.Threshold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Threshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Threshold.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(199)))), ((int)(((byte)(130)))));
            this.Threshold.Location = new System.Drawing.Point(1100, 550);
            this.Threshold.Name = "Threshold";
            this.Threshold.Size = new System.Drawing.Size(110, 60);
            this.Threshold.TabIndex = 16;
            this.Threshold.Text = "Detection + extras";
            this.Threshold.UseVisualStyleBackColor = true;
            this.Threshold.Click += new System.EventHandler(this.Threshold_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(199)))), ((int)(((byte)(130)))));
            this.label2.Location = new System.Drawing.Point(275, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Choose Accuracy:";
            // 
            // Accuracy
            // 
            this.Accuracy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.Accuracy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Accuracy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Accuracy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(199)))), ((int)(((byte)(130)))));
            this.Accuracy.Location = new System.Drawing.Point(420, 20);
            this.Accuracy.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.Accuracy.Name = "Accuracy";
            this.Accuracy.Size = new System.Drawing.Size(110, 19);
            this.Accuracy.TabIndex = 18;
            this.Accuracy.ValueChanged += new System.EventHandler(this.Accuracy_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(199)))), ((int)(((byte)(130)))));
            this.label3.Location = new System.Drawing.Point(545, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Choose Data Number:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1484, 651);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Accuracy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Threshold);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UpDownData);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Detection);
            this.Controls.Add(this.Preprocessing);
            this.Controls.Add(this.Integration);
            this.Controls.Add(this.Squaring);
            this.Controls.Add(this.Derivative);
            this.Controls.Add(this.HighPass);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.LowPass);
            this.Controls.Add(this.UpDown);
            this.Controls.Add(this.PlotButton);
            this.Controls.Add(this.chart1);
            this.MaximumSize = new System.Drawing.Size(1500, 690);
            this.MinimumSize = new System.Drawing.Size(1500, 690);
            this.Name = "Form1";
            this.Text = "ECG Segmentation";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Accuracy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button PlotButton;
        private System.Windows.Forms.NumericUpDown UpDown;
        private System.Windows.Forms.Button LowPass;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button HighPass;
        private System.Windows.Forms.Button Derivative;
        private System.Windows.Forms.Button Squaring;
        private System.Windows.Forms.Button Integration;
        private System.Windows.Forms.Button Preprocessing;
        private System.Windows.Forms.Button Detection;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.NumericUpDown UpDownData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Threshold;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown Accuracy;
        private System.Windows.Forms.Label label3;
    }
}

