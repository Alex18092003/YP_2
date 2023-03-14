using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YP_2
{
    public partial class Employees
    {
        public string FIO
        {
            get
            {
                return surname + " " + name + " " + patrinymic;
            }
        }

       

    }
}
