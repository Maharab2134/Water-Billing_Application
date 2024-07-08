using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaterBilling
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e) //Agent
        {
            AgentLogin obj = new AgentLogin();
            obj.Show();
            this.Hide();
        }

        private void SaveBtl_Click(object sender, EventArgs e)
        {
            if (PasswordTbl.Text == "")
            {
                MessageBox.Show("Enter The Admin Password ");
            } else if(PasswordTbl.Text == "Password")
            {
                Admin obj = new Admin();
                obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Admin Password ");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            Main_Home obj = new Main_Home();
            obj.Show();
            this.Hide();
        }
    }
}
