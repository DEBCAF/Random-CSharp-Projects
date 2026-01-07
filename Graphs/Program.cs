using System;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            Node london = new Node("London");
            Node croydon = new Node("Croydon");
            graph.Link("London", "Croydon", 7);
            graph.Link("London", "Guildford", 30);
            graph.Link("Croydon","",)
        }
    }
    class Node
    {
        private string data;
        private List<NodeWeight> children;
        private struct NodeWeight nw;
        public Node(string data)
        {
            this.data = data;
        }
        public string Get()
        {
            return data;
        }
        public bool Add(Node node, int weight)
        {
            nw.node = node;
            nw.weight = weight;
            children.Add(nw);
            return true;
        }
        public bool Contains(string data)
        {
            for (int i = 0; i < children.count(); i++)
            {
                if (children[i].Get() == data)
                {
                    Console.WriteLine($"Found {data}");
                    return true;
                }
            }
            Console.WriteLine("Cannot find node");
            return false;
        }
        public bool Display()
        {
            Console.WriteLine($"Here are the neighbouring nodes for {data}:");
            for (int i = 0; i < children.count(); i++)
            {
                Console.WriteLine(children[i]);
            }
        }

    }
    struct NodeWeight
    {
        Node node;
        int weight;
    }
    class Graph
    {
        private List<Node> nodes;
        private Node temp;
        public Graph(string data)
        {
        }
        public bool Contains(Node node)
        {
            for (int i = 0; i < nodes.count(); i++)
            {
                if (nodes[0] == node)
                {
                    return true;
                }
            }
            return false;
        }
        public void Link(Node parent, Node child, int weight)
        {
            parent.Add(childnode, weight);
            bool contain = false;
            for (int i = 0; i < nodes.count(); i++)
            {
                if (nodes[0] == parent)
                {
                    contain = true;
                }
            }
            contain = false;
            if (!contain)
            {
                nodes.Add(parent);
            }
            contain = false;
            for (int i = 0; i < nodes.count(); i++)
            {
                if (nodes[0] == child)
                {
                    contain = true;
                }
            }
            contain = false;
            if (!contain)
            {
                nodes.Add(child);
            }
        }
    }
}