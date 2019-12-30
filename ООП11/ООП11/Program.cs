using System;
using System.Collections.Generic;
using System.Linq;

namespace ООП11
{
    class student: IComparable<student>
    {
        public string name;
        public string faculty;
        public int exam;
        public int CompareTo(student a)
        {
            return this.faculty.CompareTo(a.faculty);
        }
    }
    class decan : IComparable<decan>
    {
        public string name;
        public string faculty;
        public int CompareTo(decan a)
        {
            return this.faculty.CompareTo(a.faculty);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] months = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
            string[] mass = { "Январь", "Февраль", "Июнь", "Июль", "Август", "Декабрь" };
            int n = 6;
            var query1 = from p in months
                       where p.Length == n
                       select p;
            foreach (string s in query1)
                Console.WriteLine(s);
            var query10 = months.Intersect<string>(mass);
            foreach (string s in query10)
                Console.WriteLine(s+".");
            var query11 = from p in months
                          orderby p
                          select p;
            foreach (string s in query11)
                Console.WriteLine(s + "/");
            var query2 = from p in months
                         where p.Length >= 4 & p.Contains("ь")
                         select p;
            foreach (string s in query2)
                Console.WriteLine(s);
            List<Train> t = new List<Train>();
            t.Add(new Train() { H = 12, M = 12, Time = "утро"});
            t.Add(new Train() { H = 9, M = 12, Time = "обед" });
            t.Add(new Train() { H = 1, M = 52, Time = "утро" });
            t.Add(new Train() { H = 22, M = 12, Time = "ночь" });
            int k = 9;
            var query6 = from p in t
                        where p.H == k
                        select p;
            foreach (Train q in query6)
                Console.WriteLine(q.ToString());
            var query7 = from Train in t
                         group Train by Train.Time;
            foreach (IGrouping<string, Train> c in query7)
            {
                Console.WriteLine(c.Key);
                foreach (Train q in c)
                    Console.WriteLine(q.ToString());
            }
            Train query8 = t.Min();
                Console.WriteLine(query8.ToString());
            var query9 = from Train in t
                         orderby Train.H
                         select Train.H;
            foreach (int s in query9)
                Console.WriteLine(s);
            student[] st = new student[] { new student{name = "Вова", faculty="FIT",exam=5 }, new student { name = "Даня", faculty = "PIM", exam =9 }, new student { name = "Ваня", faculty = "FIT", exam = 10 } };
            decan[] dec = new decan[] { new decan { name = "Шиман", faculty = "FIT"}, new decan { name = "noname", faculty = "PIM"}};
            var ss = from student in st
                     group student by student.faculty into studentgroup
                     select new { Group = studentgroup.Key, count = studentgroup.Count() };
            foreach (var s in ss)
            {
                Console.WriteLine(s.Group + "-" + s.count);
            }
            var jn = from s in st
                     join d in dec on s.faculty equals d.faculty
                     select new { decanName = d.name, facultyName = d.faculty, studentName = s.name };
            foreach (var j in jn)
                Console.WriteLine(j.decanName+" "+j.facultyName +" "+j.studentName);
        }
    }
}
