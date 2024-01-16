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
            tbGlobal.Text = graph.GraphToString(cbHeadings.IsChecked ?? false);
        }
    }
}
