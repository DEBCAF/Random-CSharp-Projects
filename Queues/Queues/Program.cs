using System;

namespace Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            string? name = "name";
            Kiu names = new Kiu(4);
            while (true)
            {
                Console.Write("ok go now: ");
                name = Console.ReadLine();
                if (string.IsNullOrEmpty(name)) break;
                bool can = names.enkiu(name);
                if (can == false)
                {
                    Console.WriteLine("Queue is full");
                    break;
                }
            }
            for (int i = 0; i<names.getsize(); i++)
            {
                Console.WriteLine(names.dekiu());
                Console.Write("ok rewrite now: ");
                string? choice = Console.ReadLine();
                names.enkiu(choice);
            }
        }
    }
    class Kiu
    {
        private string[] names;
        private int head;
        private int tail;
        private int maxsize;
        private int size;
        public Kiu(int maxsize)
        {
            this.maxsize = maxsize;
            names = new string[maxsize];
            head = 0;
            tail = 0;
            size = 0;
        }

        public bool enkiu(string? name)
        {
            if (name is null) return false;
            if (size >= maxsize)
            {
                return false; 
            }
            else
            {
                names[tail] = name;
                tail = (tail+1)%maxsize;
                size += 1;
                return true;
            }
        }
        public string dekiu()
        {
            if (size <= 0)
            {
                return ("Cannot dequeue");
            }
            else 
            {
                string value = names[head];
                head = (head+1)%maxsize;
                size -= 1;
                return value;
            }
        }
        public int getsize()
        {
            return size;
        }
    }
}