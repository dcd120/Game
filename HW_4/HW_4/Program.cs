// Заривной Николай, дз№4

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4
{
    static public class Program
    {
        static void Main(string[] args)
        {
            var ex = new List<int>();
            ex.Add(1);
            ex.Add(2);
            ex.Add(2);
            ex.Add(3);
            ex.Add(2);
            ex.Add(1);

            Console.WriteLine("result: {0}", ex._FindInt(2));
            Console.WriteLine("result: {0}", ex._FindObj(1));
            Console.WriteLine("result: {0}", ex._FindObjByLinq(3));
            Console.ReadKey();
        }

        // решение для интов
        static public int _FindInt(this List<int> vs, int value)
        {
            int count = 0;
            foreach (int a in vs)
            {
                if (a == value) count++;
            }
            return count;
        }

        // решение для обобщенной коллекции
        static public int _FindObj<T>(this List<T> vs, T obj)
        {
            int count = 0;
            foreach (T e in vs)
            {
                if (e.Equals(obj)) count++;
            }
            return count;
        }

        // решение для обощенной коллекции через linq
        static public int _FindObjByLinq<T>(this List<T> vs, T obj)
        {

            var result = from e in vs
                         where e.Equals(obj)
                         select e;
            return result.Count();
        }
    }
}
