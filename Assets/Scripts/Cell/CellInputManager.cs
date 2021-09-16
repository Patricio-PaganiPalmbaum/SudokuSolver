using System;
using UnityEngine;

public class CellInputManager : MonoBehaviour
{
    public event Action<Cell, int> OnInputNumber = delegate { };

    private Action<Cell> currentSelectCallback = delegate { };

    public static CellInputManager Instance
    {
        get
        {
            if (!instance)
            {
                instance = new GameObject("CellInputManager").AddComponent<CellInputManager>();
            }

            return instance;
        }
    }

    private static CellInputManager instance;

    private Color selectColor;
    private Cell currentCellSelected;

    private void Start()
    {
        selectColor = new Color(0.573f, 0.714f, 0.925f);
        currentSelectCallback = SetCell;
    }

    public void OnSelectCell(Cell selectedCell)
    {
        currentSelectCallback.Invoke(selectedCell);
    }

    private void SetCell(Cell selectedCell)
    {
        currentCellSelected = selectedCell;
        currentCellSelected.ChangeCellColor(selectColor);
        currentSelectCallback = ChangeSelectedCell;
    }

    private void ChangeSelectedCell(Cell selectedCell)
    {
        if (currentCellSelected == selectedCell)
        {
            currentCellSelected.ChangeCellColor(Color.white);
            currentCellSelected = null;
            currentSelectCallback = SetCell;
        }
        else
        {
            currentCellSelected.ChangeCellColor(Color.white);
            currentCellSelected = selectedCell;
            currentCellSelected.ChangeCellColor(selectColor);
        }
    }

    private void Update()
    {
        if (!currentCellSelected)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            OnInputNumber.Invoke(currentCellSelected, 0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            OnInputNumber.Invoke(currentCellSelected, 1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            OnInputNumber.Invoke(currentCellSelected, 2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            OnInputNumber.Invoke(currentCellSelected, 3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            OnInputNumber.Invoke(currentCellSelected, 4);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
        {
            OnInputNumber.Invoke(currentCellSelected, 5);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
        {
            OnInputNumber.Invoke(currentCellSelected, 6);
        }

        if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))
        {
            OnInputNumber.Invoke(currentCellSelected, 7);
        }

        if (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8))
        {
            OnInputNumber.Invoke(currentCellSelected, 8);
        }

        if (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9))
        {
            OnInputNumber.Invoke(currentCellSelected, 9);
        }
    }
}