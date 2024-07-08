using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaterBilling
{
    public partial class Splash : Form
    {
        int tt;
        public Splash()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            timer1.Start();
            tt = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ( tt <= 1 )
            {
                IbTimer.Text = IbTimer.Text+".";
                tt++;
            }
            else
            {
                // colling login screen or funcation
                 timer1.Stop();
                 Main_Home login = new Main_Home();
                 login.Show();
                 this.Hide();
            }

        }
    }
}
