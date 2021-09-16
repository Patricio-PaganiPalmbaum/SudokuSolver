using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static List<int> GetRangeValues(int[,] gridValues, int initialX, int initialY, int finalX, int finalY)
    {
        List<int> values = new List<int>();

        for (int i = initialX; i <= finalX; i++)
        {
            for (int j = initialY; j <= finalY; j++)
            {
                values.Add(gridValues[i, j]);
            }
        }

        return values;
    }

    public static bool IsValidNumber(int[,] gridValues, Vector2Int position)
    {
        return IsValidNumber(gridValues, position.x, position.y);
    }

    public static bool IsValidNumber(int[,] gridValues, int x, int y)
    {
        int startXQuadrant = (x / 3) * 3;
        int startYQuadrant = (y / 3) * 3;

        if (HasRepetedNumbers(GetRangeValues(gridValues, 0, y, gridValues.GetLength(0) - 1, y))) //row
        {
            return false;
        }

        if (HasRepetedNumbers(GetRangeValues(gridValues, x, 0, x, gridValues.GetLength(1) - 1))) //column
        {
            return false;
        }

        if (HasRepetedNumbers(GetRangeValues(gridValues, startXQuadrant, startYQuadrant, startXQuadrant + 2, startYQuadrant + 2))) //Quadrant.
        {
            return false;
        }

        return true;
    }

    public static bool HasRepetedNumbers(List<int> numbers)
    {
        int[] values = new int[10];

        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] == 0)
            {
                continue;
            }

            values[numbers[i]]++;

            if (values[numbers[i]] > 1)
            {
                return true;
            }
        }

        return false;
    }

    public static IEnumerable<int> NumberGenerator(int initialNumber)
    {
        yield return initialNumber;

        while(true)
        {
            initialNumber++;
            yield return initialNumber;
        }
    }

    public static List<T> Shuffle<T>(this List<T> collection)
    {
        List<T> shuffledCollection = new List<T>(collection);
        T aux;
        int rIndex;

        for(int i = 0; i < shuffledCollection.Count; i++)
        {
            rIndex = UnityEngine.Random.Range(i, shuffledCollection.Count);

            aux = shuffledCollection[rIndex];
            shuffledCollection[rIndex] = shuffledCollection[i];
            shuffledCollection[i] = aux;
        }

        return shuffledCollection;
    }
}