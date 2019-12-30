using System;
using System.Collections.Generic;
using System.Text;

namespace ООП9
{
    class User
    {
        public delegate void UserUpgrade(string i);
        public delegate int UserWork(int i);
        public event UserUpgrade Upgrade;
        public event UserWork Work;
        private string job;
        public string Job
        {
            get {  return job; }
            set { job = value; }
        }
        private int time;
        public int Time
        {
            get { return time; }
            set { time = value; }
        }
        public void Update (string str)
        {
            Job = str;
            Upgrade.Invoke($"Работаю над [{this.Job}]");
        }
        public void TimeWorking(int i)
        {
            Time = Work.Invoke(i);
            Console.WriteLine($"Работаю: {Time} часов");
        }
        public User()
        {
            Job = "";
            Time = 0;
        }
    }

}
