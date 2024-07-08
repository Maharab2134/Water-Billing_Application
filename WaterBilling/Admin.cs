using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace WaterBilling
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            ShowAgents();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=MAHARAB-HOSEN\SQLEXPRESS;Initial Catalog=WaterBillingDb;Integrated Security=True;Connect Timeout=30;Encrypt=False");
        public void ShowAgents()
        {
            Con.Open();
            string Query = "select AgNum as Code, AgName as Name, AgPhone as Phone,AgAdd as Address,AgPass as Paswword  from AgentTbl";
            SqlDataAdapter adapter = new SqlDataAdapter(Query,Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            AgentsDGV.DataSource = ds.Tables[0];

            Con.Close();
        }
        private void SaveBtn_Click(object sender, EventArgs e) // add
        {
            if (AgNameTbl.Text == "" || AgPassTbl.Text == "" || AgPhoneTbl.Text == "" || AgAddTbl.Text == "")
            {
                MessageBox.Show("Messing Information !!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into AgentTbl(AgName,AgPhone,AgAdd,AgPass) values(@AN,@AP,@AA,@APa)", Con);
                    cmd.Parameters.AddWithValue("@AN", AgNameTbl.Text);
                    cmd.Parameters.AddWithValue("@APa", AgPassTbl.Text);
                    cmd.Parameters.AddWithValue("@AP", AgPhoneTbl.Text);
                    cmd.Parameters.AddWithValue("@AA", AgAddTbl.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Agent Added !!");
                    Con.Close();
                    ShowAgents();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            } 
        }
        int key = 0;
        private void AgentsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AgNameTbl.Text = AgentsDGV.SelectedRows[0].Cells[1].Value.ToString();
            AgPhoneTbl.Text = AgentsDGV.SelectedRows[0].Cells[2].Value.ToString();
            AgAddTbl.Text = AgentsDGV.SelectedRows[0].Cells[3].Value.ToString();
            AgPassTbl.Text = AgentsDGV.SelectedRows[0].Cells[4].Value.ToString();

            if (AgNameTbl.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(AgentsDGV.SelectedRows[0].Cells[0].Value.ToString());
            }

        }
        private void EditeBtn_Click(object sender, EventArgs e) // edite
        {
            if (AgNameTbl.Text == "" || AgPassTbl.Text == "" || AgPhoneTbl.Text == "" || AgAddTbl.Text == "")
            {
                MessageBox.Show("Messing Information !!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update AgentTbl set AgName = @AN, AgPhone = @AP, AgAdd = @AA, AgPass= @APa where AgNum = @AKey", Con);
                    cmd.Parameters.AddWithValue("@AN", AgNameTbl.Text);
                    cmd.Parameters.AddWithValue("@AP", AgPhoneTbl.Text);
                    cmd.Parameters.AddWithValue("@AA", AgAddTbl.Text);
                    cmd.Parameters.AddWithValue("@APa", AgPassTbl.Text);
                    cmd.Parameters.AddWithValue("@AKey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Agent Update !!");
                    Con.Close();
                    ShowAgents();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void Reset()
        {
            AgNameTbl.Text = "";
            AgAddTbl.Text = "";
            AgPhoneTbl.Text = "";
            AgPassTbl.Text = "";
            key = 0;
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0 ) 
            {
                MessageBox.Show("Select The Agent To Be Delete !!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from AgentTbl where AgNum = @AKey", Con);
                    cmd.Parameters.AddWithValue("@AKey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Agent Delete !!");
                    Con.Close();
                    ShowAgents();
                    Reset() ;
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e) // image
        {
            AdminLogin obj = new AdminLogin();
            obj.Show();
            this.Hide();
        }

        private void label5_Click_1(object sender, EventArgs e) //deshbord
        { 
            Dashboard obj = new Dashboard();
            obj.Show(); 
            this.Hide();

        }


        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Dashboard obj = new Dashboard();
            obj.Show();
            this.Hide();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            Messagebox obj = new Messagebox();
            obj.Show();
            this.Hide();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            ComplentBox obj = new ComplentBox();
            obj.Show();
            this.Hide();
        }

    }
}
