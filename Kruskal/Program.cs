using System;
using System.Collections.Generic;

namespace Kruskal
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph(@"C:\Users\supod\source\repos\Kruskal\Kruskal\matrix.txt");
            Console.WriteLine("Thuat toan kruskal: ");
            kruskal(graph);

        }
        public static void kruskal(Graph G)
        {
            try
            {
                List<Edge> F = new List<Edge>();

                // 1. xap sep theo trong so tang dan
                for (int i = 0; i < G.Edges.Count; i++)
                {
                    for (int j = 0; j < G.Edges.Count - 1; j++)
                    {
                        if (G.Edges[j].Weight > G.Edges[j + 1].Weight)
                        {
                            Edge a = G.Edges[j];
                            G.Edges[j] = G.Edges[j + 1];
                            G.Edges[j + 1] = a;
                        }
                    }
                }
                // 2. them cac canh vao F neu khong tao nen chu trinh
                // 3. lap lai den khi co n - 1 canh dc chon
                for (int i = 0; (i < G.Edges.Count) && (F.Count < G.Vertices.Count - 1); i++)
                {
                    int End1TreeNumber = Convert.ToInt32(G.Edges[i].End1.Name);
                    int End2TreeNumber = Convert.ToInt32(G.Edges[i].End2.Name);
                    if (G.Trees[End1TreeNumber] != G.Trees[End2TreeNumber])
                    {
                        F.Add(G.Edges[i]);
                        if (G.biggerTree(G.Trees[End1TreeNumber], G.Trees[End2TreeNumber]))
                        {
                            G.Trees[End2TreeNumber] = G.Trees[End1TreeNumber];
                        }
                        else
                        {
                            G.Trees[End1TreeNumber] = G.Trees[End2TreeNumber];
                        }
                    }
                }
                // Show ket qua
                for (int i = 0; i < F.Count; i++)
                {
                    Console.WriteLine("(" + F[i].End1.Name + "," + F[i].End2.Name + ")" + " weight: " + F[i].Weight);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
