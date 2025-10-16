using System;
using System.Security.Cryptography;
using System.Text;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            string? name = "name";
            Console.WriteLine(name.GetHashCode());
        }
    }
}