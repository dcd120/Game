using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2
{
    class Employer_time : Employer
    {

        public Employer_time(string f_name, string l_name, double pay) : base(f_name, l_name, pay)
        {

        }

        public override double salary()
        {
            return this.payment * 20.8 * 8;
        }
    }
}
