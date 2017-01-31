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
            //makestats();
        }

        private void makestats()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            // the code that you want to measure comes here
            watch.Stop();
            int shots = 300, summ = 0;
            long elapsedMs = 0;
            for (int i = 0; i < shots; i++)
            {
                shots--;
                watch.Restart();
                summ += generateGrid();
                elapsedMs += watch.ElapsedMilliseconds;
                System.Threading.Thread.Sleep(100);
            }
            Console.WriteLine("Mean :" + summ / shots);
            Console.WriteLine("Mean :" + elapsedMs / shots);
        }

        private int generateGrid()
        {
             int i = 0;
             do
             {
                 i++;
                 resetGrid();
                 generate();
             } while (!isValid());
             Console.WriteLine("Generations : " + i);
             return i;
        }

        public void generate()
        {
            Random rnd = new Random();
            Boolean written;
            for (int x = 0; x < grid.GetLength(0); x += 1)
            {
                for (int y = 0; y < grid.GetLength(1); y += 1)
                {
                    int tmp;
                    tmp = rnd.Next(1, 10);
                    int tmpori = tmp;
                    written = false;
                    do
                    {
                        if (xFree(x, tmp) && yFree(y, tmp) && caseFree(x, y, tmp) && !isBlocking(x, y, tmp))
                        {
                            grid[x, y].setValue(tmp);
                            block(x, y, tmp);
                            written = true;
                        }
                        tmp = (tmp % 9) + 1;
                    } while (!written && tmp != tmpori);
                }
            }
        }

        private void resetGrid()
        {
            for (int x = 0; x < grid.GetLength(0); x += 1)
            {
                for (int y = 0; y < grid.GetLength(1); y += 1)
                {
                    grid[x, y] = new Cell();
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
                if (!grid[x, i].isOk(val) && i != y && grid[x,i].getValue() == 0)
                    return true;
            }

            for (int j = 0; j < grid.GetLength(1); j += 1)
            {
                if (!grid[j, y].isOk(val) && j != x && grid[j, y].getValue() == 0)
                    return true;
            }

            int subX = x / 3, subY = y / 3;
            for (int i = subX * 3; i < (subX + 1) * 3; i++)
            {
                for (int j = subY * 3; j < (subY + 1) * 3; j++)
                {
                    if (!grid[i, j].isOk(val) && i != x && j != y && grid[i, j].getValue() == 0)
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

        public Boolean isValid()
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j].getValue() == 0)
                        return false;
                }
            }
            return true;
        }
    }
}
