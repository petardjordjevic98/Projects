using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asocijacije
{
    public partial class LoadingForm : Form
    {
        Thread th;

        public string Nadimak { get; set; }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
                  int left,
                  int top,
                  int right,
                  int bottom,
                  int width,
                  int height
              );
        int LoadingSpeed = 2;
        float initialPercentage = 0;
        public LoadingForm()
        {

            InitializeComponent();
            Random r = new Random();
            int re = r.Next();
           if (re % 3 == 1)
                pictureBox1.Image = Properties.Resources.cactus;
            else if (re % 3 == 2)
           
              pictureBox1.Image = Properties.Resources.pasta;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 7, 7));


        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            this.BackColor = randomColor;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            initialPercentage += LoadingSpeed;
            float perc = initialPercentage / pictureBox1.Height * 100;
            label2.Text = (int)perc + "%";

            panel1.Location = new Point(panel1.Location.X, panel1.Location.Y + LoadingSpeed);
            if (panel1.Location.Y > pictureBox1.Location.Y + pictureBox1.Height)
            {
                label2.Text = "100 %";
                timer1.Stop();


                Nadimak = ime.Text;

                this.Close();
                th = new Thread(opennewForm);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();

            }

        }
        private void opennewForm(object obj)
        {
            
           
            Application.Run(new Asocijacija(Nadimak));
        }

        
    }
}
