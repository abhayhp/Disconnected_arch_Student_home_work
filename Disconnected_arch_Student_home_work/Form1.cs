using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Disconnected_arch_Student_home_work
{
    public partial class Form1 : Form
    {

        SqlConnection con;
        SqlDataAdapter da;
        SqlCommandBuilder scb;
        DataSet ds;
        public Form1()
        {
            
            InitializeComponent();
            string constr = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            con = new SqlConnection(constr);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }
        public DataSet GetAllEmp()
        {
            da = new SqlDataAdapter("select * from Stud", con);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            scb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "Stud");// Stud is a table name given to DataTable
            return ds;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAllEmp();
                DataRow row = ds.Tables["Stud"].NewRow();
                row["name"] = txtName.Text;
                row["sub1"] = txtPrice.Text;
                row["sub2"] = txtsub2.Text;
                row["sub3"] = txtsub3.Text;
                row["percentageamrks"] = txtpercentage.Text;


                ds.Tables["Stud"].Rows.Add(row);
                int result = da.Update(ds.Tables["Stud"]);
                if (result == 1)
                {
                    MessageBox.Show("Record inserted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnupdate_Click(object sender, EventArgs e)
        {

            try
            {
                ds = GetAllEmp();
                DataRow row = ds.Tables["Stud"].Rows.Find(txtrollno.Text);
                if (row != null)
                {
                    row["name"] = txtName.Text;
                    row["sub1"] = txtPrice.Text;
                    row["sub2"] = txtsub2.Text;
                    row["sub3"] = txtsub3.Text;
                    row["percentageamrks"] = txtpercentage.Text;



                    int result = da.Update(ds.Tables["Stud"]);
                    if (result == 1)
                    {
                        MessageBox.Show("Record updated");
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAllEmp();
                DataRow row = ds.Tables["Stud"].Rows.Find(txtrollno.Text);
                if (row != null)
                {
                    row.Delete();
                    int result = da.Update(ds.Tables["Stud"]);
                    if (result == 1)
                    {
                        MessageBox.Show("Record deleted");
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAllEmp();
                DataRow row = ds.Tables["Stud"].Rows.Find(txtrollno.Text);
                if (row != null)
                {
                    txtName.Text = row["name"].ToString();
                    txtPrice.Text = row["sub1"].ToString();
                    txtsub2.Text = row["sub2"].ToString();
                    txtsub3.Text = row["sub3"].ToString();

                    txtpercentage.Text = row["percentageamrks"].ToString();

                }
                else
                {
                    MessageBox.Show("Record not found");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnshowall_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAllEmp();
                dataGridView1.DataSource = ds.Tables["Stud"];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
