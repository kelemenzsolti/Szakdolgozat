using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ECGSegmentation
{
    public partial class Form1 : Form
    {
        private ECGModel _model;
        private DataAccess _dataaccess;
        public Form1()
        {
            InitializeComponent();
            _dataaccess = new DataAccess();
            _model = new ECGModel(_dataaccess);
            _model.SetDataNum(Decimal.ToInt32(UpDown.Value));

            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart1.MouseWheel += Zoom;
        }
        private void DrawChart()
        {
            chart1.DataSource = _model.dt;
            chart1.Series["Series1"].XValueMember = "Time";
            chart1.Series["Series1"].YValueMembers = "mV";
            chart1.Series["Series1"].BorderWidth = 1;
            chart1.Series["Series1"].ChartType = SeriesChartType.Line;
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "";
        }


        private void Zoom(object sender, MouseEventArgs e)
        {
            Chart chart = (Chart)sender;
            Axis xAxis = chart.ChartAreas[0].AxisX;
            Axis yAxis = chart.ChartAreas[0].AxisY;

            try
            {
                if (e.Delta < 0)
                {
                    xAxis.ScaleView.ZoomReset();
                    yAxis.ScaleView.ZoomReset();
                }
                else if (e.Delta > 0)
                {
                    double xMin = xAxis.ScaleView.ViewMinimum;
                    double xMax = xAxis.ScaleView.ViewMaximum;
                    double yMin = yAxis.ScaleView.ViewMinimum;
                    double yMax = yAxis.ScaleView.ViewMaximum;

                    double posXStart = xAxis.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 4;
                    double posXFinish = xAxis.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 4;
                    double posYStart = yAxis.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / 4;
                    double posYFinish = yAxis.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / 4;

                    xAxis.ScaleView.Zoom(posXStart, posXFinish);
                    yAxis.ScaleView.Zoom(posYStart, posYFinish);
                }
            }
            catch { }
        }

        private void PlotButton_Click(object sender, EventArgs e)
        {
            PlotButton.Enabled = false;
            Preprocessing.Enabled = true;
            LowPass.Enabled = true;
            _model.ReadFile();
            _model.ReadPeaks();

            textBox1.Text = "Rpeaks detected by the program: \r\n \r\n";
            textBox2.Text = "Rpeaks from database: \r\n \r\n";
            for (int i = 0; i < _model.dbtimeget.Count; i++)
            {
                textBox2.Text += _model.dbtimeget[i];
            }

            DrawChart();
        }

        private void LowPass_Click(object sender, EventArgs e)
        {
            Preprocessing.Enabled = false;
            LowPass.Enabled = false;
            HighPass.Enabled = true;
            _model.LowPass();
            DrawChart();
        }

        private void HighPass_Click(object sender, EventArgs e)
        {
            HighPass.Enabled = false;
            Derivative.Enabled = true;
            _model.HighPass();
            DrawChart();
        }

        private void Derivative_Click(object sender, EventArgs e)
        {
            Derivative.Enabled = false;
            Squaring.Enabled = true;
            _model.Derivative();
            DrawChart();
        }

        private void Squaring_Click(object sender, EventArgs e)
        {
            Squaring.Enabled = false;
            Integration.Enabled = true;
            _model.Squaring();
            DrawChart();
        }

        private void Integration_Click(object sender, EventArgs e)
        {
            Integration.Enabled = false;
            Detection.Enabled = true;
            Threshold.Enabled = true;
            _model.Integration();
            DrawChart();
        }

        private void Preprocessing_Click(object sender, EventArgs e)
        {
            LowPass.Enabled = false;
            Preprocessing.Enabled = false;
            Detection.Enabled = true;
            Threshold.Enabled = true;
            _model.Preprocessing();
            DrawChart();
        }

        private void Detection_Click(object sender, EventArgs e)
        {
            Detection.Enabled = false;
            Threshold.Enabled = false;

            chart1.Series.Add("Peaks");
            chart1.Series["Peaks"].ChartType = SeriesChartType.Line;
            chart1.Series["Peaks"].Color = Color.FromArgb(255, 102, 102);
            chart1.Series["Peaks"].BorderWidth = 2;
            chart1.Series["Peaks"].YValueMembers = "Peaks";
            chart1.Series["Peaks"].XValueMember = "Time";

            _model.Detection(false);

            DrawChart();

            for (int i = 0; i < _model.timeget.Count; i++)
            {
                textBox1.Text += _model.timeget[i].ToString();
                textBox1.Text += "\r\n";
            }
            string message = "The percentage of which the program is correct to the accuracy from the database r peak detector: " + _model.statistics + "%";
            string title = "Statistics";
            MessageBox.Show(message, title);
        }

        private void Threshold_Click(object sender, EventArgs e)
        {
            Detection.Enabled = false;
            Threshold.Enabled = false;

            chart1.Series.Add("Threshold");
            chart1.Series["Threshold"].ChartType = SeriesChartType.Line;
            chart1.Series["Threshold"].Color = Color.FromArgb(255, 102, 102);
            chart1.Series["Threshold"].BorderWidth = 2;
            chart1.Series["Threshold"].YValueMembers = "Threshold";
            chart1.Series["Threshold"].XValueMember = "Time";

            chart1.Series.Add("NoiseLevel");
            chart1.Series["NoiseLevel"].ChartType = SeriesChartType.Line;
            chart1.Series["NoiseLevel"].Color = Color.FromArgb(231, 187, 65);
            chart1.Series["NoiseLevel"].BorderWidth = 2;
            chart1.Series["NoiseLevel"].YValueMembers = "NoiseLevel";
            chart1.Series["NoiseLevel"].XValueMember = "Time";

            chart1.Series.Add("SignalLevel");
            chart1.Series["SignalLevel"].ChartType = SeriesChartType.Line;
            chart1.Series["SignalLevel"].Color = Color.FromArgb(6, 141, 157);
            chart1.Series["SignalLevel"].BorderWidth = 2;
            chart1.Series["SignalLevel"].YValueMembers = "SignalLevel";
            chart1.Series["SignalLevel"].XValueMember = "Time";

            _model.Detection(true);
            DrawChart();

            for (int i = 0; i < _model.timeget.Count; i++)
            {
                textBox1.Text += _model.timeget[i].ToString();
                textBox1.Text += "\r\n";
            }
            string message = "The percentage of which the program is correct to the accuracy from the database r peak detector: " + _model.statistics + "%";
            string title = "Statistics";
            MessageBox.Show(message, title);
        }

        private void UpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            _model.SetDataNum(Decimal.ToInt32(nud.Value));
        }

        private void UpDownData_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            _model.SetDataSetNum(Decimal.ToInt32(nud.Value));
        }
        private void Accuracy_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            _model.SetAccuracy(Decimal.ToInt32(nud.Value));
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            PlotButton.Enabled = true;
            LowPass.Enabled = false;
            HighPass.Enabled = false;
            Derivative.Enabled = false;
            Squaring.Enabled = false;
            Integration.Enabled = false;
            Preprocessing.Enabled = false;
            Detection.Enabled = false;
            Threshold.Enabled = false;
            if(_model.extras)
            {
                chart1.Series.Remove(chart1.Series["Threshold"]);
                chart1.Series.Remove(chart1.Series["NoiseLevel"]);
                chart1.Series.Remove(chart1.Series["SignalLevel"]);
            }
            else if(textBox1.Text.Length > 40)
            {
                chart1.Series.Remove(chart1.Series["Peaks"]);
            }
            textBox1.Text = "Rpeaks detected by the program: \r\n \r\n";
            textBox2.Text = "Rpeaks from database: \r\n \r\n";
            _model.ModelReset();
            DrawChart();
        }
    }
}
