using System;
using System.Reflection;
namespace ООП12
{
    class Program
    {
        static void Main(string[] args)
        {
            user u1 = new user("Вова",19);
            library.ToFile(typeof(user));
            library.Runtimemethod(typeof(user), "Hi");
        }
    }
}
