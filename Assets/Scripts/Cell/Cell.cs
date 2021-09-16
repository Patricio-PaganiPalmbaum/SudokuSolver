using System;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public Action<Cell> OnSelect = delegate { };

    public int CurrentNumber
    {
        get => currentNumber;
        set
        {
            currentNumber = value;

            numberDisplay.text = value.ToString();
            numberDisplay.enabled = value != 0;
        }
    }

    public Text numberDisplay;

    public Vector2Int gridPosition;

    private int currentNumber;
    private Material material;

    private void Awake()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    private void OnMouseDown()
    {
        OnSelect.Invoke(this);
    }

    public void ChangeCellColor(Color color)
    {
        material.color = color;
    }
}
