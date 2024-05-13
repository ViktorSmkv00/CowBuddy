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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            UserNameTb.Text = "";
            UserPassTb.Text = "";
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vikto\cow_buddy_db.mdf;Integrated Security=True;Connect Timeout=30");

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (UserNameTb.Text == "" || UserPassTb.Text == "")
            {
                MessageBox.Show("Въведете потребителско име или парола");
            }
            else
            {
                if (PositionCb.SelectedIndex > -1)
                {
                    if (PositionCb.SelectedItem.ToString() == "Admin")
                    {
                        if (UserNameTb.Text == "Admin" && UserPassTb.Text == "Admin")
                        {
                            Employees prod = new Employees();
                            prod.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Ако сте Админ, въведете правилните потребителско име и парола");
                            UserNameTb.Text = "";
                            UserPassTb.Text = "";
                        }
                    }
                    else
                    {
                        
                        Con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from EmployeeTbl where EmpName='" + UserNameTb.Text + "' and EmpPass='" + UserPassTb.Text + "'", Con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                           
                            Cows cow = new Cows();
                            cow.Show();
                            this.Hide();
                            Con.Close();

                        }
                        else
                        {
                            MessageBox.Show("Грешно потребителско име или парола");
                            UserNameTb.Text = "";
                            UserPassTb.Text = "";
                        }
                        Con.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Изберете позиция");
                }
            }


        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void RoleCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
