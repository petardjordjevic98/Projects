using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace Asocijacije
{
    public partial class Asocijacija : Form
    {//dodati jos nekoliko pesama, i dodati sve asocijacije
        public ListaAss Assoc { get; set; }
        public string Korisnik { get; set; }
        public List<Rezultat> highscores { get; set; }
        System.Media.SoundPlayer p = new System.Media.SoundPlayer();
        System.Media.SoundPlayer pesma = new System.Media.SoundPlayer();
        public int TimeNow{get;set;}
        private Rectangle a1;
        private Rectangle a2;
        private Rectangle a3;
        private Rectangle a4;
        private Rectangle a;
        private Rectangle b1;
        private Rectangle b2;
        private Rectangle b3;
        private Rectangle b4;
        private Rectangle b;
        private Rectangle c1;
        private Rectangle c2;
        private Rectangle c3;
        private Rectangle c4;
        private Rectangle c;
        private Rectangle d1;
        private Rectangle d2;
        private Rectangle d3;
        private Rectangle d4;
        private Rectangle d;
        private Rectangle k;
        private Rectangle v;
        private Rectangle kom;
        private Rectangle slika;
        private Size Forma;

        Random random1 = new Random();
        int trenutna;
        public Asocijacija(string s)
        {
            Korisnik = s;
            InitializeComponent();
        }

        private void Asocijacija_Load(object sender, EventArgs e)
        {
            highscores = new List<Rezultat>();
            using (StreamReader readtext = new StreamReader("highscores.txt"))
            {
                for (int i = 0; i < 5; i++)
                {
                    string Ime = readtext.ReadLine();
                    int vrme = Int32.Parse(readtext.ReadLine());
                    DateTime t = Convert.ToDateTime(readtext.ReadLine());
                    string resenje= readtext.ReadLine();
                    Rezultat rez = new Rezultat(Ime, vrme, t,resenje);
                    highscores.Add(rez);
                }
            }
            using (StreamReader readtext1 = new StreamReader("trenutna.txt"))
            {
                trenutna = Int32.Parse(readtext1.ReadLine());

            }
            TimeNow = 0;
            timerZaIgru.Start();
            vreme.Show();
            vreme.Text = "0";
            Assoc = new ListaAss();
            if (trenutna == Assoc.A.Count())
            {
                trenutna = 0;
                
            }
            Color boja = Color.FromArgb(random1.Next(256), random1.Next(256), random1.Next(256));
            Random rnd = new Random(DateTime.Now.Ticks.GetHashCode());
            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

            this.BackColor = randomColor;
            menuStrip1.BackColor = randomColor;
            Random r = new Random(DateTime.Now.Ticks.GetHashCode()+1);
            foreach( Control co in this.Controls)
                {
                if (co is Button)
                    co.BackColor = boja;
                if (co is TextBox)
                    co.BackColor = boja;
            }
            this.CenterToScreen();
            komenatar.ForeColor = Color.White;
            Forma = this.Size;
            kom= new Rectangle(komenatar.Location.X, komenatar.Location.Y, komenatar.Width, komenatar.Height);
            slika = new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
            v = new Rectangle(vreme.Location.X, vreme.Location.Y, vreme.Width, vreme.Height);
            a1 = new Rectangle(cmd_a1.Location.X, cmd_a1.Location.Y, cmd_a1.Width, cmd_a1.Height);
            a2 = new Rectangle(cmd_a2.Location.X, cmd_a2.Location.Y, cmd_a2.Width, cmd_a2.Height);
            a3 = new Rectangle(cmd_a3.Location.X, cmd_a3.Location.Y, cmd_a3.Width, cmd_a3.Height);
            a4 = new Rectangle(cmd_a4.Location.X, cmd_a4.Location.Y, cmd_a4.Width, cmd_a4.Height);
            a = new Rectangle(txt_a.Location.X, txt_a.Location.Y, txt_a.Width, txt_a.Height);

            b1 = new Rectangle(cmd_b1.Location.X, cmd_b1.Location.Y, cmd_b1.Width, cmd_b1.Height);
            b2 = new Rectangle(cmd_b2.Location.X, cmd_b2.Location.Y, cmd_b2.Width, cmd_b2.Height);
            b3 = new Rectangle(cmd_b3.Location.X, cmd_b3.Location.Y, cmd_b3.Width, cmd_b3.Height);
            b4 = new Rectangle(cmd_b4.Location.X, cmd_b4.Location.Y, cmd_b4.Width, cmd_b4.Height);
            b = new Rectangle(txt_b.Location.X, txt_b.Location.Y, txt_b.Width, txt_b.Height);

            c1 = new Rectangle(cmd_c1.Location.X, cmd_c1.Location.Y, cmd_c1.Width, cmd_c1.Height);
            c2 = new Rectangle(cmd_c2.Location.X, cmd_c2.Location.Y, cmd_c2.Width, cmd_c2.Height);
            c3 = new Rectangle(cmd_c3.Location.X, cmd_c3.Location.Y, cmd_c3.Width, cmd_c3.Height);
            c4 = new Rectangle(cmd_c4.Location.X, cmd_c4.Location.Y, cmd_c4.Width, cmd_c4.Height);
            c = new Rectangle(txt_c.Location.X, txt_c.Location.Y, txt_c.Width, txt_c.Height);

            d1 = new Rectangle(cmd_d1.Location.X, cmd_d1.Location.Y, cmd_d1.Width, cmd_d1.Height);
            d2 = new Rectangle(cmd_d2.Location.X, cmd_d2.Location.Y, cmd_d2.Width, cmd_d2.Height);
            d3 = new Rectangle(cmd_d3.Location.X, cmd_d3.Location.Y, cmd_d3.Width, cmd_d3.Height);
            d4 = new Rectangle(cmd_d4.Location.X, cmd_d4.Location.Y, cmd_d4.Width, cmd_d4.Height);
            d = new Rectangle(txt_d.Location.X, txt_d.Location.Y, txt_d.Width, txt_d.Height);


            k = new Rectangle(txt_konacno.Location.X, txt_konacno.Location.Y, txt_konacno.Width, txt_konacno.Height);
            this.WindowState = FormWindowState.Maximized;
        }

        private void resizeAllControls()
        {
            resizeControl(a1, cmd_a1);
            resizeControl(a2, cmd_a2);
            resizeControl(a3, cmd_a3);
            resizeControl(a4, cmd_a4);
            resizeControl(a, txt_a);
            resizeControl(b1, cmd_b1);
            resizeControl(b2, cmd_b2);
            resizeControl(b3, cmd_b3);
            resizeControl(b4, cmd_b4);
            resizeControl(b, txt_b);
            resizeControl(c1, cmd_c1);
            resizeControl(c2, cmd_c2);
            resizeControl(c3, cmd_c3);
            resizeControl(c4, cmd_c4);
            resizeControl(c, txt_c);
            resizeControl(d1, cmd_d1);
            resizeControl(d2, cmd_d2);
            resizeControl(d3, cmd_d3);
            resizeControl(d4, cmd_d4);
            resizeControl(slika, pictureBox1);
            resizeControl(d, txt_d);
            resizeControl(kom, komenatar);
            resizeControl(k, txt_konacno);
            resizeControl(v, vreme);
        }

        private void resizeControl(Rectangle rect, Control control)
        {
            float xRatio= (float)(this.Width)/(float)(Forma.Width);
            float yRatio = (float)(this.Height) / (float)(Forma.Height);

            int newX = (int)(rect.X * xRatio);
            int newY = (int)(rect.Y * yRatio);
            int newWidth = (int)(rect.Width * xRatio);
            int newHeight = (int)(rect.Height * yRatio);
           
            
            control.Location = new Point(newX, newY);
            control.Size = new Size(newWidth, newHeight);
        }

        private void Asocijacija_Resize(object sender, EventArgs e)
        {
            resizeAllControls();
        }

        private void cmd_a1_Click(object sender, EventArgs e)
        {
            cmd_a1.Text = Assoc.vrati(trenutna).a1;


            TimeNow += 10;
            cmd_a1.BackColor = Color.Red;


        }


        private void cmd_a2_Click(object sender, EventArgs e)
        {
            TimeNow += 10;

            cmd_a2.Text = Assoc.vrati(trenutna).a2;
            cmd_a2.BackColor = Color.Red;
            


        }

        private void cmd_a3_Click(object sender, EventArgs e)
        {
            TimeNow += 10;


            cmd_a3.Text = Assoc.vrati(trenutna).a3;
            


            cmd_a3.BackColor = Color.Red;
        }

        private void cmd_a4_Click(object sender, EventArgs e)
        {

            TimeNow += 10;


            cmd_a4.Text = Assoc.vrati(trenutna).a4;
            cmd_a4.BackColor = Color.Red;
        }

        private void cmd_b1_Click(object sender, EventArgs e)
        {
            TimeNow += 10;

            cmd_b1.Text = Assoc.vrati(trenutna).b1;


            

            cmd_b1.BackColor = Color.Red;
        }

        private void cmd_b2_Click(object sender, EventArgs e)
        {
            cmd_b2.Text = Assoc.vrati(trenutna).b2;

            TimeNow += 10;


            cmd_b2.BackColor = Color.Red;
        }

        private void cmd_b3_Click(object sender, EventArgs e)
        {
            cmd_b3.Text = Assoc.vrati(trenutna).b3;
            TimeNow += 10;



            cmd_b3.BackColor = Color.Red;
        }

        private void cmd_b4_Click(object sender, EventArgs e)
        {
            cmd_b4.Text = Assoc.vrati(trenutna).b4;
            cmd_b4.BackColor = Color.Red;
            TimeNow += 10;



        }

        private void cmd_c4_Click(object sender, EventArgs e)
        {
            cmd_c4.Text = Assoc.vrati(trenutna).c4;


            TimeNow += 10;

            cmd_c4.BackColor = Color.Red;
        }

        private void cmd_c3_Click(object sender, EventArgs e)
        {
            cmd_c3.Text = Assoc.vrati(trenutna).c3;
            cmd_c3.BackColor = Color.Red;

            TimeNow += 10;


        }

        private void cmd_c2_Click(object sender, EventArgs e)
        {
            cmd_c2.Text = Assoc.vrati(trenutna).c2;


            TimeNow += 10;

            cmd_c2.BackColor = Color.Red;
        }

        private void cmd_c1_Click(object sender, EventArgs e)
        {
            cmd_c1.Text = Assoc.vrati(trenutna).c1;
            cmd_c1.BackColor = Color.Red;

            TimeNow += 10;


        }

        private void cmd_d4_Click(object sender, EventArgs e)
        {
            cmd_d4.Text = Assoc.vrati(trenutna).d4;

            TimeNow += 10;


            cmd_d4.BackColor = Color.Red;
        }

        private void cmd_d3_Click(object sender, EventArgs e)
        {
            cmd_d3.Text = Assoc.vrati(trenutna).d3;

            TimeNow += 10;


            cmd_d3.BackColor = Color.Red;
        }

        private void cmd_d2_Click(object sender, EventArgs e)
        {
            cmd_d2.Text = Assoc.vrati(trenutna).d2;

            TimeNow += 10;

            cmd_d2.BackColor = Color.Red;
        }

        private void cmd_d1_Click(object sender, EventArgs e)
        {
            cmd_d1.Text = Assoc.vrati(trenutna).d1;
            cmd_d1.BackColor = Color.Red; TimeNow += 10;

        }

        private void txt_a_KeyDown(object sender, KeyEventArgs e)
        {
            int iks = 0;
            if (e.KeyCode==Keys.Enter)
            {
                foreach (string A1 in Assoc.vrati(trenutna).a)
                    if (A1.Equals(txt_a.Text))
                    {
                        iks = 1; cmd_a1_Click(sender, e);
                        cmd_a2_Click(sender, e);
                        cmd_a3_Click(sender, e);
                        cmd_a4_Click(sender, e);
                        txt_a.Text = Assoc.vrati(trenutna).a[0];
                        txt_a.ReadOnly = true;
                        txt_a.BackColor = Color.Red;
                        TimeNow -= 40;


                        //txt_a.Enabled = false;

                    }
                if (iks == 0)
                {
                 //  

                   
                    txt_a.Clear();
                    txt_a.Focus();
                    SendKeys.Send("{BACKSPACE}");
                }
                }
        }
        private void txt_b_KeyDown(object sender, KeyEventArgs e)
        {
            int iks = 0;
            if (e.KeyCode == Keys.Enter)
            {
                foreach (string A1 in Assoc.vrati(trenutna).b)
                    if (A1.Equals(txt_b.Text))
                    {
                        cmd_b1_Click(sender, e);
                        cmd_b2_Click(sender, e);
                        cmd_b3_Click(sender, e);
                        cmd_b4_Click(sender, e);
                        txt_b.Text = Assoc.vrati(trenutna).b[0];
                        txt_b.ReadOnly = true;
                        txt_b.BackColor = Color.Red;
                        TimeNow -= 40;

                        iks++;
                    }
                if (iks == 0)
                {
                    txt_b.Clear();
                    txt_b.Focus();
                    SendKeys.Send("{BACKSPACE}");

                }
            }
        }
        private void txt_c_KeyDown(object sender, KeyEventArgs e)
        {
            int iks = 0;
            if (e.KeyCode == Keys.Enter)
            {
                foreach (string A1 in Assoc.vrati(trenutna).c)
                    if (A1.Equals(txt_c.Text))
                    {
                        iks++;
                        cmd_c1_Click(sender, e);
                        cmd_c2_Click(sender, e);
                        cmd_c3_Click(sender, e);
                        cmd_c4_Click(sender, e);
                        txt_c.Text = Assoc.vrati(trenutna).c[0];
                        txt_c.ReadOnly = true;
                        txt_c.BackColor = Color.Red;
                        TimeNow -= 40;

                        //txt_c.Enabled = false;

                    }
                if (iks == 0)
                {
             
                    txt_c.Clear();
                    txt_c.Focus();
                    SendKeys.Send("{BACKSPACE}");

                }
            }
        }
        private void txt_d_KeyDown(object sender, KeyEventArgs e)
        {
            int iks = 0;

            if (e.KeyCode == Keys.Enter)
            {
                foreach (string A1 in Assoc.vrati(trenutna).d)
                    if (A1.Equals(txt_d.Text))
                    {
                        iks++;
                        cmd_d1_Click(sender, e);
                        cmd_d2_Click(sender, e);
                        cmd_d3_Click(sender, e);
                        cmd_d4_Click(sender, e);
                        txt_d.Text = Assoc.vrati(trenutna).d[0];
                        txt_d.ReadOnly = true;
                        txt_d.BackColor = Color.Red;
                        TimeNow -= 40;

                        //txt_d.Enabled = false;
                    }
                if (iks == 0)
                {
                 
                    txt_d.Clear();
                    txt_d.Focus();
                    SendKeys.Send("{BACKSPACE}");
                }
            }
            
        }

        private void txt_konacno_KeyDown(object sender, KeyEventArgs e)
        {
            int iks = 0;
            if (e.KeyCode == Keys.Enter)
            {
                foreach (string A1 in Assoc.vrati(trenutna).konacno)
                    if (A1.Equals(txt_konacno.Text))
                    {
                        iks++;
                       cmd_a1_Click(sender,null);
                        cmd_a2_Click(sender, null);
                        cmd_a3_Click(sender, null);
                        cmd_a4_Click(sender, null);
                        cmd_b1_Click(sender, null);
                        cmd_b2_Click(sender, null);
                        cmd_b3_Click(sender, null);
                        cmd_b4_Click(sender, null); cmd_d1_Click(sender, null);
                        cmd_d2_Click(sender, null);
                        cmd_d3_Click(sender, null);
                        cmd_d4_Click(sender, null); cmd_c1_Click(sender, null);
                        cmd_c2_Click(sender, null);
                        cmd_c3_Click(sender, null);
                        cmd_c4_Click(sender, null);
                        TimeNow -= 160;

                        txt_d.Text = Assoc.vrati(trenutna).d[0];
                        txt_d.ReadOnly = true;
                        txt_d.BackColor = Color.Red;
                        txt_b.Text = Assoc.vrati(trenutna).b[0];
                        txt_b.ReadOnly = true;
                        txt_b.BackColor = Color.Red;
                        txt_a.Text = Assoc.vrati(trenutna).a[0];
                        txt_a.ReadOnly = true;
                        txt_a.BackColor = Color.Red;
                        txt_c.Text = Assoc.vrati(trenutna).c[0];
                        txt_c.ReadOnly = true;
                        txt_c.BackColor = Color.Red;
                        txt_konacno.Text = Assoc.vrati(trenutna).konacno[0];
                        txt_konacno.ReadOnly = true;
                        txt_konacno.BackColor = Color.Red;
                        pictureBox1.Hide();
                        komenatar.Hide();
                        timerZaIgru.Stop();
                        Rezultat rezul = new Rezultat(Korisnik, Int32.Parse(vreme.Text), DateTime.Now,txt_konacno.Text);
                        highscores.Add(rezul);
                        for (int j = 0; j < highscores.Count() - 1; j++)
                            for(int p = j;p <highscores.Count();p++)
                                if (highscores[j].vreme>highscores[p].vreme)
                                {
                                    Rezultat temp = highscores[j];
                                    highscores[j] = highscores[p];
                                    highscores[p] = temp;
                                }
                        using (StreamWriter writetext = new StreamWriter("highscores.txt"))
                        {
                           
                           for(int i=0;i<5;i++)
                            {
                                writetext.WriteLine(highscores[i].Ime);
                                writetext.WriteLine(highscores[i].vreme);
                                writetext.WriteLine(highscores[i].termin);
                                writetext.WriteLine(highscores[i].resenje);
                            }
                                    }

                        using (StreamWriter writetext = new StreamWriter("trenutna.txt"))
                        {
                            trenutna++;
                            writetext.WriteLine(trenutna);
                        }
                            Bravo a = new Bravo(Korisnik, TimeNow.ToString());
                        timerZaIgru.Stop();

                        a.ShowDialog();
                        vreme.Hide();
                        button2.Enabled = false;
                    }
                if (iks == 0)
                {
                 
                    txt_konacno.Clear();
                    txt_konacno.Focus();
                    SendKeys.Send("{BACKSPACE}");
                }                label2.Text = (Assoc.A.Count()- trenutna).ToString();
            }
        }

        private void timerZaIgru_Tick(object sender, EventArgs e)
        {
            TimeNow++;
            if (TimeNow == 30 || TimeNow==60 || TimeNow==100 || TimeNow==150 || TimeNow ==200 || TimeNow ==300 || TimeNow==250|| TimeNow==400)
            {
                komenatar.Show();
                pictureBox1.Show();
                    if (Korisnik.Equals("Jelkic"))
                    {
                        pictureBox1.Image = Properties.Resources.pepa1;
                        komenatar.Text = "Jelkicu moj debeljko, nije valjda da ne znaas?";
                    }
                    else
                    {
                        pictureBox1.Image = Properties.Resources.pepa1;
                        komenatar.Text = "Sta je bilo, " + Korisnik + ", ne ide?";
                   }
                
               
            }
            if (TimeNow==40 || TimeNow==70 || TimeNow==110|| TimeNow == 160 || TimeNow == 210 || TimeNow == 310 || TimeNow == 260 || TimeNow == 410 )
            {
                pictureBox1.Hide();
                komenatar.Hide();
            }
            vreme.Text = TimeNow.ToString();
             
        }
       
       

        private void All_MouseHover(object sender, EventArgs e)
        {
            ((Button)sender).FlatAppearance.BorderColor = Color.Red;

        }
        private void All_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).FlatAppearance.BorderColor = Color.White;
        }

        private void highscoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Highscores r = new Highscores(highscores);
            timerZaIgru.Stop();

            r.ShowDialog();
            timerZaIgru.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;

            cmd_a1_Click(sender, null);
            cmd_a2_Click(sender, null);
            cmd_a3_Click(sender, null);
            cmd_a4_Click(sender, null);
            cmd_b1_Click(sender, null);
            cmd_b2_Click(sender, null);
            cmd_b3_Click(sender, null);
            cmd_b4_Click(sender, null); cmd_d1_Click(sender, null);
            cmd_d2_Click(sender, null);
            cmd_d3_Click(sender, null);
            cmd_d4_Click(sender, null); cmd_c1_Click(sender, null);
            cmd_c2_Click(sender, null);
            cmd_c3_Click(sender, null);
            cmd_c4_Click(sender, null);
         
            txt_d.Text = Assoc.vrati(trenutna).d[0];
            txt_d.ReadOnly = true;
            txt_d.BackColor = Color.Red;
            txt_b.Text = Assoc.vrati(trenutna).b[0];
            txt_b.ReadOnly = true;
            txt_b.BackColor = Color.Red;
            txt_a.Text = Assoc.vrati(trenutna).a[0];
            txt_a.ReadOnly = true;
            txt_a.BackColor = Color.Red;
            txt_c.Text = Assoc.vrati(trenutna).c[0];
            txt_c.ReadOnly = true;
            txt_c.BackColor = Color.Red;
            txt_konacno.Text = Assoc.vrati(trenutna).konacno[0];
            txt_konacno.ReadOnly = true;
            txt_konacno.BackColor = Color.Red;
           using (StreamWriter writetext = new StreamWriter("trenutna.txt"))
            {
                trenutna++;
                if (trenutna == Assoc.A.Count())
                    trenutna = 0;
                writetext.WriteLine(trenutna);
            }
           
            timerZaIgru.Stop();
            vreme.Hide();
            label2.Text = (Assoc.A.Count()- trenutna).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            highscores = new List<Rezultat>();
            using (StreamReader readtext = new StreamReader("highscores.txt"))
            {
                for (int i = 0; i < 5; i++)
                {
                    string Ime = readtext.ReadLine();
                    int vrme = Int32.Parse(readtext.ReadLine());
                    DateTime t = Convert.ToDateTime(readtext.ReadLine());
                    string resenje = readtext.ReadLine();
                    Rezultat rez = new Rezultat(Ime, vrme, t,resenje);
                    highscores.Add(rez);
                }
            }
            if(trenutna==Assoc.A.Count())
                trenutna=0;
            using (StreamWriter writetext = new StreamWriter("trenutna.txt"))
            {
                writetext.WriteLine(trenutna);
            }
            TimeNow = 0;
            txt_konacno.Text = "";
            txt_konacno.ReadOnly = false;
            timerZaIgru.Start();
            vreme.Show();
            vreme.Text = "0";
            cmd_a1.Text = "A1";
            cmd_a2.Text = "A2";
            cmd_a3.Text = "A3";
            cmd_a4.Text = "A4";
            txt_a.ReadOnly = false;
            txt_a.Text = "";
            cmd_b1.Text = "B1";
            cmd_b2.Text = "B2";
            cmd_b3.Text = "B3";
            cmd_b4.Text = "B4";
            txt_b.ReadOnly = false;
            txt_b.Text = "";
            cmd_c1.Text = "A1";
            cmd_c2.Text = "A2";
            cmd_c3.Text = "A3";
            cmd_c4.Text = "A4";
            txt_c.ReadOnly = false;
            cmd_d1.Text = "A1";
            cmd_d2.Text = "A2";
            cmd_d3.Text = "A3";
            cmd_d4.Text = "A4";
            txt_d.ReadOnly = false;
            txt_c.Text = "";
            txt_d.Text = "";
            txt_b.Text = "";
            label2.Text = (Assoc.A.Count()- trenutna).ToString();



            Color boja = Color.FromArgb(random1.Next(256), random1.Next(256), random1.Next(256));
            Random rnd = new Random(DateTime.Now.Ticks.GetHashCode());
            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

            this.BackColor = randomColor;
            menuStrip1.BackColor = randomColor;
            Random r = new Random(DateTime.Now.Ticks.GetHashCode() + 1);
            foreach (Control co in this.Controls)
            {
                if (co is Button)
                    co.BackColor = boja;
                if (co is TextBox)
                    co.BackColor = boja;
            }
            this.CenterToScreen();
            Forma = this.Size;
            v = new Rectangle(vreme.Location.X, vreme.Location.Y, vreme.Width, vreme.Height);
            a1 = new Rectangle(cmd_a1.Location.X, cmd_a1.Location.Y, cmd_a1.Width, cmd_a1.Height);
            a2 = new Rectangle(cmd_a2.Location.X, cmd_a2.Location.Y, cmd_a2.Width, cmd_a2.Height);
            a3 = new Rectangle(cmd_a3.Location.X, cmd_a3.Location.Y, cmd_a3.Width, cmd_a3.Height);
            a4 = new Rectangle(cmd_a4.Location.X, cmd_a4.Location.Y, cmd_a4.Width, cmd_a4.Height);
            a = new Rectangle(txt_a.Location.X, txt_a.Location.Y, txt_a.Width, txt_a.Height);

            b1 = new Rectangle(cmd_b1.Location.X, cmd_b1.Location.Y, cmd_b1.Width, cmd_b1.Height);
            b2 = new Rectangle(cmd_b2.Location.X, cmd_b2.Location.Y, cmd_b2.Width, cmd_b2.Height);
            b3 = new Rectangle(cmd_b3.Location.X, cmd_b3.Location.Y, cmd_b3.Width, cmd_b3.Height);
            b4 = new Rectangle(cmd_b4.Location.X, cmd_b4.Location.Y, cmd_b4.Width, cmd_b4.Height);
            b = new Rectangle(txt_b.Location.X, txt_b.Location.Y, txt_b.Width, txt_b.Height);

            c1 = new Rectangle(cmd_c1.Location.X, cmd_c1.Location.Y, cmd_c1.Width, cmd_c1.Height);
            c2 = new Rectangle(cmd_c2.Location.X, cmd_c2.Location.Y, cmd_c2.Width, cmd_c2.Height);
            c3 = new Rectangle(cmd_c3.Location.X, cmd_c3.Location.Y, cmd_c3.Width, cmd_c3.Height);
            c4 = new Rectangle(cmd_c4.Location.X, cmd_c4.Location.Y, cmd_c4.Width, cmd_c4.Height);
            c = new Rectangle(txt_c.Location.X, txt_c.Location.Y, txt_c.Width, txt_c.Height);

            d1 = new Rectangle(cmd_d1.Location.X, cmd_d1.Location.Y, cmd_d1.Width, cmd_d1.Height);
            d2 = new Rectangle(cmd_d2.Location.X, cmd_d2.Location.Y, cmd_d2.Width, cmd_d2.Height);
            d3 = new Rectangle(cmd_d3.Location.X, cmd_d3.Location.Y, cmd_d3.Width, cmd_d3.Height);
            d4 = new Rectangle(cmd_d4.Location.X, cmd_d4.Location.Y, cmd_d4.Width, cmd_d4.Height);
            d = new Rectangle(txt_d.Location.X, txt_d.Location.Y, txt_d.Width, txt_d.Height);


            k = new Rectangle(txt_konacno.Location.X, txt_konacno.Location.Y, txt_konacno.Width, txt_konacno.Height);
            button2.Enabled = true;
        }

        private void akoTrazisNekogaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pesma.SoundLocation = "AkoTrazis.wav";
            pesma.Play();
        }

        private void svadbarskimSokakomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pesma.Stop();
            pesma.SoundLocation = "Sokak.wav";
            pesma.Play();
        }

        private void oAutoruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Autor a = new Autor();
            timerZaIgru.Stop();

            a.ShowDialog();
            timerZaIgru.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog()==DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
                menuStrip1.BackColor = colorDialog1.Color;
            }
        }

        private void zuteDunjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pesma.Stop();
            pesma.SoundLocation = "dunje.wav";
            pesma.Play();
        }

        private void pjesmoMojaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pesma.Stop();
            pesma.SoundLocation = "pjesme.wav";
            pesma.Play();
        }

        private void heavenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pesma.Stop();
            pesma.SoundLocation = "heaven.wav";
            pesma.Play();
        }

        private void txt_a_TextChanged(object sender, EventArgs e)
        {
            txt_a.CharacterCasing = CharacterCasing.Upper;
        }

        private void txt_b_TextChanged(object sender, EventArgs e)
        {
            txt_b.CharacterCasing = CharacterCasing.Upper;

        }

        private void txt_konacno_TextChanged(object sender, EventArgs e)
        {
            txt_konacno.CharacterCasing = CharacterCasing.Upper;

        }

        private void txt_c_TextChanged(object sender, EventArgs e)
        {
            txt_c.CharacterCasing = CharacterCasing.Upper;

        }

        private void txt_d_TextChanged(object sender, EventArgs e)
        {
            txt_d.CharacterCasing = CharacterCasing.Upper;

        }
    }
}
