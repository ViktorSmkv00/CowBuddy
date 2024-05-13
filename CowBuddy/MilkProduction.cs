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
    public partial class MilkProduction : Form
    {
        public MilkProduction()
        {
            InitializeComponent();
            FillCowId();
            populate();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label17_Click(object sender, EventArgs e)
        {
           
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Finances Ob = new Finances();
            Ob.Show();
            this.Hide();
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

        private void label5_Click(object sender, EventArgs e)
        {
            Cows Ob = new Cows();
            Ob.Show();
            this.Hide();
        }

        private void MilkProduction_Load(object sender, EventArgs e)
        {

        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vikto\cow_buddy_db.mdf;Integrated Security=True;Connect Timeout=30");

        private void FillCowId()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select CowId from CowTbl",Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CowId", typeof(int));
            dt.Load(Rdr);
            CowId.ValueMember = "CowId";
            CowId.DataSource = dt;
            Con.Close();
        }
        private void populate()
        {
            Con.Open();
            string query = "select * from MilkTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            MilkDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Clear()
        {
            CowNameTb.Text = "";
            AmMilkTb.Text = "";
            NoonMilkTb.Text = "";
            PmMilkTb.Text = "";
            TotalMilkTb.Text = "";
            key = 0;

        }
        private void GetCowName()
        {
            Con.Open();
            string query = "select * from CowTbl where CowId="+CowId.SelectedValue.ToString()+"";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                CowNameTb.Text = dr["CowName"].ToString();

            }
            Con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (CowId.SelectedIndex == -1 || CowNameTb.Text == "" || AmMilkTb.Text == "" || PmMilkTb.Text == "" || NoonMilkTb.Text == "" || TotalMilkTb.Text == "" )
            {
                MessageBox.Show("Липсваща информация");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "insert into MilkTbl values(" + CowId.SelectedValue.ToString() + ",'" + CowNameTb.Text + "'," + AmMilkTb.Text + "," + NoonMilkTb.Text + "," + PmMilkTb.Text + "," + TotalMilkTb.Text + ",'" + Date.Value.Date.ToString("yyyy-MM-dd") + "')";
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

        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void CowIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCowName();
        }

       
        private void PmTb_OnValueChanged(object sender, EventArgs e)
        {
          
        }

        private void TotalTb_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void TotalTb_Click(object sender, EventArgs e)
        {
        }

        private void TotalTb_MouseEnter(object sender, EventArgs e)
        {

           
        }

        private void TotalTb_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void PmTb_Leave(object sender, EventArgs e)
        {
            int total = Convert.ToInt32(AmMilkTb.Text) + Convert.ToInt32(PmMilkTb.Text) + Convert.ToInt32(NoonMilkTb.Text);
            TotalMilkTb.Text = "" + total;
        }
        int key = 0;
        
        
        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Избор на млечен продукт да бъде изтрит");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "delete from MilkTbl where MId=" + key + ";";
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (CowId.SelectedIndex == -1 || CowNameTb.Text == "" || AmMilkTb.Text == "" || PmMilkTb.Text == "" || NoonMilkTb.Text == "" || TotalMilkTb.Text == "")
            {
                MessageBox.Show("Липсваща информация");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "update MilkTbl set CowName='" + CowNameTb.Text + "',AmMilk=" + AmMilkTb.Text + ",NoonMilk=" + NoonMilkTb.Text + ",PmMilk=" + PmMilkTb.Text + ",TotalMilk=" + TotalMilkTb.Text + ",DateProd='" + Date.Value.Date.ToString("yyyy-MM-dd") + "' where Mid=" + key + ";";
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

        private void pictureBox9_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Login Ob = new Login();
            Ob.Show();
            this.Hide();
        }

        private void pictureBox9_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MilkDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            CowId.SelectedValue = MilkDGV.SelectedRows[0].Cells[1].Value.ToString();
            CowNameTb.Text = MilkDGV.SelectedRows[0].Cells[2].Value.ToString();
            AmMilkTb.Text = MilkDGV.SelectedRows[0].Cells[3].Value.ToString();
            NoonMilkTb.Text = MilkDGV.SelectedRows[0].Cells[4].Value.ToString();
            PmMilkTb.Text = MilkDGV.SelectedRows[0].Cells[5].Value.ToString();
            TotalMilkTb.Text = MilkDGV.SelectedRows[0].Cells[6].Value.ToString();
            Date.Text = MilkDGV.SelectedRows[0].Cells[7].Value.ToString();
            if (CowNameTb.Text == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(MilkDGV.SelectedRows[0].Cells[0].Value.ToString());


            }
        }
    }
}
