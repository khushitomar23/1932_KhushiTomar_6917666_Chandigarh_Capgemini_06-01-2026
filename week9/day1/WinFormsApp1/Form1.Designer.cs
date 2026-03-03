namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnInsert_Click = new Button();
            btnFind_Click = new Button();
            label1 = new Label();
            txtEmpName = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtEmpDesig = new TextBox();
            txtEmpDOJ = new TextBox();
            txtEmpSal = new TextBox();
            txtEmpId = new TextBox();
            txtDeptNo = new TextBox();
            btnClose_Click = new Button();
            btnClear_Click = new Button();
            btnUpdate_Click = new Button();
            btnDelete_Click = new Button();
            dataGridView1 = new DataGridView();
            btbUpdateDB_Click = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            // 
            // btnInsert_Click
            // 
            btnInsert_Click.Location = new Point(50, 295);
            btnInsert_Click.Name = "btnInsert_Click";
            btnInsert_Click.Size = new Size(112, 34);
            btnInsert_Click.TabIndex = 0;
            btnInsert_Click.Text = "Insert";
            btnInsert_Click.UseVisualStyleBackColor = true;
            // 
            // btnFind_Click
            // 
            btnFind_Click.Location = new Point(187, 295);
            btnFind_Click.Name = "btnFind_Click";
            btnFind_Click.Size = new Size(112, 34);
            btnFind_Click.TabIndex = 1;
            btnFind_Click.Text = "Find";
            btnFind_Click.UseVisualStyleBackColor = true;
            btnFind_Click.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 33);
            label1.Name = "label1";
            label1.Size = new Size(111, 25);
            label1.TabIndex = 2;
            label1.Text = "Enter EmpID";
            // 
            // txtEmpName
            // 
            txtEmpName.Location = new Point(252, 70);
            txtEmpName.Name = "txtEmpName";
            txtEmpName.Size = new Size(150, 31);
            txtEmpName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 70);
            label2.Name = "label2";
            label2.Size = new Size(140, 25);
            label2.TabIndex = 4;
            label2.Text = "Enter EmpName";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 110);
            label3.Name = "label3";
            label3.Size = new Size(152, 25);
            label3.TabIndex = 5;
            label3.Text = "Enter Designation";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(39, 149);
            label4.Name = "label4";
            label4.Size = new Size(90, 25);
            label4.TabIndex = 6;
            label4.Text = "Enter DOJ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(39, 184);
            label5.Name = "label5";
            label5.Size = new Size(104, 25);
            label5.TabIndex = 7;
            label5.Text = "Enter Salary";
            label5.Click += txtEmpSal_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(39, 220);
            label6.Name = "label6";
            label6.Size = new Size(123, 25);
            label6.TabIndex = 8;
            label6.Text = "Enter DeptNO";
            label6.Click += label5_Click;
            // 
            // txtEmpDesig
            // 
            txtEmpDesig.Location = new Point(252, 110);
            txtEmpDesig.Name = "txtEmpDesig";
            txtEmpDesig.Size = new Size(150, 31);
            txtEmpDesig.TabIndex = 9;
            // 
            // txtEmpDOJ
            // 
            txtEmpDOJ.Location = new Point(252, 149);
            txtEmpDOJ.Name = "txtEmpDOJ";
            txtEmpDOJ.Size = new Size(150, 31);
            txtEmpDOJ.TabIndex = 10;
            // 
            // txtEmpSal
            // 
            txtEmpSal.Location = new Point(252, 186);
            txtEmpSal.Name = "txtEmpSal";
            txtEmpSal.Size = new Size(150, 31);
            txtEmpSal.TabIndex = 11;
            // 
            // txtEmpId
            // 
            txtEmpId.Location = new Point(252, 30);
            txtEmpId.Name = "txtEmpId";
            txtEmpId.Size = new Size(150, 31);
            txtEmpId.TabIndex = 12;
            txtEmpId.TextChanged += textBox4_TextChanged;
            // 
            // txtDeptNo
            // 
            txtDeptNo.Location = new Point(252, 223);
            txtDeptNo.Name = "txtDeptNo";
            txtDeptNo.Size = new Size(150, 31);
            txtDeptNo.TabIndex = 13;
            // 
            // btnClose_Click
            // 
            btnClose_Click.Location = new Point(333, 352);
            btnClose_Click.Name = "btnClose_Click";
            btnClose_Click.Size = new Size(112, 34);
            btnClose_Click.TabIndex = 14;
            btnClose_Click.Text = "Close";
            btnClose_Click.UseVisualStyleBackColor = true;
            // 
            // btnClear_Click
            // 
            btnClear_Click.Location = new Point(333, 295);
            btnClear_Click.Name = "btnClear_Click";
            btnClear_Click.Size = new Size(112, 34);
            btnClear_Click.TabIndex = 15;
            btnClear_Click.Text = "Clear";
            btnClear_Click.UseVisualStyleBackColor = true;
            // 
            // btnUpdate_Click
            // 
            btnUpdate_Click.Location = new Point(50, 352);
            btnUpdate_Click.Name = "btnUpdate_Click";
            btnUpdate_Click.Size = new Size(112, 34);
            btnUpdate_Click.TabIndex = 16;
            btnUpdate_Click.Text = "Update";
            btnUpdate_Click.UseVisualStyleBackColor = true;
            // 
            // btnDelete_Click
            // 
            btnDelete_Click.Location = new Point(187, 352);
            btnDelete_Click.Name = "btnDelete_Click";
            btnDelete_Click.Size = new Size(112, 34);
            btnDelete_Click.TabIndex = 17;
            btnDelete_Click.Text = "Delete";
            btnDelete_Click.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(428, 33);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(360, 225);
            dataGridView1.TabIndex = 18;
            // 
            // btbUpdateDB_Click
            // 
            btbUpdateDB_Click.Location = new Point(595, 357);
            btbUpdateDB_Click.Name = "btbUpdateDB_Click";
            btbUpdateDB_Click.Size = new Size(112, 34);
            btbUpdateDB_Click.TabIndex = 19;
            btbUpdateDB_Click.Text = "Update into Database";
            btbUpdateDB_Click.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btbUpdateDB_Click);
            Controls.Add(dataGridView1);
            Controls.Add(btnDelete_Click);
            Controls.Add(btnUpdate_Click);
            Controls.Add(btnClear_Click);
            Controls.Add(btnClose_Click);
            Controls.Add(txtDeptNo);
            Controls.Add(txtEmpId);
            Controls.Add(txtEmpSal);
            Controls.Add(txtEmpDOJ);
            Controls.Add(txtEmpDesig);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtEmpName);
            Controls.Add(label1);
            Controls.Add(btnFind_Click);
            Controls.Add(btnInsert_Click);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnInsert_Click;
        private Button btnFind_Click;
        private Label label1;
        private TextBox txtEmpName;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtEmpDesig;
        private TextBox txtEmpDOJ;
        private TextBox txtEmpSal;
        private TextBox txtEmpId;
        private TextBox txtDeptNo;
        private Button btnClose_Click;
        private Button btnClear_Click;
        private Button btnUpdate_Click;
        private Button btnDelete_Click;
        private DataGridView dataGridView1;
        private Button btbUpdateDB_Click;
    }
}
