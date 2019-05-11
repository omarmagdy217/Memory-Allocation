using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mem_allocaton
{
    class holes
    {
        public int name;
        public int Base;
        public int size;
        // public int remain_size;

        public holes(int n, int s)
        {
            Base = n;
            size = s;
        }
        public holes()
        {

        }
    }
}
