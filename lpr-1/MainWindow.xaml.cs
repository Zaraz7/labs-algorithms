using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using z7GraphUtils;

namespace lpr_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public static int nodesNumber = 6;
        enum subs { AdjacencyMatrix = 0, AdjacencyList = 1 };
        public static AdjacencyMatrixGraph graph = new AdjacencyMatrixGraph(6);
        Random random = new Random();


        public MainWindow()
        {
            InitializeComponent();

        }

        private void btcOrientedLoop(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i < graph.nodes; i++)
            {
                graph.SetEdge(i-1, i, random.Next(1, 99));
            }
            graph.SetEdge(graph.nodes-1, 0, random.Next(1, 99));
            tbGlobal.Text = graph.GraphToString(cbHeadings.IsChecked ?? false, cbColors.IsChecked ?? false);
        }
        private void btcBiPartite(object sender, RoutedEventArgs e)
        {
            var redNodes = new List<int>();
            var blueNodes = new List<int>();


            for (int i = 0; i < graph.nodes; i++)
            {
                if (random.Next(2) == 0)
                {
                    redNodes.Add(i);
                    graph.SetColor4Node(i, ConsoleColor.Red);
                }
                else
                {
                    blueNodes.Add(i);
                    graph.SetColor4Node(i, ConsoleColor.Blue);
                }

            }
            foreach (int source in redNodes)
            {
                graph.SetEdge(source, blueNodes[random.Next(blueNodes.Count)], 1, true, (ConsoleColor)random.Next(9, 15));
            }
            foreach (int source in blueNodes)
            {
                graph.SetEdge(source, redNodes[random.Next(redNodes.Count)], 1, true, (ConsoleColor)random.Next(9, 15));
            }
            tbGlobal.Text = graph.GraphToString(cbHeadings.IsChecked ?? false, cbColors.IsChecked ?? false);

        }

        private void cbColors_Checked(object sender, RoutedEventArgs e)
        {   
            if (tbGlobal != null)
            {
                tbGlobal.Text = graph.GraphToString(cbHeadings.IsChecked ?? false, cbColors.IsChecked ?? false);
            } 
        }
    }
}
