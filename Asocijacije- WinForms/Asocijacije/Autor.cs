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
    public partial class Autor : Form
    {
        int vreme = 0;
        public Autor()
        {
            InitializeComponent();
            Random rnd = new Random(DateTime.Now.Ticks.GetHashCode());
            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            label1.Hide();
            this.BackColor = randomColor;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (prikaz.Height<600) {
                prikaz.Size = new Size(prikaz.Width + 20, prikaz.Height + 20);
                prikaz.Location = new Point(prikaz.Location.X, prikaz.Location.Y - 15);
            }
            if (prikaz.Height > 600)
                label1.Show();
            vreme++;
            if (vreme==100)
            {
                this.Close();
            }
        }
    }
}
