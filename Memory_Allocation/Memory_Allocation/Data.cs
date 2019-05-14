﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory_Allocation
{
    public struct Hole
    {
        public int num;
        public int start;
        public int size;
    };

    public struct Segment
    {
        public string sg_name;
        public int sg_size;
    };

   public class Process
    {
        public string name;
        public int sg_num;
        public Segment[] sgmnt;
        private int count;

        public void sg_alloc()
        {
            sgmnt = new Segment[sg_num];
            count = 0;
        }

        public void Add_SG(Segment sg)
        {
            sgmnt[count] = sg;
            count++;
        }
    }
}
