using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Square;


namespace Minesweeper
{
    public partial class Configuration : Form
    {
        private TableConfig tc;
        
       

        
        public bool [,] Config
        {
            get
            {
                bool[,] result = new bool[tc.Dimension, tc.Dimension];
                for (int i = 0; i < tc.Dimension; i++)
                {
                    for (int j = 0; j < tc.Dimension; j++)
                    {
                        if ((tc.Matrix[i, j] as SquareConfig).HasMine == false)
                            result[i, j] = false;
                        else if ((tc.Matrix[i, j] as SquareConfig).HasMine == true)
                            result[i, j] = true;
                    }
                }

                return result;
            }            
        }

        public Configuration(Table t)
        {
            InitializeComponent();

       

            bool[,] tmp = new bool[t.Dimension, t.Dimension];
            for (int i = 0; i < t.Dimension; i++)
            {
                for (int j = 0; j < t.Dimension; j++)
                {
                    if (t.Matrix[i, j] is SquareEmpty)
                        tmp[i, j] = false;
                    else if (t.Matrix[i, j] is SquareMine)
                        tmp[i, j] = true;
                }
            }

            tc = new TableConfig(t.Dimension, t.MaxNumberOfMines, panelConfig, tmp);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            System.Console.WriteLine(tc.brojac);
            if (tc.brojac == tc.MaxNumberOfMines)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Broj mina je los");
            }
        }
    }
}
