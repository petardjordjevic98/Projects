using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Square
{
    [Serializable]
    public abstract class Table
    {
        public int  maximum= 0;
        public int minimum = 1000000;
        public int VremeIzmedju=0;
      //  public string Vreme = "0";
        public EventHandler OnKrajIgre;
        public EventHandler AzuriarajLabele;
        private int dimension;
        private int maxNumberOfMines;
        private Square[,] matrix;
        private Panel panel;
        public int time = 0;
        public Timer t1;
        
        private int numberOfOpenedSquares;
        public Table()
        { }
        public int Dimension
        {
            get
            {
                return dimension;
            }

            set
            {
                dimension = value;
            }
        }

        public int MaxNumberOfMines
        {
            get
            {
                return maxNumberOfMines;
            }

            set
            {
                maxNumberOfMines = value;
            }
        }

        public Square[,] Matrix
        {
            get
            {
                return matrix;
            }
        }

        public Panel Panel
        {
            get
            {
                return panel;
            }
        }

        public int NumberOfOpenedSquares
        {
            get
            {
                return numberOfOpenedSquares;
            }

            set
            {
                numberOfOpenedSquares = value;
            }
        }
        public Table(int d, int m, Panel p)
        {
            dimension = d;
            maxNumberOfMines = m;
            panel = p;
            numberOfOpenedSquares = 0;

            matrix = new Square[dimension, dimension];
          
        }
        
        public Square findSquare(int x, int y)
        {
            if ((x < 0) || (x >= dimension) || (y < 0) || (y >= dimension))
                return null;

            return matrix[x, y];
        }

        public void openAll()
        {
            OnKrajIgre?.Invoke(null, null);

            panel.Enabled = false;
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    if (matrix[i, j] is SquareMine)
                    {
                        matrix[i, j].open();
                    }
                }
            }



        }
        
    }
    [Serializable]
    public class TableGame : Table
    {public TableGame() : base() { }

        public bool firstTime; public void Save(string fileName)//dve metode, save je javna metoda kojoj prosledjujemo filename
        {
            XmlTextWriter wr = null;//da zapamtimo u ovaj fajl
            try
            {
                /// napravi se objekat koji je u stanju da upisuje u fajl
                wr = new XmlTextWriter(fileName, Encoding.Unicode);//prosledjujemo filename gde zelimo da zapamtimo i 
                                                                   //biramo kodiranje tj unicode

                /// kreira se objekat serijalizatora koji moze da serijalizuje 
                /// objekte klase student
                XmlSerializer sr = new XmlSerializer(typeof(TableGame));//za tip podataka student se pravi serilaser

                ///poziva se serijalizacija
                sr.Serialize(wr, this);//pozivamo metodu za ovaj objekat
            }
            catch
            {
            }
            finally//ovaj deo koda ce se sigurno izvrsiti
            {
                /// na kraju se writer objekat zatvara
                wr.Close();
            }
        }
        public TableGame(int d, int m, Panel p, bool[,] config = null) : base(d, m, p)
        {
            firstTime = true;
            if (config == null)
            {
                // random configuration

                config = new bool[Dimension, Dimension];

                for (int i = 0; i < Dimension; i++)
                {
                    for (int j = 0; j < Dimension; j++)
                    {
                        config[i, j] = false;
                    }
                }
                
                int counter = 0;
                while (counter < MaxNumberOfMines)
                {
                    Random r1 = new Random();
                    Random r2 = new Random();
                    int rand1 = r1.Next(0, Dimension);
                    int rand2 = r2.Next(0, Dimension);

                    if (config[rand1, rand2] == false)
                    {
                        config[rand1, rand2] = true;
                        counter++;
                    }
                }
            }

            int currentLeft = 0;
            int currentTop = 0;
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    if (config[i, j] == false)
                        Matrix[i, j] = new SquareEmpty(i, j, Panel, this, currentLeft, currentTop);
                    else
                        Matrix[i, j] = new SquareMine(i, j, Panel, this, currentLeft, currentTop);

                    currentLeft += Matrix[i, j].Button.Width;
                }
                currentTop += Matrix[0, 0].Button.Height;
                currentLeft = 0;
            }
        }


        public SquareEmpty exchange(int x, int y)
        {
            int rand1 = 0;
            int rand2 = 0;
            while (true)
            {
                Random r1 = new Random();
                Random r2 = new Random();
                rand1 = r1.Next(0, Dimension);
                rand2 = r2.Next(0, Dimension);

                if (Matrix[rand1, rand2] is SquareEmpty)
                    break;
            }

            Panel.Controls.Remove(Matrix[rand1, rand2].Button);
            Matrix[rand1, rand2] = new SquareMine(rand1, rand2, Panel, this, Matrix[rand1, rand2].Button.Left, Matrix[rand1, rand2].Button.Top);

            Panel.Controls.Remove(Matrix[x, y].Button);
            Matrix[x, y] = new SquareEmpty(x, y, Panel, this, Matrix[x, y].Button.Left, Matrix[x, y].Button.Top);

            return (Matrix[x, y] as SquareEmpty);
        }

       
    }
        public class TableConfig : Table
        {
            public int brojac = 0;
            public TableConfig(int d, int m, Panel p, bool[,] config) : base(d, m, p)
            {
                int currentLeft = 0;
                int currentTop = 0;
                for (int i = 0; i < Dimension; i++)
                {
                    for (int j = 0; j < Dimension; j++)
                    {
                        if (config[i, j] == true)
                        {
                            Matrix[i, j] = new SquareConfig(i, j, Panel, this, currentLeft, currentTop, true);
                            brojac++;
                        }
                        else
                            Matrix[i, j] = new SquareConfig(i, j, Panel, this, currentLeft, currentTop, false);

                        currentLeft += Matrix[i, j].Button.Width;
                    }
                    currentTop += Matrix[0, 0].Button.Height;
                    currentLeft = 0;
                }
            }
        }
    
}
