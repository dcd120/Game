using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2
{
    // класс описывает группу сотрудников (отдел)
    class Group: IEnumerable
    {
        public List<Employer> _empl;

        public Group()
        {
            _empl = new List<Employer>();
        }

        public void Add(Employer new_empl)
        {
            _empl.Add(new_empl);

        }

        public IEnumerator GetEnumerator()
        {
            foreach (Employer Empl in _empl)
            {
                yield return Empl;
            }
        }
    }
}
