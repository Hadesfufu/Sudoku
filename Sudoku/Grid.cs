using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Grid
    {
        private Cell[,] grid = new Cell[9, 9];

        public Grid()
        {
            generateGrid();
        }

        private void generateGrid()
        {
            Random rnd = new Random();
            for (int x = 0; x < grid.GetLength(0); x += 1)
            {
                for (int y = 0; y < grid.GetLength(1); y += 1)
                {
                    grid[x, y] = new Cell(rnd.Next(1, 10));
                }
            }
        }

        private Boolean xFree(int x, Cell val)
        {
            for (int y = 0; y < grid.GetLength(0); y += 1)
            {
                if (grid[x, y].getValue() == val.getValue())
                {
                    return false;
                }
            }
            return true;
        }

        private Boolean yFree(int y, Cell val)
        {
            for (int x = 0; x < grid.GetLength(0); x += 1)
            {
                if (grid[x, y].getValue() == val.getValue())
                {
                    return false;
                }
            }
            return true;
        }

        private Boolean caseFree(int x, int y, Cell val)
        {
            int subX = x / 3, subY = y / 3;
            for (int i = subX * 3; i < (subX + 1) * 3; i++)
            {
                for (int j = subY * 3; j < (subY + 1) * 3; j++)
                {
                    if (grid[i, j].getValue() == val.getValue())
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public String toStringForCmd(){
            String returnValue = "";
            for (int x = 0; x < grid.GetLength(0); x += 1)
            {
                for (int y = 0; y < grid.GetLength(1); y += 1)
                {
                    returnValue += grid[x, y].getValue();
                    if (y == 2 || y == 5)
                    {
                        returnValue += " | ";
                    }
                }
                returnValue += "\n";
                if (x == 2 || x == 5)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        returnValue += "--";
                    }
                    returnValue += "\n";
                }
            }
            return returnValue;
        }
    }
}
