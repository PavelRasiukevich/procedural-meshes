using System;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ProceduralGrid : MonoBehaviour
{
    public float yValue;

    public float cellSize = 1;
    public Vector3 gridOffset;
    public int gridSize;

    Mesh mesh;

    Vector3[] vertices;
    int[] trianles;

    private void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    private void Start()
    {
        MakeProceduralGrid();
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = trianles;
        mesh.RecalculateNormals();
    }

    private void MakeProceduralGrid()
    {
        vertices = new Vector3[gridSize * gridSize * 4];
        trianles = new int[gridSize * gridSize * 6];

        float vertexOffset = cellSize * 0.5f;

        int v = 0;
        int t = 0;

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {

                Vector3 cellOffset = new Vector3(i * cellSize, 0, j * cellSize);

                vertices[v + 0] = new Vector3(-vertexOffset, 0, -vertexOffset) + cellOffset;
                vertices[v + 1] = new Vector3(-vertexOffset, yValue, vertexOffset) + cellOffset;
                vertices[v + 2] = new Vector3(vertexOffset, yValue, -vertexOffset) + cellOffset;
                vertices[v + 3] = new Vector3(vertexOffset, 0, vertexOffset) + cellOffset;

                trianles[t + 0] = v + 0;
                trianles[t + 1] = v + 1;
                trianles[t + 2] = v + 2;
                trianles[t + 3] = v + 3;
                trianles[t + 4] = v + 2;
                trianles[t + 5] = v + 1;

                v += 4;
                t += 6;

            }
        }

    }
}
