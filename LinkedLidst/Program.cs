using System;
namespace LinkedLidst
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
    class LinkedLidst
    {
        private struct Node
        {
            public string Data;
            public int Next; 
        }

        private int maxSize;
        private int size;
        private Node[] nodes;
        private int start; 
        private int free;  

        public LinkedLidst(int maxSize)
        {
            this.maxSize = maxSize;
            nodes = new Node[maxSize];
            start = -1;
            free = 0;
            for (int i = 0; i < maxSize; i++)
            {
                if (i == maxSize - 1)
                {
                    nodes[i].Next = -1;
                }
                else 
                {
                    nodes[i].Next = i + 1;
                }
                nodes[i].Data = "";
            }
        }

        public bool IsFull()
        {
            if (size == maxSize)
            {
                return true;
            }
            return false;
        }

        public bool IsEmpty()
        {
            if (size == 0)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        private int AllocateNode()
        {
            if (free == -1) 
            {
                return -1;
            }
            int index = free;
            free = nodes[free].Next;
            return index;
        }

        private void FreeNode(int index)
        {
            nodes[index].Next = free;
            free = index;
        }

        public bool Add(string value)
        {
            if (IsFull()) 
            {
                return false;
            }
            int index = AllocateNode();
            if (index == -1) 
            {
                return false;
            }
            nodes[index].Data = value;
            nodes[index].Next = -1;

            if (start == -1)
            {
                start = index;
            }
            else
            {
                int current = start;
                while (nodes[current].Next != -1)
                {
                    current = nodes[current].Next;
                }
                nodes[current].Next = index;
            }
            size += 1;
            return true;
        }

        public bool Delete()
        {
            if (IsEmpty()) 
            {
                return false;
            }
            int oldHead = start;
            start = nodes[oldHead].Next;
            size -= 1;
            FreeNode(oldHead);
            return true;
        }
        public bool DeleteByValue(string value)
        {
            if (IsEmpty()) 
            {
                return false;
            }
            if (nodes[start].Data == value)
            {
                return Delete();
            }

            int previous = start;
            int current = nodes[start].Next;
            while (current != -1)
            {
                if (nodes[current].Data == value)
                {
                    nodes[previous].Next = nodes[current].Next;
                    size -= 1;
                    FreeNode(current);
                    return true;
                }
                previous = current;
                current = nodes[current].Next;
            }

            return false;
        }

        public int Size()
        {
            return size;
        }

        public bool Contains(string value)
        {
            int current = start;
            while (current != -1)
            {
                if (nodes[current].Data == value) 
                {
                    return true;
                }
                current = nodes[current].Next;
            }
            return false;
        }
        public void Clear()
        {
            if (start != -1)
            {
                int current = start;
                while (current != -1)
                {
                    int next = nodes[current].Next;
                    FreeNode(current);
                    current = next;
                }
            }
            start = -1;
            size = 0;
        }
    }
}