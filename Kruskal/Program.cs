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
            List<Edge> F = new List<Edge>();

            // 1. xap sep theo trong so tang dan
            for (int i = 0; i < G.Edges.Count; i++)
            {
                for (int j = 0; j < G.Edges.Count - 1; j++)
                {
                    if(G.Edges[j].Weight > G.Edges[j + 1].Weight)
                    {
                        Edge a = G.Edges[j];
                        G.Edges[j] = G.Edges[j + 1];
                        G.Edges[j + 1] = a;
                    }
                }
            }

            // 2. them cac canh vao F neu khong tao nen chu trinh
            // 3. lap lai den khi co n - 1 canh dc chon
            //F.Add(G.Edges[0]);
            while(F.Count < G.Vertices.Count - 1)
            {
                //xet tung canh, cac canh co duy nhat 1 nut trung voi cac nut cua cac canh da co trong F, 
                //thi nhung canh do dc them vao F
                for (int i = 0; i < G.Edges.Count; i++)
                {
                    bool add = true;
                    for (int j = 0; j < F.Count; j++)
                    {
                        if(G.Edges[i].End1.Name == F[j].End1.Name || G.Edges[i].End1.Name == F[j].End2.Name)
                        {
                            for (int k = 0; k < F.Count; k++)
                            {
                                if (G.Edges[i].End2.Name == F[k].End2.Name || G.Edges[i].End2.Name == F[k].End1.Name)
                                {
                                    add = false;
                                    break;
                                }
                                else
                                {
                                    add = true;
                                }
                            }
                            break;
                        }
                    }
                    if (add == true)
                    {
                        F.Add(G.Edges[i]);
                    }
                }
            }
            // Show ket qua
            for (int i = 0; i < F.Count; i++)
            {
                Console.WriteLine("(" + F[i].End1.Name + "," + F[i].End2.Name + ")" + " weight: " + F[i].Weight);
            }

        }
    }
}
