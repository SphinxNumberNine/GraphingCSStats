using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace GraphingApplication
{
    public partial class GraphingForm : Form
    {

        public GraphingForm()
        {
            InitializeComponent();
        } //default constructor; unused

        public GraphingForm(Form1.Stats stats)
        {
            int ak47 = stats.ak47_kills;
            int m4a1 = stats.m4a4_kills;
            int awp = stats.awp_kills;
            int p2000 = stats.p2000_kils;
            int glock = stats.glock18_kills;
            int deagle = stats.desert_eagle_kills;
            int ump = stats.ump45_kills;
            int tec9 = stats.tec9_kills;
            int fiveseven = stats.five_seven_kills;

            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            var model = new PlotModel { Title = "Individual Weapon Stats" };
            var barSeries = new BarSeries
            {
                ItemsSource = new List<BarItem>(new[]
                {
                    new BarItem { Value = ak47 },
                    new BarItem { Value = m4a1 },
                    new BarItem { Value = awp },
                    new BarItem { Value = p2000 },
                    new BarItem { Value = glock },
                    new BarItem { Value = deagle },
                    new BarItem { Value = ump },
                    new BarItem { Value = tec9 },
                    new BarItem { Value = fiveseven}
                }),
                LabelPlacement = LabelPlacement.Inside,
                LabelFormatString = "{0}",
                LabelMargin = 3
            };
            model.Series.Add(barSeries);
            model.Axes.Add(new CategoryAxis
            {
                Position = AxisPosition.Left,
                Key = "WeaponAxis",
                ItemsSource = new[]
                {
                    "AK-47 Kills",
                    "M4A4/M4A1-S Kills",
                    "AWP Kills",
                    "USP-S/P2000 Kills",
                    "Glock-18 Kills",
                    "Desert Eagle Kills",
                    "UMP-45 Kills",
                    "Tec-9 Kills",
                    "Five-Seven Kills"
                }
            });
            plot1.Model = model;         
        } //used when graphing individual stats

        public GraphingForm(Form1.Stats firstPlayerStats, Form1.Stats secondPlayerStats)
        {
            int ak47First = firstPlayerStats.ak47_kills;
            int m4a1First = firstPlayerStats.m4a4_kills;
            int awpFirst = firstPlayerStats.awp_kills;
            int p2000First = firstPlayerStats.p2000_kils;
            int glockFirst = firstPlayerStats.glock18_kills;
            int deagleFirst = firstPlayerStats.desert_eagle_kills;
            int umpFirst = firstPlayerStats.ump45_kills;
            int tec9First = firstPlayerStats.tec9_kills;
            int fivesevenFirst = firstPlayerStats.five_seven_kills;
            String playerNameFrist = firstPlayerStats.playerName;

            int ak47Second = secondPlayerStats.ak47_kills;
            int m4a1Second = secondPlayerStats.m4a4_kills;
            int awpSecond = secondPlayerStats.awp_kills;
            int p2000Second = secondPlayerStats.p2000_kils;
            int glockSecond = secondPlayerStats.glock18_kills;
            int deagleSecond = secondPlayerStats.desert_eagle_kills;
            int umpSecond = secondPlayerStats.ump45_kills;
            int tec9Second = secondPlayerStats.tec9_kills;
            int fivesevenSecond = secondPlayerStats.five_seven_kills;
            String playerNameSecond = secondPlayerStats.playerName;

            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(1169, 612);
            this.plot1.Size = new System.Drawing.Size(1169, 600);

            var model = new PlotModel
            {
                Title = "Compared Weapon Stats",
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomCenter,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendBorderThickness = 0
            };

            var firstSeries = new BarSeries
            {
                Title = playerNameFrist,
                StrokeColor = OxyColors.Black,
                StrokeThickness = 1,
                LabelPlacement = LabelPlacement.Inside,
                LabelFormatString = "{0}",
                LabelMargin = 3
            };

            firstSeries.Items.Add(new BarItem { Value = ak47First });
            firstSeries.Items.Add(new BarItem { Value = m4a1First });
            firstSeries.Items.Add(new BarItem { Value = awpFirst });
            firstSeries.Items.Add(new BarItem { Value = p2000First });
            firstSeries.Items.Add(new BarItem { Value = glockFirst });
            firstSeries.Items.Add(new BarItem { Value = deagleFirst });
            firstSeries.Items.Add(new BarItem { Value = umpFirst });
            firstSeries.Items.Add(new BarItem { Value = tec9First });
            firstSeries.Items.Add(new BarItem { Value = fivesevenFirst });

            var secondSeries = new BarSeries
            {
                Title = playerNameSecond,
                StrokeColor = OxyColors.Black,
                StrokeThickness = 1,
                LabelPlacement = LabelPlacement.Inside,
                LabelFormatString = "{0}",
                LabelMargin = 3
            };

            secondSeries.Items.Add(new BarItem { Value = ak47Second });
            secondSeries.Items.Add(new BarItem { Value = m4a1Second });
            secondSeries.Items.Add(new BarItem { Value = awpSecond });
            secondSeries.Items.Add(new BarItem { Value = p2000Second });
            secondSeries.Items.Add(new BarItem { Value = glockSecond });
            secondSeries.Items.Add(new BarItem { Value = deagleSecond });
            secondSeries.Items.Add(new BarItem { Value = umpSecond });
            secondSeries.Items.Add(new BarItem { Value = tec9Second });
            secondSeries.Items.Add(new BarItem { Value = fivesevenSecond });

            var categoryAxis = new CategoryAxis { Position = AxisPosition.Left };
            categoryAxis.Labels.Add("AK-47 Kills");
            categoryAxis.Labels.Add("M4A4/M4A1-S Kills");
            categoryAxis.Labels.Add("AWP Kills");
            categoryAxis.Labels.Add("USP-S/P2000 Kills");
            categoryAxis.Labels.Add("Glock-18 Kills");
            categoryAxis.Labels.Add("Desert Eagle Kills");
            categoryAxis.Labels.Add("UMP-45 Kills");
            categoryAxis.Labels.Add("Tec-9 Kills");
            categoryAxis.Labels.Add("Five-Seven Kills");

            var valueAxis = new LinearAxis { Position = AxisPosition.Bottom, MinimumPadding = 0, MaximumPadding = 0, AbsoluteMinimum = 0};

            model.Series.Add(firstSeries);
            model.Series.Add(secondSeries);
            model.Axes.Add(categoryAxis);
            model.Axes.Add(valueAxis);
            plot1.Model = model;
        } //used when graphing comparative stats

        public GraphingForm(Form1.Stats stats, int i) //for use when graphing weapon use percentages
        {
            int totalKills = stats.total_kills;
            int ak47 = stats.ak47_kills;
            int m4a1 = stats.m4a4_kills;
            int awp = stats.awp_kills;
            int p2000 = stats.p2000_kils;
            int glock = stats.glock18_kills;
            int deagle = stats.desert_eagle_kills;
            int ump = stats.ump45_kills;
            int tec9 = stats.tec9_kills;
            int fiveseven = stats.five_seven_kills;
            int remainingkills = totalKills - ak47 - m4a1 - awp - p2000 - glock - deagle - ump - tec9 - fiveseven;

            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(762, 762);
            this.plot1.Size = new System.Drawing.Size(750, 750);

            var model = new PlotModel { Title = "Weapon Use Percentages" , TitlePadding = 20};

            var pieSeries = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 0, InsideLabelFormat = "{2:.00}%" , OutsideLabelFormat = "{1}"};

            pieSeries.Slices.Add(new PieSlice("AK-47", ak47) { IsExploded = false, Fill = OxyColors.MediumPurple });
            pieSeries.Slices.Add(new PieSlice("M4A4/M4A1-S", m4a1) { IsExploded = true });
            pieSeries.Slices.Add(new PieSlice("AWP", awp) { IsExploded = true });
            pieSeries.Slices.Add(new PieSlice("USP-S/P2000", p2000) { IsExploded = true });
            pieSeries.Slices.Add(new PieSlice("Glock-18", glock) { IsExploded = true });
            pieSeries.Slices.Add(new PieSlice("Desert Eagle", deagle) { IsExploded = true });
            pieSeries.Slices.Add(new PieSlice("UMP-45", ump) { IsExploded = true });
            pieSeries.Slices.Add(new PieSlice("Tec-9", tec9) { IsExploded = true });
            pieSeries.Slices.Add(new PieSlice("Five-Seven", fiveseven) { IsExploded = true });
            pieSeries.Slices.Add(new PieSlice("Other", remainingkills) { IsExploded = false, Fill = OxyColors.Aquamarine });

            model.Series.Add(pieSeries);

            plot1.Model = model;
        }
    }
}
