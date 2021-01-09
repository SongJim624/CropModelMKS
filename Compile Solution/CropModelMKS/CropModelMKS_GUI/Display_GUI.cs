using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using CropModelMKS;

namespace CropModelMKS_GUI
{
    public partial class Display_GUI : Form
    {
        private readonly Simulator simulator;
        private readonly List<string> type_list;

        public Display_GUI(Simulator simulator, XmlDocument states)
        {
            InitializeComponent();

            type_list = new List<string> { };
            this.simulator = simulator;

            foreach (XmlElement module in states.GetElementsByTagName("Module"))
            {
                TreeNode node = new TreeNode
                {
                    Text = module.GetAttribute("type")
                };
                type_list.Add(node.Text);

                treeView1.Nodes.Add(node);

                foreach (XmlElement state in module.GetElementsByTagName("item"))
                {
                    if (state.GetAttribute("size") == "array") { continue; }

                    TreeNode n = new TreeNode
                    {
                        Text = state.GetAttribute("name")
                    };

                    node.Nodes.Add(n);
                }
            }
        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(type_list.Contains(treeView1.SelectedNode.Text))
            {
                return;
            }

            string name = treeView1.SelectedNode.Text;

            int i = 1;
            List<double> values = new List<double> { };
            List<int> days = new List<int> { };
            try
            {
                while (true)
                {
                    double value = double.Parse(simulator.Inquire(name, i).ToString());

                    values.Add(value);
                    days.Add(i);
                    i++;
                }
            }
            catch
            {
                chart1.Series.Clear();

                Series series = new Series
                {
                    ChartType = SeriesChartType.Line
                };

                series.Points.DataBindXY(days, values);                
                chart1.Series.Add(series);
                chart1.ChartAreas[0].RecalculateAxesScale();
            }
        }
    }
}
