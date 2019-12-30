using System;
using System.Collections.Generic;
using System.Text;

namespace ООП12
{
    class user : IComparable<user>
    {
        private int age;
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
        public void Hi(string message)
        {
            Console.WriteLine($"Hi {message}");
        }
        public int CompareTo(user u)
        {
            return this.age.CompareTo(u.age);
        }
        public user ()
        {
            Name = "";
            Age = 0;
        }
        public user(string n, int a)
        {
            Name = n;
            Age = a;
        }
    }
}
