using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory_Allocation
{
    class Memory_OP
    {
        private static Stack<int> Removed_Holes = new Stack<int>();
        private static Segment sg_temp;
        private static Hole hole_temp;

        static public void Reset()
        {
            Removed_Holes.Clear();
        }

        static public bool Mem_Alloc(Process PS, ref IList<Hole> Hole_List, char mt, SortedList<int, Segment> Memory)
        {
            bool fit;
            if (mt == 'F')
                Hole_List = Hole_List.OrderBy(a => a.start).ToList();
            for (int i = 0; i < PS.sg_num; i++)
            {
                fit = false;
                if (mt == 'B')
                    Hole_List = Hole_List.OrderBy(a => a.size).ToList();
                else if (mt == 'W')
                    Hole_List = Hole_List.OrderByDescending(a => a.size).ToList();
                for (int j = 0; j < Hole_List.Count; j++)
                {
                    if (Hole_List[j].size >= PS.sgmnt[i].sg_size)
                    {
                        fit = true;
                        sg_temp.sg_name = PS.sgmnt[i].sg_name;
                        sg_temp.sg_size = PS.sgmnt[i].sg_size;
                        Memory[Hole_List[j].start] = sg_temp;
                        sg_temp.sg_size = Hole_List[j].size - PS.sgmnt[i].sg_size;
                        if (sg_temp.sg_size == 0)
                        {
                            Removed_Holes.Push(Hole_List[j].num);
                            Hole_List.RemoveAt(j);
                        }
                        else
                        {
                            sg_temp.sg_name = "Hole " + Hole_List[j].num.ToString();
                            hole_temp.num = Hole_List[j].num;
                            hole_temp.start = Hole_List[j].start + PS.sgmnt[i].sg_size;
                            hole_temp.size = sg_temp.sg_size;
                            Hole_List[j] = hole_temp;
                            Memory.Add(hole_temp.start, sg_temp);
                        }
                        break;
                    }
                }
                if (!fit)
                    return false;
            }
            return true;
        }

        static public void DeAlloc(Process PS, ref IList<Hole> Hole_List, SortedList<int, Segment> Memory)
        {
            int Memory_index;
            Hole_List = Hole_List.OrderBy(a => a.start).ToList();
            for (int i = (PS.sg_num - 1); i >= 0; i--)
            {
                if (Memory.ContainsValue(PS.sgmnt[i]))
                {
                    Memory_index = Memory.IndexOfValue(PS.sgmnt[i]);
                    if (Memory_index != 0 && Memory.Values[Memory_index - 1].sg_name.Contains("Hole"))
                    {
                        var pair = Hole_List.Select((Value, Index) => new { Value, Index }).Single(p => p.Value.start == Memory.Keys[Memory_index - 1]);
                        hole_temp.num = Hole_List[pair.Index].num;
                        hole_temp.start = Hole_List[pair.Index].start;
                        hole_temp.size = Hole_List[pair.Index].size + Memory.Values[Memory_index].sg_size;
                        if ((Memory_index + 1) != Memory.Count && Memory.Values[Memory_index + 1].sg_name.Contains("Hole"))
                        {
                            if (Hole_List[pair.Index + 1].num < Hole_List[pair.Index].num)
                                hole_temp.num = Hole_List[pair.Index + 1].num;
                            hole_temp.size += Hole_List[pair.Index + 1].size;
                            Hole_List.RemoveAt(pair.Index + 1);
                            Memory.RemoveAt(Memory_index + 1);
                        }
                        Hole_List[pair.Index] = hole_temp;
                        sg_temp.sg_name = "Hole " + hole_temp.num.ToString();
                        sg_temp.sg_size = hole_temp.size;
                        Memory[Memory.Keys[Memory_index - 1]] = sg_temp;
                        Memory.RemoveAt(Memory_index);
                    }
                    else if ((Memory_index + 1) != Memory.Count && Memory.Values[Memory_index + 1].sg_name.Contains("Hole"))
                    {
                        var pair = Hole_List.Select((Value, Index) => new { Value, Index }).Single(p => p.Value.start == Memory.Keys[Memory_index + 1]);
                        hole_temp.num = Hole_List[pair.Index].num;
                        hole_temp.start = Memory.Keys[Memory_index];
                        hole_temp.size = Hole_List[pair.Index].size + Memory.Values[Memory_index].sg_size;
                        Hole_List[pair.Index] = hole_temp;
                        sg_temp.sg_name = Memory.Values[Memory_index + 1].sg_name;
                        sg_temp.sg_size = hole_temp.size;
                        Memory[Memory.Keys[Memory_index]] = sg_temp;
                        Memory.RemoveAt(Memory_index + 1);
                    }
                    else
                    {
                        if (Removed_Holes.Any())
                            hole_temp.num = Removed_Holes.Pop();
                        else
                            hole_temp.num = Hole_List.OrderByDescending(n => n.num).First().num + 1;
                        hole_temp.start = Memory.Keys[Memory_index];
                        hole_temp.size = Memory.Values[Memory_index].sg_size;
                        Hole_List.Add(hole_temp);
                        sg_temp.sg_name = "Hole " + hole_temp.num.ToString();
                        sg_temp.sg_size = Memory.Values[Memory_index].sg_size;
                        Memory[Memory.Keys[Memory_index]] = sg_temp;
                    }
                }
            }
        }

        static public void Compaction(int size, ref IList<Hole> Hole_List, SortedList<int, Segment> Memory)
        {
            for (int i = 0; i < Memory.Count; i++)
            {
                if (Memory.Values[i].sg_name.Contains("Hole"))
                {
                    Memory.RemoveAt(i);
                    i--;
                }
            }
            Hole_List.Clear();
            for (int j = 0; j < Memory.Count; j++)
            {
                if (j == 0)
                {
                    if (Memory.Keys[j] != 0)
                    {
                        sg_temp.sg_name = Memory.Values[j].sg_name;
                        sg_temp.sg_size = Memory.Values[j].sg_size;
                        Memory.RemoveAt(j);
                        Memory.Add(0, sg_temp);
                    }
                }
                else if(Memory.Keys[j] != (Memory.Keys[j-1] + Memory.Values[j-1].sg_size))
                {
                    sg_temp.sg_name = Memory.Values[j].sg_name;
                    sg_temp.sg_size = Memory.Values[j].sg_size;
                    Memory.RemoveAt(j);
                    Memory.Add((Memory.Keys[j - 1] + Memory.Values[j - 1].sg_size), sg_temp);
                }
            }
            hole_temp.num = 0;
            hole_temp.start = Memory.Keys[Memory.Count-1] + Memory.Values[Memory.Count-1].sg_size;
            hole_temp.size = size - hole_temp.start;
            Hole_List.Add(hole_temp);
            sg_temp.sg_name = "Hole " + hole_temp.num.ToString();
            sg_temp.sg_size = hole_temp.size;
            Memory.Add(hole_temp.start, sg_temp);
        }
    }
}

        /*static void Main(string[] args)
        {
            int size, Hole_sum=0, Hole_num=0, Old_num=0;
            Hole H;
            Segment SG;
            Process PS;
            IList<Hole> Hole_List = new List<Hole>();
            IList<Process> PS_List = new List<Process>();
            SortedList<int, Segment> Memory = new SortedList<int, Segment>();
            bool read_hole = true, process_op = true, Deallocate;
            Console.WriteLine("Please enter total memory size:");
            size = Convert.ToInt32(Console.ReadLine());
            while(read_hole)
            {
                H.num = Hole_num;
                Console.WriteLine("Please enter Hole[{0}] starting address:", Hole_num);
                H.start = Convert.ToInt32(Console.ReadLine());
                while (Hole_List.Any(hole => hole.start == H.start))
                {
                    Console.WriteLine("Please enter a non-existing address:");
                    H.start = Convert.ToInt32(Console.ReadLine());
                }
                while (H.start >= size)
                {
                    Console.WriteLine("Please enter Hole[{0}] starting address within Memory Limits:", Hole_num);
                    H.start = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("Please enter Hole[{0}] size:", Hole_num);
                H.size = Convert.ToInt32(Console.ReadLine());
                Hole_sum += H.size;
                while ((H.start + H.size) > size || Hole_sum > size)
                {
                    Hole_sum -= H.size;
                    Console.WriteLine("Please enter Hole[{0}] size within Memory Limits:", Hole_num);
                    H.size = Convert.ToInt32(Console.ReadLine());
                    Hole_sum += H.size;
                }
                Hole_List.Add(H);
                Hole_num++;
                Hole_List = Hole_List.OrderBy(a => a.start).ToList();
                if (Hole_sum == size)
                    break;
                Console.WriteLine("Insert new Hole [Y/N]?");
                if (Console.ReadLine() == "N")
                    read_hole = false;
            }
            for (int i = 0; i < Hole_num; i++)
            {
                if (i == 0)
                {
                    if (Hole_List[i].start > 0)
                    {
                        PS = new Process();
                        SG.sg_name = "Old Process " + Old_num.ToString();
                        SG.sg_size = Hole_List[i].start;
                        Memory.Add(0, SG);
                        PS.name = SG.sg_name;
                        PS.sg_num = 1;
                        PS.sg_alloc();
                        PS.Add_SG(SG);
                        PS_List.Add(PS);
                        Old_num++;
                    }
                }
                else if (Hole_List[i].start > (Hole_List[i - 1].start + Hole_List[i - 1].size))
                {
                    PS = new Process();
                    SG.sg_name = "Old Process " + Old_num.ToString();
                    SG.sg_size = Hole_List[i].start - (Hole_List[i - 1].start + Hole_List[i - 1].size);
                    Memory.Add((Hole_List[i - 1].start + Hole_List[i - 1].size), SG);
                    PS.name = SG.sg_name;
                    PS.sg_num = 1;
                    PS.sg_alloc();
                    PS.Add_SG(SG);
                    PS_List.Add(PS);
                    Old_num++;
                }
                SG.sg_name = "Hole " + Hole_List[i].num.ToString();
                SG.sg_size = Hole_List[i].size;
                Memory.Add(Hole_List[i].start, SG);
                if (i == Hole_num - 1)
                {
                    if ((Hole_List[i].start + Hole_List[i].size) < size)
                    {
                        PS = new Process();
                        SG.sg_name = "Old Process " + Old_num.ToString();
                        SG.sg_size = size - (Hole_List[i].start + Hole_List[i].size);
                        Memory.Add((Hole_List[i].start + Hole_List[i].size), SG);
                        PS.name = SG.sg_name;
                        PS.sg_num = 1;
                        PS.sg_alloc();
                        PS.Add_SG(SG);
                        PS_List.Add(PS);
                        Old_num++;
                    }
                }
            }
            Console.WriteLine("\n<Process Allocation>");
            for (int i = 0; i < Memory.Count; i++)
            {
                Console.WriteLine("{0}  {1}", Memory.Keys[i], Memory.Values[i].sg_name);
            }
            Console.WriteLine("{0}", size);
            while (process_op)
            {
                Deallocate = false;
                Console.WriteLine("\nDo you want to allocate or deallocate [A/D]?");
                char op = Convert.ToChar(Console.ReadLine());
                if (op == 'A')
                {
                    if (!Hole_List.Any())
                    {
                        Console.WriteLine("\nMemory Full please deallocate some processes :)");
                        Deallocate = true;
                    }
                    else
                    {
                        Console.WriteLine("Choose Method of Allocation [F/B/W]:");
                        Console.WriteLine("F: First Fit   B: Best_Fit   W: Worst_Fit");
                        char mt = Convert.ToChar(Console.ReadLine());
                        PS = new Process();
                        Console.WriteLine("Please enter Process name:");
                        PS.name = Console.ReadLine();
                        Console.WriteLine("Please enter Number of Segments:");
                        PS.sg_num = Convert.ToInt32(Console.ReadLine());
                        PS.sg_alloc();
                        for (int j = 0; j < PS.sg_num; j++)
                        {
                            Console.WriteLine("Please enter Segment[{0}] name:", j + 1);
                            SG.sg_name = PS.name + ": " + Console.ReadLine();
                            Console.WriteLine("Please enter Segment[{0}] size:", j + 1);
                            SG.sg_size = Convert.ToInt32(Console.ReadLine());
                            PS.Add_SG(SG);
                        }
                        if (!Mem_Alloc(PS, ref Hole_List, mt, Memory))
                        {
                            DeAlloc(PS, ref Hole_List, Memory);
                            Console.WriteLine("Process does not fit :(");
                        }
                        else
                            PS_List.Add(PS);
                    }
                }
                if (op == 'D' || Deallocate)
                {
                    if(Deallocate)
                    {
                        Console.WriteLine("Deallocate some processes [Y/N]?");
                        if (Console.ReadLine() != "Y")
                            Deallocate = false;
                    }
                    if (op == 'D' || Deallocate)
                    {
                        if (op == 'D' && Hole_List.Count == 1 && Hole_List.First().size == size)
                            Console.WriteLine("Memory is already empty :)");
                        else
                        {
                            for (int i = 0; i < PS_List.Count; i++)
                            {
                                Console.WriteLine("{0}:  {1}", i, PS_List[i].name);
                            }
                            Console.WriteLine("Please select Process Number:");
                            int PS_num = Convert.ToInt32(Console.ReadLine());
                            DeAlloc(PS_List[PS_num], ref Hole_List, Memory);
                            PS_List.RemoveAt(PS_num);
                        }
                    }
                }
                Console.WriteLine("\n<Memory Layout>");
                foreach (KeyValuePair<int, Segment> item in Memory)
                {
                    Console.WriteLine("{0}  {1}", item.Key, item.Value.sg_name);
                }
                Console.WriteLine("{0}", size);
                for (int i = 0; i < Hole_List.Count; i++)
                {
                    Console.WriteLine("{0}:  {1}   :{2}", Hole_List[i].num, Hole_List[i].start, Hole_List[i].size);
                }
                Console.WriteLine("\nDo new Process Operation [Y/N]?");
                if (Console.ReadLine() == "N")
                    process_op = false;
            }
        }
    }
}*/
