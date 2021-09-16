using UnityEngine;

public class CellManager : MonoBehaviour
{
    public Cell cellPrefab;

    public float startX;
    public float startY;

    public int gridSize;

    public float cellWidth;
    public float cellHeight;

    public float offSetX;
    public float offSetY;

    public Cell[,] CellGrid { get; private set; }

    private void Awake()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        CellGrid = new Cell[gridSize, gridSize];
        Vector3 cellPosition = Vector3.zero;

        for (int i = 0; i < gridSize; i++)
        {
            cellPosition.x = startX + (cellWidth * i) + (offSetX * (int)(i / 3f));

            for (int j = 0; j < gridSize; j++)
            {
                cellPosition.y = startY - (cellHeight * j) - (offSetY * (int)(j / 3f));

                CellGrid[i, j] = Instantiate(cellPrefab, cellPosition, Quaternion.identity, transform);
                CellGrid[i, j].gridPosition = new Vector2Int(i, j);
                CellGrid[i, j].OnSelect += CellInputManager.Instance.OnSelectCell;
            }
        }
    }
}