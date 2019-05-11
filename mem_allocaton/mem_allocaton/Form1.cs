using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mem_allocaton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //*************  migo   *********/
        SortedList<int, Segment> Memory = new SortedList<int, Segment>();
       // Hole H;
        Segment SG;
        Process PS;
        int size, Hole_sum = 0, Hole_num = 0, Old_num = 0;
        IList<Process> PS_List = new List<Process>();
        //*************  migo   *********/
        process p = new process();
        int i = 0;
            int num_ofSG = 0;
            int mem_size;
            IList<process> L_p = new List<process>();
            IList<holes> L_h = new List<holes>();
            //IList<sgment> sorted_sgment = new List<sgment>();
            sgment sg = new sgment();
            holes H = new holes();
            int num_holes = 1;
            private decimal d;
            private int time;
            //   SortedList<int, Segment> Memory = new SortedList<int, Segment>();
            bool read_hole = true, process_op = true, Deallocate;
           
            private void label2_Click(object sender, EventArgs e)
            {

            }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)//first fit
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)//best fit
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)//worest fit
        {

        }

        private void btn_deallocate_Click(object sender, EventArgs e)
        {
            
            DataGridViewRow row = new DataGridViewRow();
            
            for (int a = 0; a < dataGridView2.Rows.Count; a++)
            {
                row = dataGridView2.Rows[a];
                if (Convert.ToBoolean(row.Cells[0].Value)==true) {
                    string pro_name = Convert.ToString( row.Cells[1].Value);
                    for (int i = 0; i < PS_List.Count(); i++)
                    {
                        if (PS_List[i].name == pro_name) {
                            Best_fit.DeAlloc(PS_List[i], ref L_h, Memory);
                            PS_List.RemoveAt(i);
                        }


                    }
                  

                }

            }
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            DataTable dtData = new System.Data.DataTable();
            DataColumn dcID = new System.Data.DataColumn("address");
            DataColumn dcName = new System.Data.DataColumn("contain");
          
            dtData.Columns.Add(dcID);
            dtData.Columns.Add(dcName);
            
            DataRow drData = dtData.NewRow();
            foreach (KeyValuePair<int, Segment> item in Memory)
            {
                // Console.WriteLine("{0}  {1}", item.Key, item.Value.sg_name);
                drData["contain"] = item.Value.sg_name;
                drData["address"] = item.Key;
                dtData.Rows.Add(drData);
                drData = dtData.NewRow();

            }
            // Console.WriteLine("{0}", mem_size);

            drData["address"] = mem_size;
            dtData.Rows.Add(drData);
            drData = dtData.NewRow();
            dataGridView1.DataSource = dtData;
            DataTable dtData2 = new System.Data.DataTable();
            DataColumn dcID2 = new System.Data.DataColumn("process");

            dtData2.Columns.Add(dcID2);

            DataRow drData2 = dtData2.NewRow();
            for (int i = 0; i < PS_List.Count(); i++)
            {
                drData2["process"] = PS_List[i].name;
                dtData2.Rows.Add(drData2);
                drData2 = dtData2.NewRow();


            }
            //DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();

            //{
            //    checkBoxColumn.Name = "deallocate";

            //};
            //dataGridView2.Columns.Add(checkBoxColumn);

            dataGridView2.DataSource = dtData2;
        }

        private void btn_add_Click(object sender, EventArgs e)
            {
                num_holes++;
                tableLayoutPanel2.Controls.Add(new TextBox() { TextAlign = HorizontalAlignment.Center }, i /* Column Index */, 0 /* Row index */);
                tableLayoutPanel2.Controls.Add(new TextBox() { TextAlign = HorizontalAlignment.Center }, i /* Column Index */, 1 /* Row index */);
                i++;
            }

            private void button1_SG_custm_Click(object sender, EventArgs e)
            {
                if (button1_SG_custm.Text == "customize")
                {

                btn_genrate.Visible = true;
                    SG_name.Visible = true;
                    SG_size.Visible = true;
                    num_ofSG = Int32.Parse(textBox2_SG_num.Text);
                    for (int k = 0; k < num_ofSG; k++)
                    {

                        tableLayoutPanel1.Controls.Add(new TextBox() { TextAlign = HorizontalAlignment.Center }, k /* Column Index */, 0 /* Row index */);
                        tableLayoutPanel1.Controls.Add(new TextBox() { TextAlign = HorizontalAlignment.Center }, k /* Column Index */, 1 /* Row index */);

                    }
                    button1_SG_custm.Text = "add again";
                }
                else if (button1_SG_custm.Text == "add again")
                {


                    tableLayoutPanel1.Controls.Clear();
                    textBox_pr_name.Text = "";
                    textBox2_SG_num.Text = "";
                    SG_name.Visible = false;
                    SG_size.Visible = false;
                    button1_SG_custm.Text = "customize";
                }

            }

            private void btn_genrate_Click(object sender, EventArgs e)
            {
                /********start code migo**********/
                /*********finish  code migo**************/
                p.process_name = textBox_pr_name.Text;
                int count_name = 0;
                int count_size = 0;
                p.number_of_SG = num_ofSG;
              //  MessageBox.Show("num_of_sg=" + num_ofSG);
                sgment[] arr = new sgment[num_ofSG];

                // IList<sgment> arr = new List<sgment>();
                for (int a = 0; a < num_ofSG; a++)
                {

                    arr[a] = new sgment();

                }
                foreach (Control c in tableLayoutPanel1.Controls)
                {
                    if (c is TextBox)
                    {
                        TextBox txt = (TextBox)c;
                        if (String.IsNullOrEmpty(txt.Text))
                        {
                            MessageBox.Show("Please fill all the fields");
                            return;
                        }


                        if (tableLayoutPanel1.GetRow(c) == 0)
                        {

                            arr[count_name].name = txt.Text;
                          //  MessageBox.Show("count_name" + count_name);
                            count_name++;
                        }
                        else if (tableLayoutPanel1.GetRow(c) == 1)
                        {
                            arr[count_size].size = Int32.Parse(txt.Text);

                         //   MessageBox.Show("count_size" + count_size);
                            count_size++;

                        }

                    }
                }
                p.list_SG = arr;
                L_p.Add(p);
            }

            private void Form1_Load(object sender, EventArgs e)
            {

            }



        private void btn_finish_Click(object sender, EventArgs e)
        {
            int count = 1;
            int co_name = 1;
            int co_size = 1;
         
            holes[] arr_h = new holes[num_holes];
            holes first_hole = new holes(Int32.Parse(txt_holes_SA.Text), Int32.Parse(txt_hole_size.Text));
            first_hole.name = count;
            arr_h[0] = first_hole;
           
            sgment[] sorted_sgment = new sgment[num_ofSG];
            sorted_sgment[0] = new sgment();
            for (int a = 1; a < num_holes; a++)
            {

                arr_h[a] = new holes();
               
            }


            foreach (Control c in tableLayoutPanel2.Controls)
            {
                if (c is TextBox)
                {
                    TextBox txt = (TextBox)c;
                    if (String.IsNullOrEmpty(txt.Text))
                    {
                        MessageBox.Show("Please fill all the fields");
                        return;
                    }


                    if (tableLayoutPanel1.GetRow(c) == 0)
                    {
                        count++;
                        arr_h[co_name].name = count;
                        arr_h[co_name].Base = Int32.Parse(txt.Text);
                      
                        co_name++;


                    }
                    else if (tableLayoutPanel1.GetRow(c) == 1)
                    {
                        arr_h[co_size].size = Int32.Parse(txt.Text);
                     
                        co_size++;
                       
                    }

                }
            }
            L_h = arr_h;
            mem_size = Int32.Parse(txt_mem_size.Text);
            /*****************************   migo      **************************/
            for (int i = 0; i < L_h.Count(); i++)
            {
                if (i == 0)
                {
                    if (L_h[i].Base > 0)
                    {
                        PS = new Process();
                        SG.sg_name = "Old Process " + Old_num.ToString();
                        SG.sg_size = L_h[i].Base;
                        Memory.Add(0, SG);
                        PS.name = SG.sg_name;
                        PS.sg_num = 1;
                        PS.sg_alloc();
                        PS.Add_SG(SG);
                        PS_List.Add(PS);
                        Old_num++;
                    }
                }
                else if (L_h[i].Base > (L_h[i - 1].Base + L_h[i - 1].size))
                {
                    PS = new Process();
                    SG.sg_name = "Old Process " + Old_num.ToString();
                    SG.sg_size = L_h[i].Base - (L_h[i - 1].Base + L_h[i - 1].size);
                    Memory.Add((L_h[i - 1].Base + L_h[i - 1].size), SG);
                    PS.name = SG.sg_name;
                    PS.sg_num = 1;
                    PS.sg_alloc();
                    PS.Add_SG(SG);
                    PS_List.Add(PS);
                    Old_num++;
                }
                SG.sg_name = "Hole " + L_h[i].name.ToString();
                SG.sg_size = L_h[i].size;
                Memory.Add(L_h[i].Base, SG);
                if (i == L_h.Count() - 1)
                {
                    if ((L_h[i].Base + L_h[i].size) < mem_size)
                    {
                        PS = new Process();
                        SG.sg_name = "Old Process " + Old_num.ToString();
                        SG.sg_size = size - (L_h[i].Base + L_h[i].size);
                        Memory.Add((L_h[i].Base + L_h[i].size), SG);
                        PS.name = SG.sg_name;
                        PS.sg_num = 1;
                        PS.sg_alloc();
                        PS.Add_SG(SG);
                        PS_List.Add(PS);
                        Old_num++;
                    }
                }
            }
        
            for (int y = 0; y < L_p.Count(); y++) {
                PS = new Process();
                PS.name = L_p[y].process_name;
                PS.sg_num = L_p[y].number_of_SG;
                PS.sg_alloc();
                for (int u = 0; u < L_p[y].list_SG.Count();u++)
                {
                    SG.sg_name = L_p[y].list_SG[u].name;
                    SG.sg_size= L_p[y].list_SG[u].size;
                    PS.Add_SG(SG);
                }
                PS_List.Add(PS);
                }
            if (radioButton1.Checked) { Best_fit.Mem_Alloc(PS, ref L_h, 'B', Memory); }//best fit
            else if (radioButton2.Checked) { Best_fit.Mem_Alloc(PS, ref L_h, 'F', Memory); } //first fit
            else if (radioButton3.Checked) { Best_fit.Mem_Alloc(PS, ref L_h, 'W', Memory); }//worest fit


            DataTable dtData = new System.Data.DataTable();
            DataColumn dcID = new System.Data.DataColumn("address");
            DataColumn dcName = new System.Data.DataColumn("contain");
           
            dtData.Columns.Add(dcID);
            dtData.Columns.Add(dcName);
           
            DataRow drData = dtData.NewRow();
            foreach (KeyValuePair<int, Segment> item in Memory)
            {
               // Console.WriteLine("{0}  {1}", item.Key, item.Value.sg_name);
                drData["contain"] = item.Value.sg_name;
                drData["address"] = item.Key;
                dtData.Rows.Add(drData);
                drData = dtData.NewRow();
              
            }
           // Console.WriteLine("{0}", mem_size);
            
            drData["address"] = mem_size;
            dtData.Rows.Add(drData);
            drData = dtData.NewRow();
            dataGridView1.DataSource = dtData;
            /*************/
            DataTable dtData2 = new System.Data.DataTable();
            DataColumn dcID2 = new System.Data.DataColumn("process");
          
            dtData2.Columns.Add(dcID2);
           
            DataRow drData2 = dtData2.NewRow();
            for (int i=0;i<PS_List.Count();i++) {
                drData2["process"] = PS_List[i].name;
                dtData2.Rows.Add(drData2);
                drData2 = dtData2.NewRow();
              
               
            }
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();

            {
                checkBoxColumn.Name = "deallocate";

            };
            dataGridView2.Columns.Add(checkBoxColumn);

            dataGridView2.DataSource = dtData2;

            /*****************************   migo      **************************/



        }
    }
}
 