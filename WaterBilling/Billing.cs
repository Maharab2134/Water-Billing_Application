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
using System.Windows.Input;

namespace WaterBilling
{
    public partial class Billing : Form
    {
        public Billing()
        {
            InitializeComponent();
            ShowBill();
            GetCons();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=MAHARAB-HOSEN\SQLEXPRESS;Initial Catalog=WaterBillingDb;Integrated Security=True;Connect Timeout=30;Encrypt=False");
        int key = 0;
        private void ShowBill()
        {
            Con.Open();

            string Query = "select * from BillTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BillDGV.DataSource = ds.Tables[0];

            Con.Close();
        }

        private void Add_Click(object sender, EventArgs e) //Add
        {
            if (RateTb.Text == "" || TaxTb.Text == "" || ConsTb.Text == "")
            {
                MessageBox.Show("Missing Information !!");
            }
            else
            {
                try
                {
                    int R = Convert.ToInt32(RateTb.Text); //rate
                    int Consumption = Convert.ToInt32(ConsTb.Text); //con
                    int sum = (R * Consumption); 
                    float Tax = (sum / 100); 
                    float Total = Tax + sum; 


                    string Period = BPTb.Value.Month + "/" + BPTb.Value.Year;
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into BillTbl (Cid, Agent, BillPeriod, Consumption, Rate, Tax, Total) values(@CI,@AG,@BP,@CON,@RA,@TAX,@TOTA)", Con);
                    cmd.Parameters.AddWithValue("@CI", CIdCb.SelectedValue.ToString()); //Consumption BillPriod
                    cmd.Parameters.AddWithValue("@AG", AgentTbl.Text);
                    cmd.Parameters.AddWithValue("@BP", Period);
                    cmd.Parameters.AddWithValue("@CON", ConsTb.Text);
                    cmd.Parameters.AddWithValue("@RA", RateTb.Text);
                    cmd.Parameters.AddWithValue("@TAX", TaxTb.Text);
                    cmd.Parameters.AddWithValue("@TOTA", Total);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Billing Added !!");
                    Con.Close();
                    ShowBill();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) // Edit
        {
            if (RateTb.Text == "" || TaxTb.Text == "" || ConsTb.Text == "")
            {
                MessageBox.Show("Missing Information !!");
            }
            else
            {
                try
                {
                    int R = Convert.ToInt32(RateTb.Text); //rate
                    int Consumption = Convert.ToInt32(ConsTb.Text); //con
                    int sum = (R * Consumption); // 20 * 35 = 700
                    float Tax = (sum / 100); // 700 / 100 = 7
                    float Total = Tax + sum; // 700 + 7 = 707

                    string Period = BPTb.Value.Month + "/" + BPTb.Value.Year;
                    Con.Open();
                    SqlCommand cmd;
                    if (!string.IsNullOrEmpty(AgentTbl.Text))
                    {
                        cmd = new SqlCommand("UPDATE BillTbl SET Cid = @CI, Agent = @AG, BillPeriod = @BP, Consumption = @CON, Rate = @RA, Tax = @TAX, Total = @TOTA WHERE BNum = @BNum", Con);
                        cmd.Parameters.AddWithValue("@AG", AgentTbl.Text);
                    }
                    else
                    {
                        cmd = new SqlCommand("UPDATE BillTbl SET Cid = @CI, BillPeriod = @BP, Consumption = @CON, Rate = @RA, Tax = @TAX, Total = @TOTA WHERE BNum = @BNum", Con);
                    }

                    cmd.Parameters.AddWithValue("@CI", CIdCb.SelectedValue.ToString()); //Consumption BillPriod
                    cmd.Parameters.AddWithValue("@BP", Period);
                    cmd.Parameters.AddWithValue("@CON", ConsTb.Text);
                    cmd.Parameters.AddWithValue("@RA", RateTb.Text);
                    cmd.Parameters.AddWithValue("@TAX", TaxTb.Text);
                    cmd.Parameters.AddWithValue("@TOTA", Total);
                    cmd.Parameters.AddWithValue("@BNum", key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Billing Updated!!");
                    Con.Close();
                    ShowBill();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) // Delete
        {
            if (BillDGV.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int selectedId = Convert.ToInt32(BillDGV.SelectedRows[0].Cells[0].Value);

                        Con.Open();

                        SqlCommand cmd = new SqlCommand("DELETE FROM BillTbl WHERE BNum = @BNum", Con);
                        cmd.Parameters.AddWithValue("@BNum", selectedId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        Con.Close();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ShowBill();
                        }
                        else
                        {
                            MessageBox.Show("No record was deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while deleting the record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a record to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BillDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                CIdCb.SelectedValue = BillDGV.SelectedRows[0].Cells[1].Value.ToString();
                AgentTbl.Text = BillDGV.SelectedRows[0].Cells[2].Value.ToString();
                ConsTb.Text = BillDGV.SelectedRows[0].Cells[4].Value.ToString();
                RateTb.Text = BillDGV.SelectedRows[0].Cells[5].Value.ToString();
                TaxTb.Text = BillDGV.SelectedRows[0].Cells[6].Value.ToString();
                if (ConsTb.Text == "")
                {
                    key = 0;
                }
                else
                {
                    key = Convert.ToInt32(BillDGV.SelectedRows[0].Cells[0].Value.ToString());
                }
            }
        }

        private void GetCons()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select Cid from ConsumerTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Cid", typeof(int));
            dt.Load(Rdr);
            CIdCb.ValueMember = "Cid";
            CIdCb.DataSource = dt;
            Con.Close();
        }

        private void GetConsRate()
        {
            Con.Open();
            string Query = "select * from ConsumerTbl where Cid=" + CIdCb.SelectedValue.ToString() + " ";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                RateTb.Text = dr["CRate"].ToString();
            }
            Con.Close();
        }

        private void Reset() // resert
        {
            CIdCb.SelectedIndex = -1;
            RateTb.Text = "";
            TaxTb.Text = "";
            CIdCb.Text = "";
            AgentTbl.Text = "";
            key = 0;

        }
        private void CIdCb_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            GetConsRate();
        }

        private void pictureBox1_Click(object sender, EventArgs e) // go to consumer add page
        {
            Agent obj = new Agent();
            obj.Show();
            this.Hide();
        }
    }

}