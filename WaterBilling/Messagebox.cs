using FontAwesome.Sharp;
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
    public partial class Messagebox : Form
    {
        public Messagebox()
        {
            InitializeComponent();
            ShowMessage();
        }

        private void Messageboxcs_Load(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=MAHARAB-HOSEN\SQLEXPRESS;Initial Catalog=WaterBillingDb;Integrated Security=True;Connect Timeout=30;Encrypt=False");
        public void ShowMessage()
        {
            Con.Open();
            string Query = "select Name as Name, Phone as Phone, Address as Address,CCatagory as Catagory  from NewConnecation";
            SqlDataAdapter adapter = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            GridView1.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            Admin obj = new Admin();
            obj.Show();
            this.Hide();
        }
    }
}
