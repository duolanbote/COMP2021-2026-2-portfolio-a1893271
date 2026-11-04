using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Graph graph = new Graph();

        Node start = new Node("Start");
        Node a = new Node("A");
        Node b = new Node("B (BEES)");
        Node c = new Node("C");
        Node d = new Node("D (BEES)");
        Node e = new Node("E (BEES)");
        Node f = new Node("F");
        Node g = new Node("G");
        Node h = new Node("H");
        Node i = new Node("I (BEES)");
        Node j = new Node("J (BEES)");
        Node k = new Node("K");
        Node l = new Node("L");
        Node m = new Node("M");
        Node n = new Node("N");
        Node end = new Node("End");

        graph.AddEdge(start, a, 1);
        graph.AddEdge(start, b, 5);
        graph.AddEdge(start, d, 5);
        graph.AddEdge(a, c, 1);
        graph.AddEdge(b, e, 5);
        graph.AddEdge(d, c, 5);
        graph.AddEdge(d, e, 5);
        graph.AddEdge(d, g, 5);
        graph.AddEdge(e, h, 5);
        graph.AddEdge(c, f, 1);
        graph.AddEdge(g, f, 1);
        graph.AddEdge(g, h, 1);
        graph.AddEdge(g, j, 1);
        graph.AddEdge(f, i, 5);
        graph.AddEdge(h, k, 1);
        graph.AddEdge(j, i, 5);
        graph.AddEdge(j, k, 5);
        graph.AddEdge(j, m, 5);
        graph.AddEdge(i, l, 5);
        graph.AddEdge(k, n, 1);
        graph.AddEdge(m, l, 1);
        graph.AddEdge(m, n, 1);
        graph.AddEdge(l, end, 1);

        Node target = end;

        Dictionary<Node, int> distanceList = new Dictionary<Node, int>();

        foreach (Node node in graph.Nodes)
        {
            distanceList[node] = int.MaxValue;
        }

        distanceList[start] = 0;

        PriorityQueue<Node, int> priorityQueue = new PriorityQueue<Node, int>();
        Dictionary<Node, Node?> parents = new Dictionary<Node, Node?>();

        parents[start] = null;
        priorityQueue.Enqueue(start, 0);

        while (priorityQueue.Count > 0)
        {
            Node current = priorityQueue.Dequeue();

            if (current == target)
            {
                break;
            }

            foreach (KeyValuePair<Node, int> neighbour in current.Edges)
            {
                int totalDistance = distanceList[current] + neighbour.Value;

                if (totalDistance < distanceList[neighbour.Key])
                {
                    distanceList[neighbour.Key] = totalDistance;
                    parents[neighbour.Key] = current;
                    priorityQueue.Enqueue(neighbour.Key, totalDistance);
                }
            }
        }

        List<string> path = new List<string>();
        Node? nodeInPath = target;

        while (nodeInPath != null)
        {
            path.Add(nodeInPath.Data);
            nodeInPath = parents[nodeInPath];
        }

        path.Reverse();

        Console.WriteLine("Path: " + string.Join(" -> ", path));
        Console.WriteLine("Distance: " + distanceList[target]);
    }
}
