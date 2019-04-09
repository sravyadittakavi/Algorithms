using System;
using System.Collections.Generic;

namespace GraphBFSTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph newGraph = new Graph(5);
            newGraph.AddEdge(0, 1);
            newGraph.AddEdge(0, 4);
            newGraph.AddEdge(1, 0);
            newGraph.AddEdge(1, 2);
            newGraph.AddEdge(1, 3);
            newGraph.AddEdge(1, 4);
            newGraph.AddEdge(2, 1);
            newGraph.AddEdge(2, 3);
            newGraph.AddEdge(3, 1);
            newGraph.AddEdge(3, 2);
            newGraph.AddEdge(3, 4);
            newGraph.AddEdge(4, 0);
            newGraph.AddEdge(4, 1);
            newGraph.AddEdge(4, 3);

            Console.WriteLine("BFS traversal starting at node 1 is ");
            newGraph.BFS(1);

            Console.WriteLine();
            Console.WriteLine("DFS traversal starting at node 1 is ");
            newGraph.DFS(1);

            Graph dg = new Graph(6);
          
            dg.AddEdge(2, 3);
            dg.AddEdge(3, 1);
            dg.AddEdge(4, 1);
            dg.AddEdge(4, 0);
            dg.AddEdge(5, 2);
            dg.AddEdge(5, 0);

            Console.WriteLine();
            Console.WriteLine("Topological sort ");
            dg.TopologicalSort();

            Console.Read();
        }
    }

    public class Graph
    {
        public int NumberOfVertices;
        public Dictionary<int, List<int>> AdjList;

        public Graph(int v)
        {
            NumberOfVertices = v;
            AdjList = new Dictionary<int, List<int>>();
            for(int i=0;i< v; i++)
            {
                AdjList[i] = new List<int>();
            }
        }

        public void AddEdge(int v, int w)
        {
            AdjList[v].Add(w);
        }

        public void BFS(int s)
        {
            bool[] visited = new bool[NumberOfVertices];

            Queue<int> visitedQueue = new Queue<int>();
            visitedQueue.Enqueue(s);
            visited[s] = true;

            while(visitedQueue.Count != 0)
            {
                int num = visitedQueue.Dequeue();
                Console.Write(num+" ");

                int counter = 0;
                while(counter < AdjList[num].Count)
                {
                    int currentItem = AdjList[num][counter];
                    if (!visited[currentItem])
                    {
                        visitedQueue.Enqueue(currentItem);
                        visited[currentItem] = true;
                    }
                    counter++;
                }
            }
        }

        public void DFS(int s)
        {
            bool[] visited = new bool[NumberOfVertices];
            for(int i = 0; i < NumberOfVertices; i++)
            {
                visited[i] = false;
            }

            DFSUtil(s, visited);
        }

        private void DFSUtil(int v, bool[] visited)
        {
            Console.Write(v + " ");
            visited[v] = true;

            int counter = 0;
            while (counter < AdjList[v].Count)
            {
                int currentItem = AdjList[v][counter];
                if (!visited[currentItem])
                {
                    DFSUtil(currentItem, visited);
                }
                counter++;
            }
        }

        public void TopologicalSort()
        {
            bool[] visited = new bool[NumberOfVertices];
            Stack<int> tStack = new Stack<int>();
            for (int i = 0; i < NumberOfVertices; i++)
            {
                visited[i] = false;
            }

            for (int i = 0; i < NumberOfVertices; i++)
            {
                if (visited[i] == false)
                {
                    TopologicalSortUtil(i, visited, tStack);
                }
            }
            
            while (tStack.Count != 0)
            {
                Console.Write(tStack.Peek() + " ");
                tStack.Pop();
            }
        }

        public void TopologicalSortUtil(int v, bool[] visited, Stack<int> tStack)
        {
            visited[v] = true;

            int counter = 0;
            while (counter < AdjList[v].Count)
            {
                int currentItem = AdjList[v][counter];
                if (!visited[currentItem])
                {
                    TopologicalSortUtil(currentItem, visited, tStack);
                }
                counter++;
            }
            tStack.Push(v);
        }
    }
}
