using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCreator
{

    private List<GameObject> listOfpoints;

    public PointCreator()
    {
        listOfpoints = new List<GameObject>();
    }

    public void CreatePoint(Vector2 point, Canvas parent, Font font)
    {
        GameObject p = new GameObject("Point");
        listOfpoints.Add(p);

        p.transform.position = new Vector3(point.x, 0, point.y);
        p.transform.SetParent(parent.transform);


        Text mytext = p.AddComponent<Text>();
        mytext.transform.position = Camera.main.WorldToScreenPoint(p.transform.position);
        mytext.font = font;
        mytext.color = Color.red;
        mytext.alignment = TextAnchor.MiddleCenter;
        mytext.text = $"({point.x}, {point.y})";
    }

    public void DeleteLastPoint()
    {
        for (int i = 0; i < listOfpoints.Count; i++)
        {
            if (i == listOfpoints.Count - 1)
            {
                Object.Destroy(listOfpoints[i]);
            }
        }

        if (listOfpoints.Count != 0)
            listOfpoints.RemoveAt(listOfpoints.Count - 1);
    }
}
