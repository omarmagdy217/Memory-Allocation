namespace mem_allocaton
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);


        }
        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grb_box_fit = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btn_finish = new System.Windows.Forms.Button();
            this.button1_SG_custm = new System.Windows.Forms.Button();
            this.textBox2_SG_num = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            this.textBox_pr_name = new System.Windows.Forms.TextBox();
            this.txt_hole_size = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_holes_SA = new System.Windows.Forms.TextBox();
            this.txt_mem_size = new System.Windows.Forms.TextBox();
            this.SG_name = new System.Windows.Forms.Label();
            this.SG_size = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_genrate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btn_deallocate = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.grb_box_fit.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grb_box_fit);
            this.groupBox1.Controls.Add(this.btn_finish);
            this.groupBox1.Controls.Add(this.button1_SG_custm);
            this.groupBox1.Controls.Add(this.textBox2_SG_num);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btn_add);
            this.groupBox1.Controls.Add(this.textBox_pr_name);
            this.groupBox1.Controls.Add(this.txt_hole_size);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_holes_SA);
            this.groupBox1.Controls.Add(this.txt_mem_size);
            this.groupBox1.Location = new System.Drawing.Point(35, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 366);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // grb_box_fit
            // 
            this.grb_box_fit.Controls.Add(this.radioButton3);
            this.grb_box_fit.Controls.Add(this.radioButton2);
            this.grb_box_fit.Controls.Add(this.radioButton1);
            this.grb_box_fit.Location = new System.Drawing.Point(71, 280);
            this.grb_box_fit.Name = "grb_box_fit";
            this.grb_box_fit.Size = new System.Drawing.Size(278, 52);
            this.grb_box_fit.TabIndex = 13;
            this.grb_box_fit.TabStop = false;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(175, 21);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(85, 21);
            this.radioButton3.TabIndex = 4;
            this.radioButton3.Text = "worest fit";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(67, 21);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "first fit";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(90, 21);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(71, 21);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.Text = "best fit";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // btn_finish
            // 
            this.btn_finish.AutoSize = true;
            this.btn_finish.Location = new System.Drawing.Point(123, 333);
            this.btn_finish.Name = "btn_finish";
            this.btn_finish.Size = new System.Drawing.Size(81, 27);
            this.btn_finish.TabIndex = 12;
            this.btn_finish.Text = "genrate";
            this.btn_finish.UseVisualStyleBackColor = true;
            this.btn_finish.Click += new System.EventHandler(this.btn_finish_Click);
            // 
            // button1_SG_custm
            // 
            this.button1_SG_custm.AutoSize = true;
            this.button1_SG_custm.Location = new System.Drawing.Point(123, 247);
            this.button1_SG_custm.Name = "button1_SG_custm";
            this.button1_SG_custm.Size = new System.Drawing.Size(81, 27);
            this.button1_SG_custm.TabIndex = 11;
            this.button1_SG_custm.Text = "customize";
            this.button1_SG_custm.UseVisualStyleBackColor = true;
            this.button1_SG_custm.Click += new System.EventHandler(this.button1_SG_custm_Click);
            // 
            // textBox2_SG_num
            // 
            this.textBox2_SG_num.Location = new System.Drawing.Point(231, 221);
            this.textBox2_SG_num.Name = "textBox2_SG_num";
            this.textBox2_SG_num.Size = new System.Drawing.Size(100, 22);
            this.textBox2_SG_num.TabIndex = 10;
            this.textBox2_SG_num.Text = "3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "segment number";
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(242, 141);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 8;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // textBox_pr_name
            // 
            this.textBox_pr_name.Location = new System.Drawing.Point(231, 189);
            this.textBox_pr_name.Name = "textBox_pr_name";
            this.textBox_pr_name.Size = new System.Drawing.Size(100, 22);
            this.textBox_pr_name.TabIndex = 7;
            this.textBox_pr_name.Text = "p1";
            // 
            // txt_hole_size
            // 
            this.txt_hole_size.Location = new System.Drawing.Point(231, 110);
            this.txt_hole_size.Name = "txt_hole_size";
            this.txt_hole_size.Size = new System.Drawing.Size(100, 22);
            this.txt_hole_size.TabIndex = 6;
            this.txt_hole_size.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "process name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "hole size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mem.size";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "hole starting address";
            // 
            // txt_holes_SA
            // 
            this.txt_holes_SA.Location = new System.Drawing.Point(231, 73);
            this.txt_holes_SA.Name = "txt_holes_SA";
            this.txt_holes_SA.Size = new System.Drawing.Size(100, 22);
            this.txt_holes_SA.TabIndex = 1;
            this.txt_holes_SA.Text = "10";
            // 
            // txt_mem_size
            // 
            this.txt_mem_size.Location = new System.Drawing.Point(231, 36);
            this.txt_mem_size.Name = "txt_mem_size";
            this.txt_mem_size.Size = new System.Drawing.Size(100, 22);
            this.txt_mem_size.TabIndex = 0;
            this.txt_mem_size.Text = "50";
            // 
            // SG_name
            // 
            this.SG_name.AutoSize = true;
            this.SG_name.Location = new System.Drawing.Point(396, 238);
            this.SG_name.Name = "SG_name";
            this.SG_name.Size = new System.Drawing.Size(101, 17);
            this.SG_name.TabIndex = 3;
            this.SG_name.Text = "segment name";
            this.SG_name.Visible = false;
            // 
            // SG_size
            // 
            this.SG_size.AutoSize = true;
            this.SG_size.Location = new System.Drawing.Point(396, 281);
            this.SG_size.Name = "SG_size";
            this.SG_size.Size = new System.Drawing.Size(91, 17);
            this.SG_size.TabIndex = 4;
            this.SG_size.Text = "segment size";
            this.SG_size.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(48, 4);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.39942F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.60058F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(0, 0);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // btn_genrate
            // 
            this.btn_genrate.AutoSize = true;
            this.btn_genrate.Location = new System.Drawing.Point(434, 328);
            this.btn_genrate.Name = "btn_genrate";
            this.btn_genrate.Size = new System.Drawing.Size(81, 27);
            this.btn_genrate.TabIndex = 12;
            this.btn_genrate.Text = "finish";
            this.btn_genrate.UseVisualStyleBackColor = true;
            this.btn_genrate.Visible = false;
            this.btn_genrate.Click += new System.EventHandler(this.btn_genrate_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(522, 235);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1159, 126);
            this.panel1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Controls.Add(this.tableLayoutPanel4);
            this.panel2.Location = new System.Drawing.Point(399, 70);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1159, 100);
            this.panel2.TabIndex = 14;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(21, 29);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.39942F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.60058F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(0, 0);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(52, 17);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.39942F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.60058F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(0, 0);
            this.tableLayoutPanel4.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(339, 381);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(435, 194);
            this.dataGridView1.TabIndex = 15;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(865, 381);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(435, 194);
            this.dataGridView2.TabIndex = 16;
            // 
            // btn_deallocate
            // 
            this.btn_deallocate.AutoSize = true;
            this.btn_deallocate.Location = new System.Drawing.Point(865, 597);
            this.btn_deallocate.Name = "btn_deallocate";
            this.btn_deallocate.Size = new System.Drawing.Size(83, 27);
            this.btn_deallocate.TabIndex = 14;
            this.btn_deallocate.Text = "deallocate";
            this.btn_deallocate.UseVisualStyleBackColor = true;
            this.btn_deallocate.Click += new System.EventHandler(this.btn_deallocate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 710);
            this.Controls.Add(this.btn_deallocate);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btn_genrate);
            this.Controls.Add(this.SG_size);
            this.Controls.Add(this.SG_name);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grb_box_fit.ResumeLayout(false);
            this.grb_box_fit.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.TextBox textBox_pr_name;
        private System.Windows.Forms.TextBox txt_hole_size;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_holes_SA;
        private System.Windows.Forms.TextBox txt_mem_size;
        private System.Windows.Forms.Button button1_SG_custm;
        private System.Windows.Forms.TextBox textBox2_SG_num;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label SG_name;
        private System.Windows.Forms.Label SG_size;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_genrate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btn_finish;
        private System.Windows.Forms.GroupBox grb_box_fit;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btn_deallocate;
    }
}

/// <summary>
/// Required method for Designer support - do not modify
/// the contents of this method with the code editor.
/// </summary>


