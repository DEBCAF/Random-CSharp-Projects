using System;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Node first = new Node('M');
            first.Add('B');
            first.Add('X');
        }
    }
    class Node
    {
        private Node? L;
        private Node? R;
        private char data;
        public Node(char data)
        {
            this.data = data;
        }

        public char getData()
        {
            return data;
        }
        public bool Add(char ndata)
        {
            int n = ndata;
            int o = data;
            if (ndata<data)
            {
                L = new Node(ndata);
                Console.WriteLine($"Added data {ndata} to left node");
                return true;
            }
            else if (data<ndata)
            {
                R = new Node(ndata);
                Console.WriteLine($"Added data {ndata} to right node");
                return true;
            }
            else
            {
                return false;
            } 
        }
        public string Display()
        {
            return ($"Left Node: {L.getData()} | Right Node: {R.getData()}");
        }
    }
}