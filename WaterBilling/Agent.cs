using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace WaterBilling
{
    public partial class Agent : Form
    {
        public Agent()
        {
            InitializeComponent();
            ShowConsumer();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=MAHARAB-HOSEN\SQLEXPRESS;Initial Catalog=WaterBillingDb;Integrated Security=True;Connect Timeout=30;Encrypt=False");
        public void ShowConsumer()
        {
            Con.Open();
            string Query = "select Cid as Number, CName as Name, CAddress as Address, CPhone as Phone, CCatagory as Category, CDate as JoinDate, CRate as Rate from ConsumerTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ConsumerDGV.DataSource = ds.Tables[0];

            Con.Close();
        }
        private void Reset()
        {

            CNameTbl.Text = "";
            CPhoneTbl.Text = "";
            CAddTbl.Text = "";
            CRateTbl.Text = "";
            CCateTbl.SelectedIndex = -1;
            key = 0;
        }

        private void GetRate()
        {
            if (CCateTbl.SelectedIndex == 0)
            {
                CRateTbl.Text = "9";
            }
            else
            {
                CRateTbl.Text = "14";
            }
        }
        private void CCateTbl_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetRate();
        }

        int key = 0;

        private void ConsumerDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            CNameTbl.Text = ConsumerDGV.SelectedRows[0].Cells[1].Value.ToString();
            CAddTbl.Text = ConsumerDGV.SelectedRows[0].Cells[2].Value.ToString();
            CPhoneTbl.Text = ConsumerDGV.SelectedRows[0].Cells[3].Value.ToString();
            CCateTbl.SelectedItem = ConsumerDGV.SelectedRows[0].Cells[4].Value.ToString();
            CDateTbl.Text = ConsumerDGV.SelectedRows[0].Cells[5].Value.ToString();
            CRateTbl.Text = ConsumerDGV.SelectedRows[0].Cells[6].Value.ToString();

            if (CNameTbl.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(ConsumerDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void SaveBtn_Click_1(object sender, EventArgs e)
        {
            if (CNameTbl.Text == "" || CAddTbl.Text == "" || CPhoneTbl.Text == "" || CCateTbl.SelectedIndex == -1)
            {
                MessageBox.Show("Messing Information !!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into ConsumerTbl(CName, CAddress, CPhone, CCatagory, CDate, CRate) values(@CN, @CA, @CP, @CCA, @CD, @CR)", Con);
                    cmd.Parameters.AddWithValue("@CN", CNameTbl.Text);
                    cmd.Parameters.AddWithValue("@CA", CAddTbl.Text);
                    cmd.Parameters.AddWithValue("@CP", CPhoneTbl.Text);
                    cmd.Parameters.AddWithValue("@CCA", CCateTbl.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@CD", CDateTbl.Value.Date);
                    cmd.Parameters.AddWithValue("@CR", CRateTbl.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Consumer Added !!");
                    Con.Close();
                    ShowConsumer();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void EditBtn_Click_1(object sender, EventArgs e)
        {
            if (CNameTbl.Text == "" || CAddTbl.Text == "" || CPhoneTbl.Text == "" || CCateTbl.SelectedIndex == -1)
            {
                MessageBox.Show("Messing Information !!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update ConsumerTbl set CName = @CN, CAddress = @CA, CPhone = @CP, CCatagory = @CCA, CDate = @CD, CRate = @CR where cid = @Ckey", Con);
                    cmd.Parameters.AddWithValue("@CN", CNameTbl.Text);
                    cmd.Parameters.AddWithValue("@CA", CAddTbl.Text);
                    cmd.Parameters.AddWithValue("@CP", CPhoneTbl.Text);
                    cmd.Parameters.AddWithValue("@CCA", CCateTbl.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@CD", CDateTbl.Value.Date);
                    cmd.Parameters.AddWithValue("@CR", CRateTbl.Text);
                    cmd.Parameters.AddWithValue("@CKey", key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Consumer Update !!");
                    Con.Close();
                    ShowConsumer();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteBtn_Click_1(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select The Consumer To Be Delete !!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from ConsumerTbl where Cid = @CKey", Con);
                    cmd.Parameters.AddWithValue("@CKey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Consumer Delete !!");
                    Con.Close();
                    ShowConsumer();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e) //Billing
        {
            Billing obj = new Billing();
            obj.Show();
            this.Hide();
        }
        
        private void label7_Click(object sender, EventArgs e) // Back To consumer
        {
            Agent obj = new Agent();
            obj.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e) //Back to agent login page
        {
            AgentLogin obj = new AgentLogin();
            obj.Show();
            this.Hide();
        }

        private void guna2PictureBox2_Click_1(object sender, EventArgs e)
        {
            Billing obj = new Billing();
            obj.Show();
            this.Hide();
        }
    }
}
