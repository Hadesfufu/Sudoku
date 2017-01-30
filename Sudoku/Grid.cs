using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Cell
    {
        private int val;
        private Boolean[] posVals = new Boolean[9];

        public Cell(){
            resetCell();
        }

        public int getValue()
        {
            return val;
        }

        public void setValue(int x)
        {
            val = x;
        }

        public void resetCell(){
            for (int i = 0; i < posVals.GetLength(0); i++)
            {
                posVals[i] = true;
            }
        }

        public void removeVal(int val)
        {
            posVals[val - 1] = false;
        }

        public Boolean isOk(int val)
        {
            for (int i = 0; i < posVals.GetLength(0); i++)
            {
                if (i != val - 1 && posVals[i] == true)
                {
                    return true;
                }
            }
            return false;
        }
    }
    class Grid
    {
        private Cell[,] grid = new Cell[9, 9];

        public Grid()
        {
            generateGrid();
        }

        private void generateGrid()
        {
            
        }
                    } while (!written);
                }
            }
        }

        private Boolean xFree(int x, int val)
        {
            for (int y = 0; y < grid.GetLength(0); y += 1)
            {
                if (grid[x, y].getValue() == val)
                {
                    return false;
                }
            }
            return true;
        }

        private Boolean yFree(int y, int val)
        {
            for (int x = 0; x < grid.GetLength(0); x += 1)
            {
                if (grid[x, y].getValue() == val)
                {
                    return false;
                }
            }
            return true;
        }

        private Boolean caseFree(int x, int y, int val)
        {
            int subX = x / 3, subY = y / 3;
            for (int i = subX * 3; i < (subX + 1) * 3; i++)
            {
                for (int j = subY * 3; j < (subY + 1) * 3; j++)
                {
                    if (grid[i, j].getValue() == val)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool isBlocking(int x, int y, int val)
        {
            for (int i = 0; i < grid.GetLength(0); i += 1)
            {
                if (!grid[x, i].isOk(val))
                    return true;
            }

            for (int j = 0; j < grid.GetLength(1); j += 1)
            {
                if (!grid[j, y].isOk(val))
                    return true;
            }

            int subX = x / 3, subY = y / 3;
            for (int i = subX * 3; i < (subX + 1) * 3; i++)
            {
                for (int j = subY * 3; j < (subY + 1) * 3; j++)
                {
                    if (!grid[i, j].isOk(val))
                        return true;
                }
            }
            return false;
        }

        public void block(int x, int y, int val)
        {
            for (int i = 0; i < grid.GetLength(0); i += 1)
            {
                grid[x, i].removeVal(val);
            }

            for (int j = 0; j < grid.GetLength(1); j += 1)
            {
                grid[j, y].removeVal(val);
            }

            int subX = x / 3, subY = y / 3;
            for (int i = subX * 3; i < (subX + 1) * 3; i++)
            {
                for (int j = subY * 3; j < (subY + 1) * 3; j++)
                {
                    grid[i, j].removeVal(val);
                }
            }
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
