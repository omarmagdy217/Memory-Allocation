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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        Process PS = new Process();
        Segment SG;
        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
           
            int numSG;
            
            PS.name = textBox1.Text;
            numSG = Int32.Parse(textBox2.Text);
            DataTable dtData = new System.Data.DataTable();
            DataColumn SGID = new System.Data.DataColumn("id");
            DataColumn SGName = new System.Data.DataColumn("segment name");
            DataColumn SGSize = new System.Data.DataColumn("segment size");

            dtData.Columns.Add(SGID);
            dtData.Columns.Add(SGName);
            dtData.Columns.Add(SGSize);
            DataRow drData = dtData.NewRow();
            for (int i = 0; i < numSG; i++) {
                drData["id"] =i+1;
                dtData.Rows.Add(drData);
                drData = dtData.NewRow();
            }
           
            dataGridView1.DataSource = dtData;
            dataGridView1.Columns[0].Width = 30;
            dataGridView1.Columns[1].Width = 110;
            dataGridView1.Columns[2].Width = 110;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           int numSG = Int32.Parse(textBox2.Text);
            Segment[] arr = new Segment[numSG];
            DataGridViewRow row = new DataGridViewRow();
            PS.sg_num = numSG;
            PS.sg_alloc();
           
            for (int a = 0; a < dataGridView1.Rows.Count; a++)
            {
                row = dataGridView1.Rows[a];
              //  if (Convert.ToBoolean(row.Cells[0].Value) == true)
              // /
                    arr[a].sg_name= Convert.ToString(row.Cells[1].Value);
                    arr[a].sg_size= Convert.ToInt32(row.Cells[2].Value);
                
                   PS.Add_SG(arr[a]);
                

            }

            Form1.PS_List.Add(PS);
            button2.Enabled = false;
            textBox1.Text = null;
            textBox2.Text = null;
            dataGridView1.DataSource = null;
            this.DialogResult = DialogResult.OK;
            this.Close();
            /*   check for the input       */

            for (int a = 0; a < PS.sg_num; a++)
            {
                MessageBox.Show("segment" + a + 1 + " name= " + PS.sgmnt[a].sg_name + " ,size= " + PS.sgmnt[a].sg_size);

            }
        }
    }
}
