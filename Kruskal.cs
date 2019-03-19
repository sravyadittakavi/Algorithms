using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int numTotalEdgeNodes = 6;
            int numTotalAvailableNetworkRoutes = 3;
            int[,] networkRoutesAvailable = new int[,] { { 1, 4 }, { 4, 5 }, { 2, 3 } };
            int numNewNetworkRoutesConstruct = 4;
            int[,] costNewNetworkRoutesConstruct = new int[,] { { 1, 2, 5 }, { 1, 3, 10 }, { 1, 6, 2 }, { 5, 6, 5 } };
            Console.WriteLine(minimumCostIncurred(numTotalEdgeNodes, numTotalAvailableNetworkRoutes, networkRoutesAvailable, numNewNetworkRoutesConstruct, costNewNetworkRoutesConstruct));            
            Console.ReadKey();
        }

        public static int minimumCostIncurred(int numTotalEdgeNodes, int numTotalAvailableNetworkRoutes, int[,] networkRoutesAvailable, int numNewNetworkRoutesConstruct, int[,] costNewNetworkRoutesConstruct)
        {
            // Construct edges
            Graph graph = CreateGraph(numTotalEdgeNodes, numTotalAvailableNetworkRoutes+ numNewNetworkRoutesConstruct);

            
            for(int i = 0; i < numTotalAvailableNetworkRoutes; i++)
            {
                graph.edge[i].Source = networkRoutesAvailable[i,0]-1;
                graph.edge[i].Destination = networkRoutesAvailable[i,1]-1;
                graph.edge[i].Weight = 0;
            }

            for(int i=0; i< numNewNetworkRoutesConstruct; i++)
            {
                graph.edge[i+ numTotalAvailableNetworkRoutes].Source = costNewNetworkRoutesConstruct[i, 0]-1;
                graph.edge[i+ numTotalAvailableNetworkRoutes].Destination = costNewNetworkRoutesConstruct[i, 1]-1;
                graph.edge[i+ numTotalAvailableNetworkRoutes].Weight = costNewNetworkRoutesConstruct[i,2];
            }
          return  Kruskal(graph);
           
        }

        public struct Edge
        {
            public int Source;
            public int Destination;
            public int Weight;
        }

        public struct Graph
        {
            public int VerticesCount;
            public int EdgesCount;
            public Edge[] edge;
        }

        public struct Subset
        {
            public int Parent;
            public int Rank;
        }

        public static Graph CreateGraph(int verticesCount, int edgesCoun)
        {
            Graph graph = new Graph();
            graph.VerticesCount = verticesCount;
            graph.EdgesCount = edgesCoun;
            graph.edge = new Edge[graph.EdgesCount];

            return graph;
        }

        private static int Find(Subset[] subsets, int i)
        {
            if (subsets[i].Parent != i)
                subsets[i].Parent = Find(subsets, subsets[i].Parent);

            return subsets[i].Parent;
        }

        private static void Union(Subset[] subsets, int x, int y)
        {
            int xroot = Find(subsets, x);
            int yroot = Find(subsets, y);

            if (subsets[xroot].Rank < subsets[yroot].Rank)
                subsets[xroot].Parent = yroot;
            else if (subsets[xroot].Rank > subsets[yroot].Rank)
                subsets[yroot].Parent = xroot;
            else
            {
                subsets[yroot].Parent = xroot;
                ++subsets[xroot].Rank;
            }
        }

        private static int Print(Edge[] result, int e)
        {
            int weight = 0;
            for (int i = 0; i < e; ++i)
                weight+= result[i].Weight;
            return weight;
        }

        public static int Kruskal(Graph graph)
        {
            int verticesCount = graph.VerticesCount;
            Edge[] result = new Edge[verticesCount];
            int i = 0;
            int e = 0;

            Array.Sort(graph.edge, delegate (Edge a, Edge b)
            {
                return a.Weight.CompareTo(b.Weight);
            });

            Subset[] subsets = new Subset[verticesCount];

            for (int v = 0; v < verticesCount; ++v)
            {
                subsets[v].Parent = v;
                subsets[v].Rank = 0;
            }

            while (e < verticesCount - 1)
            {
                Edge nextEdge = graph.edge[i++];
                int x = Find(subsets, nextEdge.Source);
                int y = Find(subsets, nextEdge.Destination);

                if (x != y)
                {
                    result[e++] = nextEdge;
                    Union(subsets, x, y);
                }
            }

          return  Print(result, e);
        }


    }
}
