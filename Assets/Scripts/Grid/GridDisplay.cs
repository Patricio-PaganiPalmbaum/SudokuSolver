using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GridDisplay : MonoBehaviour
{
    public GridManager gridManager;
    public CellManager cellManager;

    public Text currentStep;
    public Text totalSteps;

    private List<int> availableNumbers;

    private bool randomNumbers;
    private bool showSequence;

    void Start()
    {
        availableNumbers = Utility.NumberGenerator(1).Take(gridManager.gridSize).ToList();

        randomNumbers = true;
        showSequence = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            List<int[,]> sequenceToDisplay = new List<int[,]>();
            SudokuSolver.SolveSudoku(gridManager.Grid, randomNumbers ? availableNumbers.Shuffle() : availableNumbers, sequenceToDisplay);
            totalSteps.text = "Total steps: " + sequenceToDisplay.Count;

            if (showSequence)
            {
                StopAllCoroutines();
                StartCoroutine(ShowSequence(sequenceToDisplay));
            }
            else
            {
                currentStep.text = "Current step: " + sequenceToDisplay.Count;
                ShowCurrentGrid();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            totalSteps.text = "Total steps: 0";
            currentStep.text = "Current step: 0";

            StopAllCoroutines();
            gridManager.ResetGrid();
            ShowCurrentGrid();
            CellInputManager.Instance.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            StopAllCoroutines();
            CellInputManager.Instance.enabled = true;
        }
    }

    public void SetShowSequence(bool showSequence)
    {
        this.showSequence = showSequence;
    }

    public void SetRandomNumbers(bool randomNumbers)
    {
        this.randomNumbers = randomNumbers;
    }

    private IEnumerator ShowSequence(List<int[,]> sequence)
    {
        CellInputManager.Instance.enabled = false;

        for (int k = 0; k < sequence.Count; k++)
        {
            for (int j = 0; j < sequence[k].GetLength(1); j++)
            {
                for (int i = 0; i < sequence[k].GetLength(0); i++)
                {
                    cellManager.CellGrid[i, j].CurrentNumber = sequence[k][i, j];
                }
            }

            currentStep.text = "Current step: " + k;
            yield return new WaitForSeconds(.1f);
        }

        CellInputManager.Instance.enabled = true;
    }

    private void ShowCurrentGrid()
    {
        for (int i = 0; i < gridManager.Grid.GetLength(0); i++)
        {
            for (int j = 0; j < gridManager.Grid.GetLength(0); j++)
            {
                cellManager.CellGrid[i, j].CurrentNumber = gridManager.Grid[i, j];
            }
        }
    }
}