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
        Process PS;

        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            PS = new Process();
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                button1.Enabled = true;
                button2.Enabled = false;
            }
            /*textBox1.Text = null;
            textBox2.Text = null;
            dataGridView1.DataSource = null;*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
            int numSG;

            numSG = Int32.Parse(textBox2.Text);
            DataTable dtData = new System.Data.DataTable();
            DataColumn SGID = new System.Data.DataColumn("id");
            DataColumn SGName = new System.Data.DataColumn("segment name");
            DataColumn SGSize = new System.Data.DataColumn("segment size");

            dtData.Columns.Add(SGID);
            dtData.Columns.Add(SGName);
            dtData.Columns.Add(SGSize);
            DataRow drData;
            for (int i = 0; i < numSG; i++)
            {
                drData = dtData.NewRow();
                drData["id"] = i + 1;
                dtData.Rows.Add(drData);
            }

            dataGridView1.DataSource = dtData;
            dataGridView1.Columns[0].Width = 30;
            dataGridView1.Columns[1].Width = 110;
            dataGridView1.Columns[2].Width = 110;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int numSG = Int32.Parse(textBox2.Text);
            Segment[] arr = new Segment[numSG];
            DataGridViewRow row = new DataGridViewRow();
            PS.name = textBox1.Text;
            PS.sg_num = numSG;
            PS.sg_alloc();

            for (int a = 0; a < dataGridView1.Rows.Count-1; a++)
            {
                row = dataGridView1.Rows[a];
                //  if (Convert.ToBoolean(row.Cells[0].Value) == true)
                // /
                arr[a].sg_name = Convert.ToString(PS.name + ": " + row.Cells[1].Value);
                arr[a].sg_size = Convert.ToInt32(row.Cells[2].Value);

                PS.Add_SG(arr[a]);


            }

            Form1.PS_List.Add(PS);
            textBox1.Text = null;
            textBox2.Text = null;
            dataGridView1.DataSource = null;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
        }
    }
}
