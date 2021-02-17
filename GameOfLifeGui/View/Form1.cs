using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameOfLife;
using Newtonsoft.Json;

namespace GameOfLifeGui
{
    public partial class Form1 : Form
    {
        private NumberphileFinder _numberphileFinder;

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                upperPnl.Enabled = false;
                await FindNumberphile(tbName.Text, btnColor.BackColor, (int) chromosomeNum.Value,
                    (double) numericUpDownMutation.Value, (double) numericUpDownCroosover.Value,
                    (double) numericUpDownKeepBestRation.Value, (int) numericUpDownMaxIterations.Value);
            }
            finally
            {
                upperPnl.Enabled = true;
            }
        }

        private async Task FindNumberphile(string name, Color color, int chromosomeNum, double mutationProb,
            double crossoverProb, double keepBestRation, int maxIteration)
        {
            var sw = new Stopwatch();
            sw.Start();
            var results = await Task.Run(() => _numberphileFinder.FindNumberphile(chromosomeNum, mutationProb, crossoverProb, keepBestRation, maxIteration));
            AddChart(results.Item2, name, color);
        }

        private void AddChart(IEnumerable<Coords> results, string name, Color color)
        {
            chart1.Series.Add(name);
            chart1.Series[name].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[name].Color = color;

            foreach (var inordinate in results)
            {
                chart1.Series[name].Points.AddXY(inordinate.X, inordinate.Y);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _numberphileFinder = new NumberphileFinder();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnColor.BackColor = colorDialog1.Color;
            }
        }

        private async void btnAddFromFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    upperPnl.Enabled = false;
                    var filePath = openFileDialog1.FileName;
                    var coordinates = new List<Coords>();
                    await Task.Run(() =>
                    {
                        var jsonString = File.ReadAllText(filePath);
                        coordinates = JsonConvert.DeserializeObject<List<Coords>>(jsonString);
                    });
                    AddChart(coordinates, filePath, btnColor.BackColor);
                }
                finally
                {
                    upperPnl.Enabled = true;
                }
            }

        }
    }
}
