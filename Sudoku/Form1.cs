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
            loadGraphicalGrid();
            label1.Text = "";
        }

        private void loadGraphicalGrid()
        {
            // Partial grid generation
            dataGridView1.Rows.Clear();
            Grid mGrid = new Grid();
            String[,] table = mGrid.generatePartialGrid();

            // grid config
            dataGridView1.ColumnCount = 9;
            dataGridView1.RowTemplate.Height = 45;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            for (int i = 0; i < 9; i++)
            {
                dataGridView1.Columns[i].Width = 45;
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // set values in DataGridView
            string[] s;
            for (int i = 0; i < 9; i++)
            {
                s = new string[9];
                for (int j = 0; j < 9; j++)
                {
                    s[j] = table[i, j];
                }
                dataGridView1.Rows.Add(s);
                for (int j = 0; j < 9; j++)
                {
                    if (table[i, j] != null)
                    {
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Aqua;
                    }
                }
            }
        }

        private string[,] getDataFromGridView()
        {
            string[,] values = new string[9, 9];
            for (int rows = 0; rows < dataGridView1.Rows.Count; rows++)
            {
                for (int col = 0; col < dataGridView1.Rows[rows].Cells.Count; col++)
                {
                    if (dataGridView1.Rows[rows].Cells[col].Value != null)
                    {
                        values[rows, col] = dataGridView1.Rows[rows].Cells[col].Value.ToString();
                    }
                    else
                    {
                    }
                }
            }
            return values;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /*
         * Reset button
         */
        private void button1_Click(object sender, EventArgs e)
        {
            this.loadGraphicalGrid();
            button2.BackColor = default(Color);
            label1.Text = "";
        }

        /*
         * Validate button
         */
        private void button2_Click(object sender, EventArgs e)
        {
            Grid mGrid = new Grid();
            if (mGrid.isGridValid(getDataFromGridView()))
            {
                button2.BackColor = Color.Green;
                label1.Text = "Félicitation !!";
            }
            else
            {
                button2.BackColor = Color.Red;
                label1.Text = "Votre grile n'est pas valide...";
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
