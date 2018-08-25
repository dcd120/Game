using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2
{
    abstract class Employer: IComparable
    {
        protected string first_name;
        protected string last_name;
        public double payment;

        protected Employer(string f_name, string l_name, double pay)
        {
            first_name = f_name;
            last_name = l_name;
            payment = pay;
        }

        public int CompareTo(object obj)
        {
            return (salary() > (obj as Employer).salary()) ? 1 : -1;   
        }

        abstract public double salary();
    }
}
