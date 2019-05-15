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
    public partial class Form2 : Form
    {
        private int Hole_num, Hole_sum;
        Hole H;

        public Form2()
        {
            InitializeComponent();
            Hole_num = 0;
        }

        public void Reset()
        {
            Hole_num = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            H.num = Hole_num;
            
            // check:
            if (!int.TryParse(textBox1.Text, out H.size))
            {

                MessageBox.Show("Please enter integer value");
                return;
            }
           else if (!int.TryParse(textBox2.Text, out H.size))
            {

                MessageBox.Show("Please enter integer value");
                return;
            }
            int st = Int32.Parse(textBox1.Text);
            int si = Int32.Parse(textBox2.Text);

            if (Int32.Parse(textBox1.Text) < 0 || Int32.Parse(textBox2.Text) < 0)
                {
                    MessageBox.Show("please enter postive intiger number ");
                return;
            }
               
                else if ((Int32.Parse(textBox1.Text) + Int32.Parse(textBox2.Text)) > Form1.size)
                {
                    MessageBox.Show("please enter sutiable hole");
                return;
                }
                for (int i = 0; i < Form1.Hole_List.Count(); i++)
                {
                    if ((( (st+si) > (Form1.Hole_List[i].start)) && (st + si) < (Form1.Hole_List[i].start + Form1.Hole_List[i].size)))
                    {
                        MessageBox.Show("please enter sutiable hole");
                    return;
                    }
                    else if (st > Form1.Hole_List[i].start&&st< (Form1.Hole_List[i].start + Form1.Hole_List[i].size))
                    {

                        MessageBox.Show("please enter sutiable hole");
                    return;
                    }
                   
                
                    
                }

                
             

            H.start = Int32.Parse(textBox1.Text);
            H.size = Int32.Parse(textBox2.Text);
            Form1.Hole_List.Add(H);
            Hole_num++;
            textBox1.Text = "";
            textBox2.Text = "";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = "Hole[" + Hole_num.ToString() + "] Addres:";
            label2.Text = "Hole[" + Hole_num.ToString() + "] Size:";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
