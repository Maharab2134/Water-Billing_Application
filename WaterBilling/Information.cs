using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Configuration;
using System.ServiceModel.Dispatcher;

namespace WaterBilling
{
    public partial class Information : Form
    {
        public Information()
        {
            InitializeComponent();
        }

        private void Information_Load(object sender, EventArgs e)
        {
            pictureBox1.Region = round(pictureBox1);
            pictureBox2.Region = round(pictureBox2);
            pictureBox3.Region = round(pictureBox3);
            pictureBox4.Region = round(pictureBox4);
            pictureBox5.Region = round(pictureBox5);
        }

        private Region round(PictureBox pictureBox)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse (0, 0, pictureBox.Width, pictureBox.Height);
            Region rgn = new Region(path);
            return rgn;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Main_Home obj = new Main_Home();
            obj.Show();
            this.Hide();
        }
    }
}
