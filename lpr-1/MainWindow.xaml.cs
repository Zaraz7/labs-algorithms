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
        public static int nodesNumber = 6;
        enum subs { AdjacencyMatrix = 0, AdjacencyList = 1 };
        public static AdjacencyMatrixGraph graph = new AdjacencyMatrixGraph(nodesNumber);

        static void Oriented()
        {
            graph.SetEdge(1, 2, 10, true);

        }

        public MainWindow()
        {
            InitializeComponent();

        }
    }
}
