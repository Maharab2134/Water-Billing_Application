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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WaterBilling
{
    public partial class New_connecation : Form
    {
        public New_connecation()
        {
            InitializeComponent();
        }

       
        SqlConnection Con = new SqlConnection(@"Data Source=MAHARAB-HOSEN\SQLEXPRESS;Initial Catalog=WaterBillingDb;Integrated Security=True;Connect Timeout=30;Encrypt=False");

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (name.Text == "" || address.Text == "" || number.Text == "" || CCateTbl.Text == "")
            {
                MessageBox.Show("Messing Information !!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into NewConnecation(Name,Address,Phone,CCatagory) values(@N,@A,@P,@CCA)", Con);
                    cmd.Parameters.AddWithValue("@N", name.Text);
                    cmd.Parameters.AddWithValue("@A", address.Text);
                    cmd.Parameters.AddWithValue("@P", number.Text);
                    cmd.Parameters.AddWithValue("@CCA", CCateTbl.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registration successful!");
                    Con.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            Main_Home obj = new Main_Home();
            obj.Show();
            this.Hide();
        }
    }
 }
