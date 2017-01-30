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

        public Cell(int val = 0)
        {
            this.val = val;
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

        public void resetCell()
        {
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
}
