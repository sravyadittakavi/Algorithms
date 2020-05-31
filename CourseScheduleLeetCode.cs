public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
    if (prerequisites.Length == 0)
      return true; // no cycle could be formed in empty graph.

    // course -> list of next courses
    Dictionary<int, GNode> graph = new Dictionary<int, GNode>();

    // build the graph first
    foreach (int[] relation in prerequisites) {
      // relation[1] -> relation[0]
      GNode prevCourse = this.GetCreateGNode(graph, relation[1]);
      GNode nextCourse = this.GetCreateGNode(graph, relation[0]);

      prevCourse.outNodes.Add(relation[0]);
      nextCourse.inDegrees += 1;
    }

    // We start from courses that have no prerequisites.
    int totalDeps = prerequisites.Length;
    Stack<int> nodepCourses = new Stack<int>();
    foreach (var entry in graph) {
      GNode node = entry.Value;
      if (node.inDegrees == 0)
        nodepCourses.Push(entry.Key);
    }

    int removedEdges = 0;
    while (nodepCourses.Count > 0) {
      int course = nodepCourses.Pop();

      foreach (int nextCourse in graph[course].outNodes) {
        GNode childNode = graph[nextCourse];
        childNode.inDegrees -= 1;
        removedEdges += 1;
        if (childNode.inDegrees == 0)
          nodepCourses.Push(nextCourse);
      }
    }

    if (removedEdges != totalDeps)
      // if there are still some edges left, then there exist some cycles
      // Due to the dead-lock (dependencies), we cannot remove the cyclic edges
      return false;
    else
      return true;
  }

  /**
   * Retrieve the existing <key, value> from graph, otherwise create a new one.
   */
   private GNode GetCreateGNode(Dictionary<int, GNode> graph, int course) {
    GNode node = null;
    if (graph.ContainsKey(course)) {
      node = graph[course];
    } else {
      node = new GNode();
      graph.Add(course, node);
    }
    return node;
  }

}

 public class GNode {
  public int inDegrees = 0;
  public List<int> outNodes = new List<int>();
}