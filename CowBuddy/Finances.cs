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
    public partial class Finances : Form
    {
        public Finances()
        {
            InitializeComponent();
            populateExp();
            populateInc();
            FillEmpId();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {
            
        }

        private void label16_Click(object sender, EventArgs e)
        {
            MilkSales Ob = new MilkSales();
            Ob.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Breedings Ob = new Breedings();
            Ob.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            CowHealth Ob = new CowHealth();
            Ob.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            MilkProduction Ob = new MilkProduction();
            Ob.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vikto\cow_buddy_db.mdf;Integrated Security=True;Connect Timeout=30");

        private void populateExp()
        {
            Con.Open();
            string query = "select * from ExpenditureTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ExpDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void populateInc()
        {
            Con.Open();
            string query = "select * from IncomeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            IncDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void FilterIncome()
        {
            Con.Open();
            string query = "select * from IncomeTbl where IncDate='" + IncomeDateFilter.Value.Date.ToString("yyyy-MM-dd") + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            IncDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void FilterExp()
        {
            Con.Open();
            string query = "select * from ExpenditureTbl where ExpDate='" + ExpDateFilter.Value.Date.ToString("yyyy-MM-dd") + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ExpDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void ClearExp()
        {
            ExpAmtTb.Text = "";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (ExpPurposeCb.SelectedIndex == -1 || ExpAmtTb.Text == "" || IdSlujitelCb.SelectedIndex == -1)
            {
                MessageBox.Show("Липсваща информация");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "insert into ExpenditureTbl values('" + ExpDate.Value.Date.ToString("yyyy-MM-dd") + "','" + ExpPurposeCb.SelectedItem.ToString() + "'," + ExpAmtTb.Text + "," + IdSlujitelCb.SelectedValue.ToString() + ")";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Успешно запазване на разход");

                    Con.Close();
                    populateExp();
                    ClearExp();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void FillEmpId()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select EmpId from EmployeeTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("EmpId", typeof(int));
            dt.Load(Rdr);
            IdSlujitelCb.ValueMember = "EmpId";
            IdSlujitelCb.DataSource = dt;
            Con.Close();
        }
        private void ClearInc()
        {
            IncPurposeCb.SelectedIndex = -1;
            IncAmtTb.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (IncPurposeCb.SelectedIndex == -1 || IncAmtTb.Text == ""|| IdSlujitelCb.SelectedIndex == -1)
            {
                MessageBox.Show("Липсваща информация");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "insert into IncomeTbl values('" + IncomeDate.Value.Date.ToString("yyyy-MM-dd") + "','" + IncPurposeCb.SelectedItem.ToString() + "'," + IncAmtTb.Text + "," + IdSlujitelCb.SelectedValue.ToString() + ")";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Успешно запазване на приход");

                    Con.Close();
                    populateInc();
                    ClearInc();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            FilterIncome();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            populateInc();
        }

        private void ExpDateFilter_ValueChanged(object sender, EventArgs e)
        {
            FilterExp();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            populateExp();
        }

        private void Finances_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Login Ob = new Login();
            Ob.Show();
            this.Hide();
        }

        private void pictureBox11_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ExpDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
