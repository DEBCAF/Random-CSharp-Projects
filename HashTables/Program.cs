using System;
using System.Security.Cryptography;
using System.Text;

namespace HashTables
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable hashTable = new HashTable();
            User user1 = new User("test@test.com", "John", "Smith");
            User user2 = new User("test2@test.com", "Lyndon", "Johnson");
            hashTable.Add(user1);
            hashTable.Add(user2);
        }
    }
    class User
    {
        public string email;
        public string first_name;
        public string last_name;

        public User(string email, string first_name, string last_name)
        {
            this.email = email;
            this.first_name = first_name;
            this.last_name = last_name;
        }

        public string GetHash()
        {
            return email.GetHashCode().ToString();
        }
    }
    class HashTable
    {
        private User[] users;
        private int size;

        public HashTable()
        {
            this.size = 10;
            users = new User[size];
        }

        public bool Add(User user)
        {
            string hash = user.GetHash();
            int index = int.Parse(hash) % size;
            if (users[index] == null)
            {
                users[index] = user;
                return true;
            }
            return false;
        }

        public bool Remove(User user)
        {
            string hash = user.GetHash();
            int index = int.Parse(hash) % size;
        }

        public bool Contains(User user)
        {
            string hash = user.GetHash();
            int index = int.Parse(hash) % size;
            return users[index] != null;
        }
    }
}