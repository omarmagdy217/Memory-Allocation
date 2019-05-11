using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mem_allocaton
{
    class Best_fit
    {

        private static Stack<int> Removed_Holes = new Stack<int>();

        static public bool Mem_Alloc(Process PS, ref IList<holes> Hole_List, char mt, SortedList<int, Segment> Memory)
        {
            Segment sg_temp;
            holes hole_temp=new holes();
            bool fit;
            if (mt == 'F')
                Hole_List = Hole_List.OrderBy(a => a.Base).ToList();
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
                        Memory[Hole_List[j].Base] = sg_temp;
                        sg_temp.sg_size = Hole_List[j].size - PS.sgmnt[i].sg_size;
                        if (sg_temp.sg_size == 0)
                        {
                            Removed_Holes.Push(Hole_List[j].name);
                            Hole_List.RemoveAt(j);
                        }
                        else
                        {
                            sg_temp.sg_name = "Hole " + Hole_List[j].name.ToString();
                            hole_temp.name = Hole_List[j].name;
                            hole_temp.Base = Hole_List[j].Base + PS.sgmnt[i].sg_size;
                            hole_temp.size = sg_temp.sg_size;
                            Hole_List[j] = hole_temp;
                            Memory.Add(hole_temp.Base, sg_temp);
                        }
                        break;
                    }
                }
                if (!fit)
                    return false;
            }
            return true;
        }

        static public void DeAlloc(Process PS, ref IList<holes> Hole_List, SortedList<int, Segment> Memory)
        {
            int Memory_index;
            Segment sg_temp;
            holes hole_temp=new holes();
            Hole_List = Hole_List.OrderBy(a => a.Base).ToList();
            for (int i = (PS.sg_num - 1); i >= 0; i--)
            {
                if (Memory.ContainsValue(PS.sgmnt[i]))
                {
                    Memory_index = Memory.IndexOfValue(PS.sgmnt[i]);
                    if (Memory_index != 0 && Memory.Values[Memory_index - 1].sg_name.Contains("Hole"))
                    {
                        var pair = Hole_List.Select((Value, Index) => new { Value, Index }).Single(p => p.Value.Base == Memory.Keys[Memory_index - 1]);
                        hole_temp.name = Hole_List[pair.Index].name;
                        hole_temp.Base = Hole_List[pair.Index].Base;
                        hole_temp.size = Hole_List[pair.Index].size + Memory.Values[Memory_index].sg_size;
                        if ((Memory_index + 1) != Memory.Count && Memory.Values[Memory_index + 1].sg_name.Contains("Hole"))
                        {
                            hole_temp.size += Hole_List[pair.Index + 1].size;
                            Hole_List.RemoveAt(pair.Index + 1);
                            Memory.RemoveAt(Memory_index + 1);
                        }
                        Hole_List[pair.Index] = hole_temp;
                        sg_temp.sg_name = Memory.Values[Memory_index - 1].sg_name;
                        sg_temp.sg_size = hole_temp.size;
                        Memory[Memory.Keys[Memory_index - 1]] = sg_temp;
                        Memory.RemoveAt(Memory_index);
                    }
                    else if ((Memory_index + 1) != Memory.Count && Memory.Values[Memory_index + 1].sg_name.Contains("Hole"))
                    {
                        var pair = Hole_List.Select((Value, Index) => new { Value, Index }).Single(p => p.Value.Base == Memory.Keys[Memory_index + 1]);
                        hole_temp.name = Hole_List[pair.Index].name;
                        hole_temp.Base = Memory.Keys[Memory_index];
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
                            hole_temp.name = Removed_Holes.Pop();
                        else
                            hole_temp.name = Hole_List.OrderByDescending(n => n.name).First().name + 1;
                        hole_temp.Base = Memory.Keys[Memory_index];
                        hole_temp.size = Memory.Values[Memory_index].sg_size;
                        Hole_List.Add(hole_temp);
                        sg_temp.sg_name = "Hole " + hole_temp.name.ToString();
                        sg_temp.sg_size = Memory.Values[Memory_index].sg_size;
                        Memory[Memory.Keys[Memory_index]] = sg_temp;
                    }
                }
            }
        }

    }
}
