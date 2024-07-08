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
    public partial class ShowBill : Form
    {
        public ShowBill()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection Con = new SqlConnection(@"Data Source=MAHARAB-HOSEN\SQLEXPRESS;Initial Catalog=WaterBillingDb;Integrated Security=True;Connect Timeout=30;Encrypt=False");
                {
                    if (Con.State == ConnectionState.Closed)
                        Con.Open();
                    using (DataTable dt = new DataTable("ConsumerTbl")) 
                    {
                        using (SqlCommand cmd = new SqlCommand("select *from BillTbl where Cid = @Cid ", Con))
                        {
                            cmd.Parameters.AddWithValue("Cid", textSearch.Text);
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        
                    }
                }
            } 
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message,"Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void textSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)15)
                btnSearch.PerformClick();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ConsumerHome obj = new ConsumerHome();
            obj.Show();
            this.Hide();
        }

        private Bitmap bmp;
          
        
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Image logo = Image.FromFile("C:\\Users\\User\\Pictures\\Screenshots\\Logo.png");
            e.Graphics.DrawImage(logo, 10, 10, 120, 120);


            string name = "ARS LTD"; // Title
            Font nameFont = new Font("Arial", 18, FontStyle.Bold);
            SizeF nameSize = e.Graphics.MeasureString(name, nameFont);
            float nameX = (e.PageBounds.Width - nameSize.Width) / 2; 
            e.Graphics.DrawString(name, nameFont, new SolidBrush(SystemColors.HotTrack), nameX, 50);

            string smallText = "Water Distribution Company"; // Deteles
            Font smallFont = new Font("Arial", 10);
            SizeF smallSize = e.Graphics.MeasureString(smallText, smallFont);
            float smallX = (e.PageBounds.Width - smallSize.Width) / 2; // Center horizontally
            e.Graphics.DrawString(smallText, smallFont, Brushes.Black, smallX, 100);


            e.Graphics.DrawImage(bmp, 0, 150); 
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 10;
            bmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();


            dataGridView1.Height = height;
        }
    }
}
