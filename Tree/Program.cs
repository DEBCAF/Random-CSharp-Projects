using System;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree binarytree = new Tree("morning");
            binarytree.insert("apple");
            binarytree.insert("zebra");
            binarytree.search("apple");
            binarytree.in_order_traversal(binarytree.getRoot());
        }
    }
    class Node
    {
        private Node? L;
        private Node? R;
        private string data;
        public Node(string data)
        {
            this.data = data;
        }

        public string getData()
        {
            return data;
        }

        public Node? left()
        {
            return L;
        }
        public Node? right()
        {
            return R;
        }
        public bool Add(string ndata)
        {
            char newstring = ndata[0];
            char oldstring = data[0];
            int newValue = newstring;
            int oldValue = oldstring;
            if (newValue < oldValue)
            {
                if (L == null)
                {
                    L = new Node(ndata);
                    Console.WriteLine($"Added data {ndata} to left node");
                    return true;
                }
                else
                {
                    return L.Add(ndata);
                }
            }
            else if (oldValue <= newValue)
            {
                if (R == null)
                {
                    R = new Node(ndata);
                    Console.WriteLine($"Added data {ndata} to right node");
                    return true;
                }
                else
                {
                    return R.Add(ndata);
                }
            }
            else
            {
                return false;
            } 
        }
        public string Display()
        {
            return ($"Left Node: {L?.getData() ?? "null"} | Right Node: {R?.getData() ?? "null"}");
        }
    }
    class Tree
    {
        private Node root;
        public Tree(string rootData)
        {
            this.root = new Node(rootData);
        }
        public Node getRoot()
        {
            return root;
        }
        public bool insert(string data)
        {
            return root.Add(data);
        }

        public bool search(string data)
        {
            Node? currentnode = root;
            while (currentnode != null)
            {
                if (data == currentnode.getData())
                {
                    Console.WriteLine($"Found data: {data}");
                    return true;
                }
                else
                {
                    char currentstring = currentnode.getData()[0];
                    char searchedstring = data[0];
                    int current = currentstring;
                    int searched = searchedstring;
                    if (searched<current)
                    {
                        currentnode = currentnode.left();
                    }
                    else if (current<=searched)
                    {
                        currentnode = currentnode.right();
                    }
                }
            }
            Console.WriteLine($"Data: {data} not found");
            return false;
        }
        public void in_order_traversal(Node currentnode)
        {
            if (currentnode == null)
            {
                return;
            }
            in_order_traversal(currentnode.left());
            Console.WriteLine(currentnode.getData());
            in_order_traversal(currentnode.right());
        }
    }
}