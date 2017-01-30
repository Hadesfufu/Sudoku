using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Grid
    {
        private int[,] grid = new int[9, 9];

        public Grid()
        {
            generateGrid();
        }

        private void generateGrid()
        {
            Random rnd = new Random();
            Boolean written;
            for (int x = 0; x < grid.GetLength(0); x += 1)
            {
                for (int y = 0; y < grid.GetLength(1); y += 1)
                {
                    grid[x, y] = 0;
                }
            }
            for (int x = 0; x < grid.GetLength(0); x += 1)
            {
                for (int y = 0; y < grid.GetLength(1); y += 1)
                {
                    int tmp;
                    written = false;
                    do
                    {
                        tmp = rnd.Next(1, 10);
                        if (xFree(x, tmp) && yFree(y, tmp) && caseFree(x, y ,tmp))
                        {
                            grid[x, y] = tmp;
                            written = true;
                        }
                    } while (!written);
                }
            }
        }

        private Boolean xFree(int x, int val)
        {
            for (int y = 0; y < grid.GetLength(0); y += 1)
            {
                if (grid[x, y] == val)
                {
                    return false;
                }
            }
            return true;
        }

        private Boolean yFree(int y, int val)
        {
            //for (int x = 0; x < grid.GetLength(0); x += 1)
            //{
            //    if (grid[x, y] == val)
            //    {
            //        return false;
            //    }
            //}
            return true;
        }

        private Boolean caseFree(int x, int y, int val)
        {
            return true;
        }

        public String toStringForCmd(){
            String returnValue = "";
            for (int x = 0; x < grid.GetLength(0); x += 1)
            {
                for (int y = 0; y < grid.GetLength(1); y += 1)
                {
                    returnValue += grid[x, y];
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
