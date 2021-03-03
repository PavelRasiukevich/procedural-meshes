using UnityEngine;

public class Checker
{
    public Vector2[] Check(Vector2[] points)
    {
        Vector2[] checkedArray = points;

        for (int i = 0; i < checkedArray.Length - 1; i++)
        {

            if ((checkedArray[i + 1].x == checkedArray[0].x) && (checkedArray[i + 1].y == checkedArray[0].y))
            {
                checkedArray[i + 1] = new Vector2(points[i + 1].x - .0001f, points[i + 1].y - .0001f);
            }
        }

        return checkedArray;
    }
}
