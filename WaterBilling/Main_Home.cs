using System;
using System.Drawing;
using System.Windows.Forms;

namespace WaterBilling
{
    public partial class Main_Home : Form
    {
        private bool sidebarExpanded = true;

        public Main_Home()
        {
            InitializeComponent();
        }
        private void sideberTrans_Tick(object sender, EventArgs e)
        {
            if (sidebarExpanded)
            {
                slidebar.Width -= 5;

                if (slidebar.Width <= 60)
                {
                    sidebarExpanded = false;
                    sideberTrans.Stop();
                }
            }
            else // If the sidebar is collapsed
            {
                slidebar.Width += 5;

                if (slidebar.Width >= 240)
                {
                    sidebarExpanded = true;
                    sideberTrans.Stop();
                }
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            sideberTrans.Start();
        }

        private void button28_Click(object sender, EventArgs e) // Consumer
        {
            ConsumerLogin obj = new ConsumerLogin();
            obj.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e) // Agent
        {
            AgentLogin obj = new AgentLogin();
            obj.Show();
            this.Hide();
        }

        private void button43_Click(object sender, EventArgs e) // Admin
        {
            AdminLogin obj = new AdminLogin();
            obj.Show();
            this.Hide();
        }
        private void button55_Click(object sender, EventArgs e) // New Connecation
        {
            New_connecation obj = new New_connecation();
            obj.Show();
            this.Hide();
        }
        private void button58_Click(object sender, EventArgs e) // Info
        {
           Form Background = new Form();
            Info Model = new Info();
            using (Model)
            {
                Background.StartPosition = FormStartPosition.Manual;
                Background.FormBorderStyle = FormBorderStyle.None;
                Background.Opacity = .50d;
                Background.BackColor = Color.Black;
                Background.Size = this.Size;
                Background.Location = this.Location;
                Background.ShowInTaskbar = false;
                Background.Show(this);
                Model.Owner = Background;
                Model.ShowDialog(Background);
                Background.Dispose();
            }
        }
        private void button71_Click(object sender, EventArgs e) //Application Exit
        {
            Application.Exit();
        }
        private void panel23_Paint(object sender, PaintEventArgs e) // Timer
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e) // Timer track
        {
            label2.Text = DateTime.Now.ToLongTimeString();
            label3.Text = DateTime.Now.ToLongDateString();
        }
        private void pictureBox4_Click(object sender, EventArgs e) //Information iamage
        {
            Information obj = new Information();
            obj.Show();
            this.Hide();
        }

    }
}
