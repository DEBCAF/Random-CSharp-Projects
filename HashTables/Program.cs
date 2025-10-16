using System;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;

namespace HashTables
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable hashTable = new HashTable(10);
            User user1 = new User("test@test.com", "John", "Smith");
            User user2 = new User("test2@test.com", "Lyndon", "Johnson");
            hashTable.Add(user1);
            hashTable.Add(user2);
            Console.WriteLine(hashTable.Contains(user1));
            Console.WriteLine(hashTable.Contains(user2));
        }
    }
    class User
    {
        private string email;
        private string first_name;
        private string last_name;
        private int hash;

        public User(string email, string first_name, string last_name)
        {
            this.email = email;
            this.first_name = first_name;
            this.last_name = last_name;
        }

        public string GetHash()
        {
            hash = email.GetHashCode();
            if (hash < 0)
            {
                hash = -hash;
            }
            return hash.ToString();
        }

        public string GetEmail()
        {
            return email;
        }

        public string GetFirstName()
        {
            return first_name;
        }

        public string GetLastName()
        {
            return last_name;
        }
    }
    class HashTable
    {
        private List<User>[] users;
        private int size;

        public HashTable(int size)
        {
            this.size = size;
            users = new List<User>[size];
            for (int i = 0; i < size; i++)
            {
                users[i] = new List<User>();
            }
        }

        public bool Add(User user)
        {
            string hash = user.GetHash();
            int index = int.Parse(hash) % size;
            foreach (User existing in users[index])
            {
                if (existing.GetEmail() == user.GetEmail())
                {
                    return false;
                }
            }
            users[index].Add(user);
            return true;
        }

        public bool Remove(User user)
        {
            string hash = user.GetHash();
            int index = int.Parse(hash) % size;
            for (int i = 0; i < users[index].Count; i++)
            {
                if (users[index][i].GetEmail() == user.GetEmail())
                {
                    users[index].RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public bool Contains(User user)
        {
            string hash = user.GetHash();
            int index = int.Parse(hash) % size;
            foreach (User existing in users[index])
            {
                if (existing.GetEmail() == user.GetEmail())
                {
                    return true;
                }
            }
            return false;
        }
    }
}