
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
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

        BFS(A, I);
    }

    static void BFS(Node start, Node target)
    {
        HashSet<Node> checkedNodes = new HashSet<Node>();
        Queue<Node> queue = new Queue<Node>();

        HashSet<Node> discovered = new HashSet<Node>();

        queue.Enqueue(start);
        discovered.Add(start);

        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();

            checkedNodes.Add(current);

            Console.WriteLine(current.Data);

            if (current == target)
            {
                Console.WriteLine("Target found!");
                break;
            }

            foreach (Node next in current.Edges)
            {
                if (!discovered.Contains(next))
                {
                    queue.Enqueue(next);
                    discovered.Add(next);
                }
            }
        }
    }
}
