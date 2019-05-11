using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mem_allocaton
{
    class process
    {
        public string process_name;
        public int number_of_SG;
        public IList<sgment> list_SG = new List<sgment>();
    }
}
