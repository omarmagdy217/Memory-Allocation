using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_Allocation
{
    public partial class Form1 : Form
    {
        private Random rnd = new Random();
        Form2 frm2 = new Form2();
        Form3 frm3 = new Form3();
        int size, Old_num, pad;
        Segment SG;
        Process PS;
        public static IList<Hole> Hole_List = new List<Hole>();
        public static IList<Process> PS_List = new List<Process>();
        public static SortedList<int, Segment> Memory = new SortedList<int, Segment>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            button3.Visible = false;
            checkedListBox1.Visible = false;
            button5.Visible = false;
            button3.Enabled = false;
            button2.Enabled = false;
            button6.Enabled = false; 
            groupBox2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = frm2.ShowDialog();
            if (result == DialogResult.OK)
            {
                string str = Hole_List.Last().start.ToString() + " >> Hole" + Hole_List.Last().num.ToString() + " [" + Hole_List.Last().size.ToString() + "]";
                listBox1.Items.Add(str);
                button2.Enabled = true;
            }
        }

        private void Memory_Layout()
        {
            tableLayoutPanel1.Controls.Clear();
            for (int i = 0; i < Memory.Count; i++)
            {
                Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                var Label1 = new Label { TextAlign = ContentAlignment.TopCenter, BackColor = Color.White, Text = Memory.Keys[i].ToString(), Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right), AutoSize = true };
                var Label2 = new Label { TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.White, BackColor = randomColor, Text = Memory.Values[i].sg_name, Anchor = (AnchorStyles.Left | AnchorStyles.Right), AutoSize = true };
                Label2.Font = new Font("Arial", 12, FontStyle.Bold);
                pad = (int)(100 * ((float)Memory.Values[i].sg_size / (float)size));
                Label1.Margin = new Padding(0, 0, 0, 0);
                Label2.Margin = new Padding(0, 0, 0, 0);
                Label2.Padding = new Padding(0, pad, 0, pad);
                tableLayoutPanel1.Controls.Add(Label1, 0 /* Column Index */, i /* Row index */);
                tableLayoutPanel1.Controls.Add(Label2, 1 /* Column Index */, i /* Row index */);
            }
            var Label3 = new Label { TextAlign = ContentAlignment.TopCenter, BackColor = Color.White, Text = size.ToString(), Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right), AutoSize = true };
            Label3.Margin = new Padding(0, 0, 0, 0);
            tableLayoutPanel1.Controls.Add(Label3, 0 /* Column Index */, Memory.Count /* Row index */);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            size = Int32.Parse(textBox1.Text);
            Old_num = 0;
            for (int i = 0; i < Hole_List.Count; i++)
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
                if (i == Hole_List.Count - 1)
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
            Memory_Layout();
            if (PS_List.Any())
            {
                label5.Text = "Memory Layout";
                if (Hole_List.Count == 1)
                {
                    if (Memory.Last().Value.sg_name.Contains("Hole"))
                        label5.Text = "Memory Compact";
                    else
                        button6.Enabled = true;
                }
                else
                    button6.Enabled = true;
                label2.Visible = true;
                button3.Enabled = true;
            }
            else
            {
                label5.Text = "Memory Empty";
            }
            textBox1.Enabled = false;
            button1.Visible = false;
            button5.Visible = true;
            groupBox2.Enabled = true;
            listBox1.Visible = false;
            button2.Visible = false;
            button3.Visible = true;
            checkedListBox1.Visible = true;
            for (int i = 0; i < PS_List.Count; i++)
            {
                checkedListBox1.Items.Insert(i, PS_List[i].name);  
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] indices = checkedListBox1.CheckedIndices.Cast<int>().ToArray();
            if (indices.Length == 0)
                MessageBox.Show("Please select one process at least :)");
            else
            {
                for (int i = 0; i < indices.Length; i++)
                {
                    Memory_OP.DeAlloc(PS_List[indices[i] - i], ref Hole_List, Memory);
                    PS_List.RemoveAt(indices[i] - i);
                    checkedListBox1.Items.RemoveAt(indices[i] - i);
                }
                Memory_Layout();
                groupBox2.Enabled = true;
                if (checkedListBox1.Items.Count == 0)
                {
                    label2.Visible = false;
                    label5.Text = "Memory Empty";
                    button3.Enabled = false;
                    button6.Enabled = false;
                }
                else
                {
                    label5.Text = "Memory Layout";
                    if (Hole_List.Count == 1)
                    {
                        if (Memory.Last().Value.sg_name.Contains("Hole"))
                        {
                            label5.Text = "Memory Compact";
                            button6.Enabled = false;
                        }
                        else
                            button6.Enabled = true;
                    }
                    else
                        button6.Enabled = true;
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("New Design clears all data", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning );
            if (result == DialogResult.OK)
            {
                Hole_List.Clear();
                PS_List.Clear();
                Memory.Clear();
                tableLayoutPanel1.Controls.Clear();
                frm2.Reset();
                Memory_OP.Reset();
                label5.Text = "New Design";
                button3.Enabled = true;
                button6.Enabled = false;
                label2.Visible = false;
                button3.Visible = false;
                button1.Visible = true;
                button2.Visible = true;
                textBox1.Text = "";
                textBox1.Enabled = true;
                listBox1.Items.Clear();
                checkedListBox1.Items.Clear();
                listBox1.Visible = true;
                checkedListBox1.Visible = false;
                button5.Visible = false;
                button2.Enabled = false;
                groupBox2.Enabled = false;
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            var answer = MessageBox.Show("Choosed the wanted method?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                var result = frm3.ShowDialog();
                if (result == DialogResult.OK)
                {
                    char mt;
                    if (radioButton1.Checked)
                        mt = 'F';
                    else if (radioButton2.Checked)
                        mt = 'B';
                    else
                        mt = 'W';
                    if (!Memory_OP.Mem_Alloc(PS_List.Last(), ref Hole_List, mt, Memory))
                    {
                        Memory_OP.DeAlloc(PS_List.Last(), ref Hole_List, Memory);
                        PS_List.RemoveAt(PS_List.Count - 1);
                        MessageBox.Show("Process does not fit :(");
                    }
                    else
                    {
                        Memory_Layout();
                        label5.Text = "Process Allocation";
                        checkedListBox1.Items.Add(PS_List.Last().name);
                        label2.Visible = true;
                        button3.Enabled = true;
                        if (!Hole_List.Any())
                        {
                            label5.Text = "Memory Full";
                            button6.Enabled = false;
                            groupBox2.Enabled = false;
                        }
                    }

                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Memory_OP.Compaction(size, ref Hole_List, Memory);
            Memory_OP.Reset();
            Memory_Layout();
            label5.Text = "Memory Compact";
            button6.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
