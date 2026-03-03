using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WAMDI
{
    public partial class GVOperationWithDataset : Form
    {
        SqlConnection con = new SqlConnection("server=KHUSHI23\\SQLEXPRESS;Database=khushidb;User Id=sa; Password=kirty");
        SqlCommandBuilder Bldr; SqlDataAdapter da; DataRow rec;
        DataSet ds;
        public GVOperationWithDataset()
        {
            InitializeComponent();
        }

        private void GVOperationWithDataset_Load(object sender, EventArgs e)
        {

            da = new SqlDataAdapter("Select *  from Employeetb", con);
            ds = new DataSet();
            da.Fill(ds, "Employeetb");
            dataGridView1.DataSource = ds.Tables[0];
            da.FillSchema(ds, SchemaType.Source, "Employeetb");
            Bldr = new SqlCommandBuilder(da);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                rec = ds.Tables[0].NewRow();
                rec[0] = txtEmpId.Text;
                rec[1] = txtEmpName.Text;
                rec[2] = txtEmpDesig.Text;
                rec[3] = txtEmpDOJ.Text;
                rec[4] = txtEmpSal.Text;
                rec[5] = txtDeptNo.Text;
                ds.Tables[0].Rows.Add(rec);
                MessageBox.Show("Record is Inserted into dataset Table");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                rec = ds.Tables[0].Select("EmpId=" + txtEmpId.Text)[0];
                txtEmpName.Text = rec[1].ToString();
                txtEmpDesig.Text = rec[2].ToString();
                txtEmpDOJ.Text = rec[3].ToString();
                txtEmpSal.Text = rec[4].ToString();
                txtDeptNo.Text = rec[5].ToString();
                btnUpdate.Enabled = true;
                MessageBox.Show("record find");
            }
            catch
            {
                MessageBox.Show("record Not Found");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                rec[1] = txtEmpName.Text;
                rec[2] = txtEmpDesig.Text;
                rec[3] = txtEmpDOJ.Text;
                rec[4] = txtEmpSal.Text;
                rec[5] = txtDeptNo.Text;
                btnUpdate.Enabled = false;
                MessageBox.Show("record is updated into dataset Table");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                rec = ds.Tables[0].Select("EmpId" + txtEmpId.Text)[0];
                rec.Delete();
                MessageBox.Show("Record is deleted from dataset Table");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btbUpdateDB_Click(object sender, EventArgs e)
        {
            try
            {
                if (ds.HasChanges() == true)
                {
                    da.Update(ds, "Employeetb");
                    MessageBox.Show("Dataset data is Upadated into database");
                }
                else
                {
                    MessageBox.Show("No modifiaction in Dataset");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                    x.Text = "";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
