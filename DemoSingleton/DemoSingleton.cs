using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.DemoSingleton
{
    public class DemoSingleton
    {
        private static DemoSingleton? _instance;
        private int _id;

        private int Id
        {
            get => _id;
            set => _id = value;
        }

        private DemoSingleton()
        {
            Console.WriteLine("constructor");
        }

        public static DemoSingleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DemoSingleton();
            }
            return _instance;
        }

        public void AddDays(int days)
        {
            Id += days;
        }

        public void SubtractDays(int days)
        {
            Id -= days;
        }
    }
}
