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
    public partial class ComplentBox : Form
    {
        public ComplentBox()
        {
            InitializeComponent();
            ShowMessage();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=MAHARAB-HOSEN\SQLEXPRESS;Initial Catalog=WaterBillingDb;Integrated Security=True;Connect Timeout=30;Encrypt=False");

        public void ShowMessage()
        {
            Con.Open();
            string Query = "select cid as CID, date as Date, details as [Poblem Details]  from Complaints";
            SqlDataAdapter adapter = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            GridView2.DataSource = ds.Tables[0];

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
