using System.Collections.Generic;
using UnityEngine;

public static class SudokuSolver
{
    public static bool SolveSudoku(int[,] gridValues, List<int> availableNumbers, List<int[,]> sequence, int x = 0, int y = 0, int depthProtect = 2000)
    {
        if (--depthProtect <= 0)
        {
            Debug.Log("Depth Protect");
            return false;
        }

        if (x == gridValues.GetLength(0))
        {
            x = 0;
            y++;
        }

        if (y == gridValues.GetLength(1))
        {
            return true;
        }

        if (gridValues[x, y] == 0)
        {
            for (int i = 0; i < availableNumbers.Count; i++)
            {
                gridValues[x, y] = availableNumbers[i];

                if (Utility.IsValidNumber(gridValues, x, y))
                {
                    sequence.Add((int[,])gridValues.Clone());

                    if (SolveSudoku(gridValues, availableNumbers, sequence, x + 1, y, depthProtect))
                    {
                        return true;
                    }
                }
            }

            gridValues[x, y] = 0;
            return false;
        }
        else
        {
            return SolveSudoku(gridValues, availableNumbers, sequence, x + 1, y, depthProtect);
        }
    }
}