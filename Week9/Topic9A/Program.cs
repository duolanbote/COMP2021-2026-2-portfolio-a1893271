using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Graph graph = BuildGraph();
        Dictionary<string, Node> nodes = Index(graph);

        Console.WriteLine("Graph:");
        Console.WriteLine(graph);

        Console.WriteLine("BFS on the initial graph:");
        BFS(nodes["A"], nodes["I"]);

        // G - H and H - I, the adjusted graph for task 2
        graph.AddEdge(nodes["G"], nodes["H"]);
        graph.AddEdge(nodes["H"], nodes["I"]);

        Console.WriteLine("Adjusted graph:");
        Console.WriteLine(graph);

        Console.WriteLine("BFS on the adjusted graph:");
        BFS(nodes["A"], nodes["I"]);

        Graph graph2 = BuildGraph();
        Dictionary<string, Node> nodes2 = Index(graph2);

        Console.WriteLine("DFS on the initial graph:");
        DFS(nodes2["A"], nodes2["I"]);

        // D - E - F and F - H - I, the adjusted graph for task 3
        graph2.AddEdge(nodes2["D"], nodes2["E"]);
        graph2.AddEdge(nodes2["E"], nodes2["F"]);
        graph2.AddEdge(nodes2["F"], nodes2["H"]);
        graph2.AddEdge(nodes2["H"], nodes2["I"]);
        graph2.AddEdge(nodes2["G"], nodes2["H"]);

        Console.WriteLine("Adjusted graph:");
        Console.WriteLine(graph2);

        Console.WriteLine("DFS on the adjusted graph:");
        DFS(nodes2["A"], nodes2["I"]);
    }

    static Graph BuildGraph()
    {
        Graph graph = new Graph();

        Node A = new Node("A");
        Node B = new Node("B");
        Node C = new Node("C");
        Node D = new Node("D");
        Node E = new Node("E");
        Node F = new Node("F");
        Node G = new Node("G");
        Node H = new Node("H");
        Node I = new Node("I");

        graph.AddEdge(A, B);
        graph.AddEdge(A, C);
        graph.AddEdge(B, D);
        graph.AddEdge(B, E);
        graph.AddEdge(C, F);
        graph.AddEdge(D, G);
        graph.AddEdge(E, H);
        graph.AddEdge(F, I);

        return graph;
    }

    static Dictionary<string, Node> Index(Graph graph)
    {
        Dictionary<string, Node> nodes = new Dictionary<string, Node>();

        foreach (Node node in graph.Nodes)
        {
            nodes[node.Data] = node;
        }

        return nodes;
    }

    static void BFS(Node start, Node target)
    {
        List<Node> checkedNodes = new List<Node>();
        Dictionary<Node, Node?> parents = new Dictionary<Node, Node?>();
        Queue<Node> queue = new Queue<Node>();

        queue.Enqueue(start);
        parents[start] = null;

        bool found = false;

        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();

            if (current == target)
            {
                found = true;
                break;
            }

            checkedNodes.Add(current);

            foreach (Node next in current.Edges)
            {
                if (checkedNodes.Contains(next) || parents.ContainsKey(next))
                {
                    continue;
                }

                parents[next] = current;
                queue.Enqueue(next);
            }
        }

        Console.WriteLine("Checked: " + string.Join(", ", checkedNodes.ConvertAll(node => node.Data)));

        if (found)
        {
            Console.WriteLine("Path: " + BuildPath(parents, target));
        }
        else
        {
            Console.WriteLine("Target not found");
        }

        Console.WriteLine();
    }

    static void DFS(Node start, Node target)
    {
        List<Node> checkedNodes = new List<Node>();
        Dictionary<Node, Node?> parents = new Dictionary<Node, Node?>();
        Stack<Node> stack = new Stack<Node>();

        stack.Push(start);
        parents[start] = null;

        bool found = false;

        while (stack.Count > 0)
        {
            Node current = stack.Pop();

            if (current == target)
            {
                found = true;
                break;
            }

            checkedNodes.Add(current);

            foreach (Node next in current.Edges)
            {
                if (checkedNodes.Contains(next) || parents.ContainsKey(next))
                {
                    continue;
                }

                parents[next] = current;
                stack.Push(next);
            }
        }

        Console.WriteLine("Checked: " + string.Join(", ", checkedNodes.ConvertAll(node => node.Data)));

        if (found)
        {
            Console.WriteLine("Path: " + BuildPath(parents, target));
        }
        else
        {
            Console.WriteLine("Target not found");
        }

        Console.WriteLine();
    }

    static string BuildPath(Dictionary<Node, Node?> parents, Node target)
    {
        List<string> path = new List<string>();
        Node? node = target;

        while (node != null)
        {
            path.Add(node.Data);
            node = parents[node];
        }

        path.Reverse();

        return string.Join(" -> ", path);
    }
}
