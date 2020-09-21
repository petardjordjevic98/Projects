using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Settings : Form
    {
        public int Dimension
        {
            get
            {
                return Convert.ToInt32(numdim.Value);
            }
        }
        public int Mines
        {
            get
            {
                return Convert.ToInt32(nummin.Value);
            }
        }
        public Settings(int dim,int broj)
        {
            InitializeComponent();
            numdim.Value = dim;
            nummin.Value = broj;
        }

        private void btnok_Click(object sender, EventArgs e)
        {
             DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
    }
}
