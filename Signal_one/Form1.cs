using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signal_one
{
    using Chart = System.Windows.Forms.DataVisualization.Charting.Chart;

    public partial class Form1 : Form
    {
        /// <summary>
        /// Виды сигналов
        /// </summary>
        enum TypeSignal
        {
            CustomUnknown,
            CustomSignalCardio,
            CustomSignalReo,
            CustomSignalSpiro,
            CustomSignalVelo,
            SquareSignal,
            SawtoothSignal,
            TriangularSignal
        }

        private TypeSignal m_currentCustomSignal;

        string cardio = "Cardio";
        string reo = "Reo";
        string spiro = "Spiro";
        string velo = "Velo";

        /// <summary>
        /// Лист- хранит сигнал считанный из файла
        /// </summary>
        private List<double> m_customSignal;

        /// <summary>
        /// Лист- хранит прямоуголный тестовый сигнал
        /// </summary>
        private List<double> m_squareSignal;

        /// <summary>
        /// Лист- хранит пилообразный тестовый сигнал
        /// </summary>
        private List<double> m_sawtoothSignal;

        /// <summary>
        /// Лист- хранит треуголный тестовый сигнал
        /// </summary>
        private List<double> m_triangularSignal;

        private const int cardioMax = 255;
        private const int cardioMin = 0;

        public Form1()
        {
            InitializeComponent();
            InitValue();
        }

        private void InitValue()
        {
            SignalDuration.Value = 2;
            SamplingFrequencySignal.Value = 360;
        }

        private void FillChart(ref Chart _chart, int _minY, int _maxY, int _maxX, int _minX, ref List<double> _signal)
        {
            _chart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;

            _chart.ChartAreas[0].AxisY.Minimum = _minY;
            _chart.ChartAreas[0].AxisY.Maximum = _maxY;
            //_chart.ChartAreas[0].AxisX.Minimum = _minX;
            //_chart.ChartAreas[0].AxisX.Maximum = _maxX;
            for (int i = 0; i < _signal.Count; i++)
                chart1.Series[0].Points.AddXY(i, _signal.ElementAt(i));
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            if (openFileSignal.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileSignal.FileName;
            if (filename.Contains(cardio))
                m_currentCustomSignal = TypeSignal.CustomSignalCardio;
            else if (filename.Contains(spiro))
                m_currentCustomSignal = TypeSignal.CustomSignalSpiro;
            else if (filename.Contains(reo))
                m_currentCustomSignal = TypeSignal.CustomSignalReo;
            else if (filename.Contains(velo))
                m_currentCustomSignal = TypeSignal.CustomSignalVelo;
            else
                m_currentCustomSignal = TypeSignal.CustomUnknown;

            FileHandler.ReadFile(filename, ref m_customSignal);
        }

        private void GenerateTestSignal_Click(object sender, EventArgs e)
        {
            if (SignalDuration.Value <= 0 || SamplingFrequencySignal.Value <= 0)
            {
                MessageBox.Show("Укажите действительные параметры для генерации тестовых сигналов");
                return;
            }
            SignalGenerator.GenerationSawtoothSignal((int)SamplingFrequencySignal.Value, (int)SignalDuration.Value, ref m_sawtoothSignal);
            SignalGenerator.GenerationSquareSignal((int)SamplingFrequencySignal.Value, (int)SignalDuration.Value, ref m_squareSignal);
            SignalGenerator.GenerationTriangularSignal((int)SamplingFrequencySignal.Value, (int)SignalDuration.Value, ref m_triangularSignal);
        }

        private void Start_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;

            chart1.ChartAreas[0].AxisY.Interval = 0.5;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.Minimum = 0;

            for (int i = 0; i < m_customSignal.Count; i++)
            {
                double y = (m_customSignal.ElementAt(i) - 127);
                y = y / 60;
                double x = (double)i / 360;
                chart1.Series[0].Points.AddXY(x, y);
            }
        }
    }
}
