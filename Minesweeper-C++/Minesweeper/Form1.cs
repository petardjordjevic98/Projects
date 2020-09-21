using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Resources;
using Square;

//da meri najduzi i najbrzi potez

namespace Minesweeper
{
    public partial class formMain : Form
    {
        private TableGame tg;
        private int currentDim;
        private int currentNumOfMines;
        private bool firstTime = true;
        private int time = 0;
       private void ZaustaviVreme(object Sender,EventArgs e )
        {
            timer1.Stop();
           // lblmax.Text = tg.maximum.ToString(); 
            MessageBox.Show(lbVreme.Text);
        }
        private void PromeniLabele(object Sender, EventArgs e)
        {
            lblmax.Text = tg.maximum.ToString();
            lblmin.Text = tg.minimum.ToString();
        }
        public formMain()
        {
            InitializeComponent();
            currentDim = 9;
            currentNumOfMines = 10;
            tg = new TableGame(currentDim, currentNumOfMines, panelMain);
            tg.OnKrajIgre += ZaustaviVreme;
            tg.AzuriarajLabele += PromeniLabele;
            lbVreme.Text = "";
            timer1.Start();
        }

        private void formMain_Shown(object sender, EventArgs e)
        {
            ActiveControl = null;
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            Configuration c = new Configuration(tg);
            if (c.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                

                panelMain.Controls.Clear();
                time = 0;
                //for (int i = 0; i < c.Dimension; i++)
                //    for (int j = 0; j < c.Dimension; j++)
                //        System.Console.WriteLine(c.Config[i, j]);
                tg = new TableGame(currentDim, currentNumOfMines, panelMain, c.Config);
              (tg as TableGame).firstTime = false;
            }
            timer1.Start();
        }

        private void panelMain_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                if (firstTime)
                {
                    int btnLeft = (sender as Button).Left;
                    int btnTop = (sender as Button).Top;


                    int x = btnLeft / (sender as Button).Width;
                    int y = btnTop / (sender as Button).Height;
                    Console.WriteLine(x + " " + y);

                    firstTime = false;
                }
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings s = new Settings(currentDim, currentNumOfMines);
            timer1.Stop();
            if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               
                currentDim = s.Dimension;
                currentNumOfMines = s.Mines;
                panelMain.Controls.Clear();
                panelMain.Enabled = true;
                tg = new TableGame(currentDim, currentNumOfMines, panelMain);
                time = 0;

            }
            timer1.Start();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            time = 0;
            timer1.Start();
            panelMain.Controls.Clear();
            panelMain.Enabled = true;
            tg = new TableGame(currentDim, currentNumOfMines, panelMain);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {



            time++;
            DateTime dt = new DateTime();
            lbVreme.Text = dt.AddMilliseconds(time).ToString("mm:ss");
            //tg.Vreme = dt.AddMilliseconds(tg.VremeIzmedju).ToString("ms");
            
            tg.VremeIzmedju++;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            timer1.Stop();
            if (sf.ShowDialog() == DialogResult.OK)
                {
                    /// ako je odabran fajl i kliknuto na "OK", program ce probati
                    /// da snimi objekat u odabrani fajl
                    this.tg.Save(sf.FileName);
                }
            timer1.Start();
        }

        private void lblmax_Click(object sender, EventArgs e)
        {

        }

        //private void formMain_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    timer1.Stop();
        //    MessageBox.Show(lbVreme.Text);
        //}
    }
}
