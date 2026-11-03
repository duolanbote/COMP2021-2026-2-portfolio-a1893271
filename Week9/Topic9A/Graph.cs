
using System.Collections.Generic;

public class Graph
{
    public List<Node> Nodes { get; set; }

    public Graph()
    {
        Nodes = new List<Node>();
    }

    public void AddEdge(Node fromNode, Node toNode)
    {
        if (!Nodes.Contains(fromNode))
        {
            Nodes.Add(fromNode);
        }

        if (!Nodes.Contains(toNode))
        {
            Nodes.Add(toNode);
        }

        if (!fromNode.Edges.Contains(toNode))
        {
            fromNode.Edges.Add(toNode);
        }

        if (!toNode.Edges.Contains(fromNode))
        {
            toNode.Edges.Add(fromNode);
        }
    }

    public override string ToString()
    {
        string result = "";

        foreach (Node node in Nodes)
        {
            result += node.Data + ": ";

            foreach (Node edge in node.Edges)
            {
                result += edge.Data + " ";
            }

            result += "\n";
        }

        return result;
    }
}
