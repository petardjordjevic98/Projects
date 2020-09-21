using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asocijacije
{
    public partial class Bravo : Form
    {
        int vreme = 0; System.Media.SoundPlayer p = new System.Media.SoundPlayer();

        public Bravo(string s,string s1)
        {
            InitializeComponent();
            Random ra = new Random();
            Color randomColor = Color.FromArgb(ra.Next(256), ra.Next(256), ra.Next(256));
            this.BackColor = randomColor;
            label1.Text = "BRAVO, " + s+"!"+"Osvojili ste: +"+s1;
            p.SoundLocation = "jejo.wav";
            p.Play();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            vreme++;
            if (vreme == 50)
            {
                this.Close();
                p.Stop();
            }
        }
    }
}
