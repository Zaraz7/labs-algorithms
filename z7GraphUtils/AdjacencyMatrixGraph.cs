using System;
using System.Text;

namespace z7GraphUtils
{
    public class AdjacencyMatrixGraph
    {
        private int nodes;
        private Node[] nodesArray;
        private Edge[,] matrix;
        public void Print()
        {
            Console.Write($" \t");
            for (int i = 0; i < nodes; i++)
            {
                Console.BackgroundColor = nodesArray[i].color;
                Console.Write($"{i} \t");
            }
            Console.WriteLine("\n");
            for (int i = 0; i < nodes; i++)
            {
                Console.BackgroundColor = nodesArray[i].color;
                Console.Write($"{i} \t");
                for (int j = 0; j < nodes; j++)
                {
                    Console.BackgroundColor = matrix[i, j].color;
                    Console.Write($"{matrix[i, j].weight} \t");
                }
                Console.ResetColor();
                Console.WriteLine();
            }
        }
        public string GraphToString(bool headlines = true)
        {
            StringBuilder sb = new StringBuilder();

            if (headlines) { 
                for (int i = 0; i < nodes; i++)
                {
                    Console.BackgroundColor = nodesArray[i].color;
                    sb.Append($"\t{i}");
                }
                sb.AppendLine("");
            }
            for (int i = 0; i < nodes; i++)
            {
                if (headlines)
                    sb.Append($"{i} \t");
                for (int j = 0; j < nodes; j++)
                {
                    sb.Append($"{matrix[i, j].weight} \t");
                }
                sb.AppendLine("");
            }

            return sb.ToString();
        }
        public void SetEdge(int source, int target, int weight = 1, bool notOriented = false)
        {
            matrix[source, target].weight = weight;
            if (notOriented)
                matrix[target, source].weight = weight;
        }
        public void DropEdge(int source, int target, bool notOriented = false)
        {
            matrix[source, target].weight = 0;
            if (notOriented)
                matrix[target, source].weight = 0;
        }
        public void SetColor4Node(int target, ConsoleColor color)
        {
            nodesArray[target].color = color;
        }
        public void SetColor4Edge(int source, int target, ConsoleColor color, bool notOriented = false)
        {
            matrix[source, target].color = color;
            if (notOriented)
                matrix[target, source].color = color;
        }

        public AdjacencyMatrixGraph(int nodes, bool colorfull = true)
        {
            this.nodes = nodes;
            this.nodesArray = new Node[nodes];
            this.matrix = new Edge[nodes, nodes];
            for (int i = 0; i < nodes; i++)
                nodesArray[i] = new Node();
            for (int i = 0; i < nodes; i++)
            {
                for (int j = 0; j < nodes; j++)
                {
                    matrix[i, j] = new Edge();
                }
            }
        }
    }
}
