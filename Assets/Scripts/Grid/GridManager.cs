using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int gridSize;

    public CellManager cellManager;

    public int[,] Grid { get; private set; }

    private void Awake()
    {
        Grid = new int[gridSize, gridSize];
    }

    void Start()
    {
        CellInputManager.Instance.OnInputNumber += ProcessInput;
    }

    private void ProcessInput(Cell cell, int input)
    {
        int currentNumber = Grid[cell.gridPosition.x, cell.gridPosition.y];
        Grid[cell.gridPosition.x, cell.gridPosition.y] = input;

        if (input == 0 || Utility.IsValidNumber(Grid, cell.gridPosition))
        {
            cell.CurrentNumber = input;
        }
        else
        {
            Grid[cell.gridPosition.x, cell.gridPosition.y] = currentNumber;
        }
    }

    public void ResetGrid()
    {
        Grid = new int[gridSize, gridSize];
    }
}