using System;
using System.Collections.Generic;
using System.Text;

namespace Kruskal
{
    class Edge
    {
        protected Vertex end1 = new Vertex();
        protected Vertex end2 = new Vertex();
        public Vertex End1
        {
            get { return end1; }
            set { end1 = value; }
        }
        public Vertex End2
        {
            get { return end2; }
            set { end2 = value; }
        }
        public int Weight { get; set; }
        public Edge()
        {

        }
        public Edge(Vertex end1, Vertex end2, int weight)
        {
            End1 = end1;
            End2 = end2;
            Weight = weight;
        }
        public Edge(string nameEnd1, string nameEnd2, int weight)
        {
            End1.Name = nameEnd1;
            End2.Name = nameEnd2;
            Weight = weight;
        }
    }
}
