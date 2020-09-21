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
    public partial class Highscores : Form
    {
        public Highscores(List<Rezultat> r)
        {
            
            int j = 1;
            InitializeComponent();
            for(int i=0;i<5;i++)
            {
                Control l = this.Controls.Find("label" + j.ToString(), true)[0];
                l.Text = r[i].Ime;
                j++;
                Control le = this.Controls.Find("label" + j.ToString(), true)[0];
                le.Text = r[i].vreme.ToString();
                j++;
                Control lee = this.Controls.Find("label" + j.ToString(), true)[0];
                lee.Text = r[i].termin.ToString();
                j++;


                Random ra = new Random();
                Color randomColor = Color.FromArgb(ra.Next(256), ra.Next(256), ra.Next(256));
                this.BackColor = randomColor;
            }
            label18.Text = r[0].resenje;
            label22.Text = r[1].resenje;
            label23.Text = r[2].resenje;
            label24.Text = r[3].resenje;
            label25.Text = r[4].resenje;
            pictureBox1.Image = Properties.Resources.x
                ;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
