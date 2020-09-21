using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Resources;
using static Square.TableGame;

namespace Square
{
    public abstract class Square
    {
        
        protected int x;
        protected int y;
        protected Button button;
        protected Panel panel;
        protected Table table;

        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }

        public Button Button
        {
            get
            {
                return button;
            }
        }

        public Panel Panel
        {
            get
            {
                return panel;
            }
        }

        public Table Table
        {
            get
            {
                return table;
            }
        }

        public Square(int x, int y, Panel p, Table t, int left, int top)
        {
            this.x = x;
            this.y = y;
            this.panel = p;
            this.table = t;

            button = new Button();
            panel.Controls.Add(button);
            button.BackgroundImageLayout = ImageLayout.Zoom;
            button.Height = button.Width = panel.Width / t.Dimension;
            button.Left = left;
            button.Top = top;
            button.MouseUp += on_click;
        }

        public abstract void on_click(object sender, MouseEventArgs e);
        public abstract void open();
    }

    public class SquareEmpty : Square
    {
        public SquareEmpty(int x, int y, Panel p, Table t, int left, int top)
            : base(x, y, p, t, left, top)
        {

        }

        public override void on_click(object sender, MouseEventArgs e)
        {
           

            if (e.Button == MouseButtons.Left)
            {
                open();
                if (table.VremeIzmedju>table.maximum)
                {
                    table.maximum = table.VremeIzmedju;
                }
                 if (table.VremeIzmedju<table.minimum)
                {
                    table.minimum = table.VremeIzmedju;
                }
                table.VremeIzmedju = 0;
                
                if (((table.Dimension * table.Dimension) - table.NumberOfOpenedSquares) == table.MaxNumberOfMines)
                {
                    MessageBox.Show("You win!");
                    table.openAll();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (button.BackgroundImage == null)
                    button.BackgroundImage = Resources.Properties.Resources.flag_png;
                else if (button.BackgroundImage.Size == Resources.Properties.Resources.flag_png.Size)
                    button.BackgroundImage = Resources.Properties.Resources.question_mark_png;
                else
                    button.BackgroundImage = null;
            }
            table.AzuriarajLabele?.Invoke(null, null);//ovde ga pozivamo,svaki put posle klika
            panel.Focus();
        }

        public override void open()
        {
            table.NumberOfOpenedSquares++;
            List<Square> neighbours = new List<Square>();

            int counter = 0;
            for (int i = x - 1; i < x + 2; i++)
            {
                for (int j = y - 1; j < y + 2; j++)
                {
                    Square tmp = table.findSquare(i, j);
                    if (tmp == null)
                        continue;

                    if (tmp is SquareMine)
                        counter++;
                    else
                        neighbours.Add(tmp);
                }
            }

            if (counter == 0)
            {
                button.Enabled = false;
                foreach (Square s in neighbours)
                {
                    if (s.Button.Enabled == true)
                        s.open();
                }
            }
            else
            {
                button.Enabled = false;
                button.Text = counter.ToString();
            }
        }
    }

    public class SquareMine : Square
    {
        public SquareMine(int x, int y, Panel p, Table t, int left, int top)
            : base(x, y, p, t, left, top)
        {

        }

        public override void on_click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if ((table as TableGame).firstTime)
                {
                    SquareEmpty se = (table as TableGame).exchange(x, y);
                    se.open();

                    (table as TableGame).firstTime = false;
                }
                else
                {
                    MessageBox.Show("Game over!");
                    table.openAll();
                    
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (button.BackgroundImage == null)
                    button.BackgroundImage = Resources.Properties.Resources.flag_png;
                else if (button.BackgroundImage.Size == Resources.Properties.Resources.flag_png.Size)
                    button.BackgroundImage = Resources.Properties.Resources.question_mark_png;
                else
                    button.BackgroundImage = null;
            }

            panel.Focus();
        }

        public override void open()
        {
            button.BackgroundImage = Resources.Properties.Resources.minesweeper_png;
        }
    }

    public class SquareConfig : Square
    {
        private bool hasMine;

        public bool HasMine
        {
            get
            {
                return hasMine;
            }

            set
            {
                hasMine = value;
            }
        }
        public SquareConfig(int x, int y, Panel p, Table t, int left, int top, bool h)
            : base(x, y, p, t, left, top)
        {
            hasMine = h;

            if (hasMine)
                button.BackgroundImage = Resources.Properties.Resources.minesweeper_png;
        }

        public override void on_click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                open();

            panel.Focus();
        }

        public override void open()
        {
            if (button.BackgroundImage == null)
            {
                button.BackgroundImage = Resources.Properties.Resources.minesweeper_png;
                hasMine = true;
                (table as TableConfig).brojac++;

            }
            else
            {
                button.BackgroundImage = null;
                hasMine = false;
                (table as TableConfig).brojac--;
            }
        }
    }
}
