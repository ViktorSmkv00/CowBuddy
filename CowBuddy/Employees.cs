using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CowBuddy
{
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
            populate();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vikto\cow_buddy_db.mdf;Integrated Security=True;Connect Timeout=30");


        private void populate()
        {
            Con.Open();
            string query = "select * from EmployeeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmployeeDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Employees_Load(object sender, EventArgs e)
        {

        }
        int key = 0;
        private void Clear()
        {
            EmpTelTb.Text = "";
            EmpNameTb.Text = "";
            AddressTb.Text = "";
            GenderCb.SelectedIndex = -1;
            key = 0;
            EmpPassTb.Text = "";
        }
        
       

        private void pictureBox9_Click_2(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void pictureBox10_Click_1(object sender, EventArgs e)
        {
            Login Ob = new Login();
            Ob.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (EmpNameTb.Text == "" || GenderCb.SelectedIndex == -1 || EmpTelTb.Text == "" || AddressTb.Text == "" || EmpPassTb.Text == "")
            {
                MessageBox.Show("Липсваща информация");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "insert into EmployeeTbl values('" + EmpNameTb.Text + "','" + DOB.Value.Date.ToString("yyyy-MM-dd") + "','" + GenderCb.SelectedItem.ToString() + "','" + EmpTelTb.Text + "','" + AddressTb.Text + "','" + EmpPassTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Запазване успешно");

                    Con.Close();
                    populate();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (EmpNameTb.Text == "" || GenderCb.SelectedIndex == -1 || EmpTelTb.Text == "" || AddressTb.Text == "")
            {
                MessageBox.Show("Липсваща информация");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "update EmployeeTbl set EmpName='" + EmpNameTb.Text + "',EmpDOB='" + DOB.Value.Date.ToString("yyyy-MM-dd") + "',Gender='" + GenderCb.SelectedItem.ToString() + "',Phone='" + EmpTelTb.Text + "',Address='" + AddressTb.Text + "',EmpPass='" + EmpPassTb.Text + "' where Empid=" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Актуализиране успешно");
                    Con.Close();
                    populate();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Избиране на служител да бъде изтрит");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "delete from EmployeeTbl where EmpId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Изтриване успешно");

                    Con.Close();
                    populate();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Clear();

        }

        private void EmployeeDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            EmpNameTb.Text = EmployeeDGV.SelectedRows[0].Cells[1].Value.ToString();
            DOB.Text = EmployeeDGV.SelectedRows[0].Cells[2].Value.ToString();
            GenderCb.SelectedItem = EmployeeDGV.SelectedRows[0].Cells[3].Value.ToString();
            EmpTelTb.Text = EmployeeDGV.SelectedRows[0].Cells[4].Value.ToString();
            AddressTb.Text = EmployeeDGV.SelectedRows[0].Cells[5].Value.ToString();
            EmpPassTb.Text = EmployeeDGV.SelectedRows[0].Cells[6].Value.ToString();
            if (EmpNameTb.Text == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(EmployeeDGV.SelectedRows[0].Cells[0].Value.ToString());


            }
        }
    }
}
