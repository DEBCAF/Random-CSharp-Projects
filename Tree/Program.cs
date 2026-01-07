using System;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree binarytree = new Tree("dawn");
            binarytree.insert("dave");
            binarytree.insert("beth");
            binarytree.insert("david");
            binarytree.insert("cindi");
            binarytree.insert("mike");
            binarytree.insert("gina");
            binarytree.insert("pat");
            binarytree.insert("sue");
            Console.WriteLine("In order traversal:");
            binarytree.in_order_traversal(binarytree.getRoot());
            Console.WriteLine("Post order traversal:");
            binarytree.post_order_traversal(binarytree.getRoot());
            binarytree.delete("mike");
            Console.WriteLine("In order traversal:");
            binarytree.in_order_traversal(binarytree.getRoot());
            Console.WriteLine("Post order traversal:");
            binarytree.post_order_traversal(binarytree.getRoot());
        }
    }
    class Node
    {
        private Node? L;
        private Node? R;
        private string? data;
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
        public bool Set(string data)
        {
            this.data = data;
            return true;
        }
        public bool Add(string ndata)
        {
            int count = 0;
            while (true)
            {
                char newstring = ndata[count];
                char oldstring = data[count];
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
                else if (oldValue < newValue)
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
                    count += 1;
                } 
            }
        }
        public string Display()
        {
            return ($"Left Node: {L?.getData() ?? "null"} | Right Node: {R?.getData() ?? "null"}");
        }
        public bool Delete()
        {
            this.data = null;
            this.L = null;
            this.R = null;
            return true;
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
            if (currentnode != null)
            {
                in_order_traversal(currentnode.left());
                Console.WriteLine(currentnode.getData());
                in_order_traversal(currentnode.right());
            }
        }
        public void post_order_traversal(Node currentnode)
        {
            if (currentnode != null)
            {
                post_order_traversal(currentnode.left());
                post_order_traversal(currentnode.right());
                Console.WriteLine(currentnode.getData());
            }
        }
        public bool delete(string data)
        {
            if (!search(data))
            {
                return false;
            }
            Node? currentnode = root;
            Node? previousnode = null;
            Node? deletenode;
            while (currentnode != null)
            {
                if (data == currentnode.getData())
                {
                    Console.WriteLine($"Found data: {data}");
                    break;
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
            deletenode = currentnode;
            currentnode = currentnode.left();
            while (currentnode != null)
            {
                previousnode = currentnode;
                currentnode = currentnode.right();
            }
            if (previousnode != null)
            {
                deletenode.Set(previousnode.getData());
                previousnode.Delete();
            }
            Console.WriteLine($"Deleted: {data}");
            return true;
        }
    }
}