using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace GVOperationWithDataset
{
    public partial class Form1 : Form
    {
        SqlConnection con = null!;
        SqlDataAdapter da = null!;
        DataSet ds = null!;
        SqlCommandBuilder bldr = null!;
        DataRow? rec;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string conStr = @"Server=KHUSHI23\\SQLEXPRESS;Database=khushidb;Integrated Security=True;TrustServerCertificate=True;";

            con = new SqlConnection(conStr);
            da = new SqlDataAdapter("SELECT * FROM Employeetb", con);
            ds = new DataSet();

            da.Fill(ds, "Employeetb");

            DataTable table = ds.Tables["Employeetb"]!;

            table.PrimaryKey = new DataColumn[] { table.Columns["EmpId"] };

            dataGridView1.DataSource = table;

            bldr = new SqlCommandBuilder(da);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            DataTable table = ds.Tables["Employeetb"]!;

            if (!int.TryParse(txtEmpId.Text, out int empId) ||
                !int.TryParse(txtEmpSal.Text, out int empSal) ||
                !int.TryParse(txtDeptNo.Text, out int deptNo) ||
                !DateTime.TryParse(txtEmpDOJ.Text, out DateTime doj))
            {
                MessageBox.Show("Please enter valid numeric/date values.");
                return;
            }

            rec = table.NewRow();

            rec["EmpId"] = empId;
            rec["EmpName"] = txtEmpName.Text;
            rec["EmpDesg"] = txtEmpDesig.Text;
            rec["EmpDOJ"] = doj;
            rec["EmpSal"] = empSal;
            rec["EmpDept"] = deptNo;

            table.Rows.Add(rec);

            MessageBox.Show("Record inserted into Dataset");
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtEmpId.Text, out int empId))
            {
                MessageBox.Show("Enter valid EmpId");
                return;
            }

            DataTable table = ds.Tables["Employeetb"]!;
            rec = table.Rows.Find(empId);

            if (rec != null)
            {
                txtEmpName.Text = rec["EmpName"]?.ToString();
                txtEmpDesig.Text = rec["EmpDesg"]?.ToString();
                txtEmpDOJ.Text = Convert.ToDateTime(rec["EmpDOJ"]).ToShortDateString();
                txtEmpSal.Text = rec["EmpSal"]?.ToString();
                txtDeptNo.Text = rec["EmpDept"]?.ToString();
            }
            else
            {
                MessageBox.Show("Record not found");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (rec == null)
            {
                MessageBox.Show("Find record first");
                return;
            }

            if (!int.TryParse(txtEmpSal.Text, out int empSal) ||
                !int.TryParse(txtDeptNo.Text, out int deptNo) ||
                !DateTime.TryParse(txtEmpDOJ.Text, out DateTime doj))
            {
                MessageBox.Show("Invalid input values");
                return;
            }

            rec["EmpName"] = txtEmpName.Text;
            rec["EmpDesg"] = txtEmpDesig.Text;
            rec["EmpDOJ"] = doj;
            rec["EmpSal"] = empSal;
            rec["EmpDept"] = deptNo;

            MessageBox.Show("Record updated in Dataset");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtEmpId.Text, out int empId))
            {
                MessageBox.Show("Enter valid EmpId");
                return;
            }

            DataTable table = ds.Tables["Employeetb"]!;
            rec = table.Rows.Find(empId);

            if (rec != null)
            {
                rec.Delete();
                MessageBox.Show("Record deleted from Dataset");
            }
            else
            {
                MessageBox.Show("Record not found");
            }
        }

        private void btnUpdateDB_Click(object sender, EventArgs e)
        {
            if (ds.HasChanges())
            {
                da.Update(ds, "Employeetb");
                MessageBox.Show("Changes saved to database");
            }
            else
            {
                MessageBox.Show("No changes to save");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
                if (c is TextBox txt)
                    txt.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}