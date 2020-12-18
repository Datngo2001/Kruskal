using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Kruskal
{
    class Graph
    {
        protected List<Vertex> vertices = new List<Vertex>();
        protected List<Edge> edges = new List<Edge>();
        protected List<List<int>> Matrix = new List<List<int>>();
        public List<Vertex> Vertices
        {
            get { return vertices; }
            set { vertices = value; }
        }
        public List<Edge> Edges
        {
            get { return edges; }
            set { edges = value; }
        }
        public Graph()
        {

        }
        public Graph(List<Edge> edge, List<Vertex> vertice)
        {
            Edges = edge;
            Vertices = vertice;
        }
        public Graph(List<List<int>> matrix)
        {
            Matrix = matrix;
        }
        public Graph(string pathMatrix)
        {
            ReadMatrix(pathMatrix);
        }
        protected void ReadMatrix(string path)
        {
            StreamReader reader = new StreamReader(path);
            int i = 0;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] node = line.Split(" ");
                for (int j = i; j < node.Length; j++)
                {
                    if(node[j] != "0")
                    {
                        int weight = Convert.ToInt32(node[j]);
                        Edge edge = new Edge(i.ToString(), j.ToString(), weight);
                        Edges.Add(edge);
                    }
                }
                Vertex vertex = new Vertex((i + 1).ToString());
                Vertices.Add(vertex);
                i++;
            }
            reader.Close();
        }
    }
}
