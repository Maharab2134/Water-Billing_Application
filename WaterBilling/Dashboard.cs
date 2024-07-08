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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            CountAgents();
            CountConsumers();
            SumBill();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=MAHARAB-HOSEN\SQLEXPRESS;Initial Catalog=WaterBillingDb;Integrated Security=True;Connect Timeout=30;Encrypt=False");
        
        private void CountAgents()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from AgentTbl",Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            AgNumLbl.Text = dt.Rows[0][0].ToString()+"  Agents";
            Con.Close();
        }
        private void CountConsumers()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from ConsumerTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ConsuLbl.Text = dt.Rows[0][0].ToString() + "  Consumers";
            Con.Close();
        }
        private void SumBill() //Full Bill Count
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select sum(Total) from BillTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            BillLbl.Text = "Taka " + dt.Rows[0][0].ToString() ;
            Con.Close();
        }
        private void ConsuLbl_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Admin obj = new Admin();
            obj.Show();
            this.Hide();
        }
    }
}
