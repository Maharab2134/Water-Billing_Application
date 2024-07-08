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

namespace WaterBilling
{
    public partial class AgentLogin : Form
    {
        public AgentLogin()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=MAHARAB-HOSEN\SQLEXPRESS;Initial Catalog=WaterBillingDb;Integrated Security=True;Connect Timeout=30;Encrypt=False");
        public static string User;

        private void SaveBtl_Click(object sender, EventArgs e) //button login
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from AgentTbl where AgName='"+UserTbl.Text+"'and AgPass='"+PasswordTbl.Text+"'",Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                User = UserTbl.Text;
                Agent obj = new Agent();
                obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong User Name & Password !!");
            }
            Con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Main_Home obj = new Main_Home();
            obj.Show();
            this.Hide();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Information obj= new Information();
            obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            AdminLogin obj = new AdminLogin();
            obj.Show();
            this.Hide();
        }
    }
}
