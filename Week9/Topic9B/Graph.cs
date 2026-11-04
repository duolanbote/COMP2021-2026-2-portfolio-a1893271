using System.Collections.Generic;

public class Graph
{
    public List<Node> Nodes { get; set; }

    public Graph()
    {
        Nodes = new List<Node>();
    }

    public void AddEdge(Node fromNode, Node toNode, int weight)
    {
        if (!Nodes.Contains(fromNode))
        {
            Nodes.Add(fromNode);
        }

        if (!Nodes.Contains(toNode))
        {
            Nodes.Add(toNode);
        }

        fromNode.Edges[toNode] = weight;
        toNode.Edges[fromNode] = weight;
    }

    public override string ToString()
    {
        string result = "";

        foreach (Node node in Nodes)
        {
            result += node.Data + ": ";

            foreach (KeyValuePair<Node, int> edge in node.Edges)
            {
                result += edge.Key.Data + "(" + edge.Value + ") ";
            }

            result += "\n";
        }

        return result;
    }
}
