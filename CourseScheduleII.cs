using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSchedule
{
    class CourseSchedule
    {
        static void Main(string[] args)
        {
            int[][] preReq = new int[2][];
            for(int i=0;i<preReq.Length;i++)
            {
                preReq[i] = new int[2] { 0, 1 };
               // preReq[i] = i == 0 ? (new int[2] { 0, 1 }): (new int[2] { 1, 0 });
            }

            Console.WriteLine(CanFinish(2, preReq));
            Console.ReadLine();
        }

        // If there is no cycle in the graph, then the courses can be completed
        // While doing DFS, if there is an edge from current node to another node 
        // which is in visiting state and not yet completed, then a cycle exists
        // States are as follows:
        // 0-> not visited, 1-> currently visiting 2->completely visited
        public static bool CanFinish(int numCourses, int[][] prerequisites)
        {
            // Form adjacency list of the given graph
            List<List<int>> adjList = new List<List<int>>();

            for (int i = 0; i < numCourses; i++)
                adjList.Add(new List<int>());
            
            foreach (var a in prerequisites)
                adjList[a[0]].Add(a[1]);

            // Create a visited array for the nodes and change visited status accordingly
            int[] visited = new int[numCourses];

            // Do a DFS on the nodes
            for (int i = 0; i < numCourses; i++)
                if (visited[i] == 0 && !DFS(adjList, visited, i))
                    return false;
            
            return true;
        }

        // Do a DFS on all neighbors of the current node from the adjacency list
        public static bool DFS(List<List<int>> adjList, int[] visited, int v)
        {
            // If current node is in visiting status, that means there is a back edge
            // and hence a cycle. So return false;
            if (visited[v] == 1) return false;

            // Set status of current node to visiting
            visited[v] = 1;

            foreach (var l in adjList[v])
                if (!DFS(adjList, visited, l))
                    return false;

            // Set status of the current node to completed
            visited[v] = 2;
            return true;
        }
    }
}
