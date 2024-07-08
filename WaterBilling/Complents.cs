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
    public partial class Complenbox : Form
    {
        public Complenbox()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private string connectionString = @"Data Source=MAHARAB-HOSEN\SQLEXPRESS;Initial Catalog=WaterBillingDb;Integrated Security=True;Connect Timeout=30;Encrypt=False";
        private Timer timer;

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 2000; // 2 seconds
            timer.Tick += Timer_Tick; //timer traking and back page
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            Main_Home obj = new Main_Home();
            obj.Show();
            this.Hide();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string complaintDetails = complaintTextBox.Text;

            int complaintId;
            if (!int.TryParse(cidTextBox.Text, out complaintId))
            {
                MessageBox.Show("Please enter a valid complaint ID.");
                return;
            }

            DateTime currentDate = DateTime.Now;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Complaints (cid, date, details) VALUES (@CID, @Date, @Details)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CID", complaintId);
                    cmd.Parameters.AddWithValue("@Date", currentDate);
                    cmd.Parameters.AddWithValue("@Details", complaintDetails);


                    int rowsAffected = cmd.ExecuteNonQuery();


                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Complaint submitted successfully.");

                        cidTextBox.Clear();
                        complaintTextBox.Clear();
                        timer.Start();

                    }
                    else
                    {
                        MessageBox.Show("Failed to submit complaint.");
                    }
                }
            }
        }
        private void guna2PictureBox1_Click_1(object sender, EventArgs e)
        {
            ConsumerHome obj = new ConsumerHome();
            obj.Show();
            this.Hide();
        }
    }
}

