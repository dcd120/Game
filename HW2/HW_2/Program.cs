using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2
{
    class Program
    {
        private static Employer[] _employers;
        private static Random Rnd;
        private static Group it;

        static void Main(string[] args)
        {
            Load();
            View();
            Console.ReadKey();
        }

        private static void Load()
        {
            Rnd = new Random();
            _employers = new Employer[10];
            for (int i = 0; i < _employers.Length / 2; i++)
            {
                _employers[i] = new Employer_month("fn_" + i,"ln_ " + i,Rnd.Next(100,1500));       
            }
            for (int i = _employers.Length / 2; i < _employers.Length; i++)
            {
                _employers[i] = new Employer_time("fn_" + i, "ln_ " + i, Rnd.Next(1, 10));
            }
            // создадим элемент класса и заполним его из ранее созданного массива
            it = new Group();
            foreach (Employer emp in _employers)
            {
                it.Add(emp);
            }

        }

        private static void View()
        {
            Array.Sort(_employers);
            foreach (Employer Emp in _employers)
            {
                Console.WriteLine(" " + Emp.GetType() + " - " + Emp.salary());
            }
            // продемонстрируем работу класса Group через foreach
            // до сортировки
            foreach (Employer Emp in it)
            {
                Console.WriteLine($" - " + Emp.salary());
            }
        }
    }
}
