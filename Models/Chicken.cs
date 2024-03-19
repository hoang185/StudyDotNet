using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Models
{
    public class Chicken
    {
        public string Name { get; set; }
        public string DOB { get; set; }
        public int Age { get; set; }
        public Chicken GetClone()
        {
            return (Chicken)this.MemberwiseClone();
        }
    }
}
