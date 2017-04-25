using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Form1 : Form
    {
        //Label[,] labels = new Label[9,9];
        public Form1()
        {
            InitializeComponent();
            Grid mGrid = new Grid();
            Cell[,] table = mGrid.GetGridCells();
            dataGridView1.ColumnCount = 9;
            dataGridView1.RowTemplate.Height = 30;
            for (int i = 0; i < 9; i++)
            { // set columns width
                dataGridView1.Columns[i].Width = 30;
            }

            string[] s = new string[9];
            for (int i = 0; i < 9; i++)
            {
                s = new string[9];
                for (int j = 0; j < 9; j++)
                {
                    s[j] = table[i, j].getValue().ToString();
                }
                dataGridView1.Rows.Add(s);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
