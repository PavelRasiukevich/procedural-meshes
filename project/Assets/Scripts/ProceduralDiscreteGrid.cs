using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ProceduralDiscreteGrid : MonoBehaviour
{
    public float yValue;

    public float cellSize = 1;
    public Vector3 gridOffset;
    public int gridSize;

    [SerializeField] Material custom, defaultMat;
    [SerializeField] Material mat;

    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;
    Color[] vertexColors;
    Vector2[] uv;

    private void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        GetComponent<MeshRenderer>().sharedMaterial = mat;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {

            GetComponent<MeshRenderer>().sharedMaterial = custom;
            ProceduralGridData();
            GenerateGrid();
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {

            GetComponent<MeshRenderer>().sharedMaterial = defaultMat;
            
            ProceduralGridDataUV();
            GenerateGridTexture();
        }
    }

    private void GenerateGrid()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.colors = vertexColors;

        mesh.RecalculateNormals();
    }

    private void GenerateGridTexture()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;

        mesh.RecalculateNormals();
    }

    private void ProceduralGridDataUV()
    {


        vertices = new Vector3[gridSize * gridSize * 4];
        triangles = new int[gridSize * gridSize * 6];
        vertexColors = new Color[vertices.Length];
        uv = new Vector2[vertices.Length];

        float vertexOffset = cellSize * 0.5f;

        int v = 0;
        int t = 0;

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {

                Vector3 cellOffset = new Vector3(i * cellSize, 0, j * cellSize);

                vertices[v + 0] = new Vector3(-vertexOffset, 0, -vertexOffset) + cellOffset;
                vertices[v + 1] = new Vector3(-vertexOffset, 0, vertexOffset) + cellOffset;
                vertices[v + 2] = new Vector3(vertexOffset, 0, -vertexOffset) + cellOffset;
                vertices[v + 3] = new Vector3(vertexOffset, 0, vertexOffset) + cellOffset;

                uv[v + 0] = new Vector2(-vertexOffset, -vertexOffset);
                uv[v + 1] = new Vector2(-vertexOffset, vertexOffset);
                uv[v + 2] = new Vector2(vertexOffset, -vertexOffset);
                uv[v + 3] = new Vector2(vertexOffset, vertexOffset);

                triangles[t + 0] = v + 0;
                triangles[t + 1] = v + 1;
                triangles[t + 2] = v + 2;
                triangles[t + 3] = v + 3;
                triangles[t + 4] = v + 2;
                triangles[t + 5] = v + 1;

                v += 4;
                t += 6;

            }
        }
    }

    private void ProceduralGridData()
    {


        vertices = new Vector3[gridSize * gridSize * 4];
        triangles = new int[gridSize * gridSize * 6];
        vertexColors = new Color[vertices.Length];

        float vertexOffset = cellSize * 0.5f;

        int v = 0;
        int t = 0;

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {

                Vector3 cellOffset = new Vector3(i * cellSize, 0, j * cellSize);

                vertices[v + 0] = new Vector3(-vertexOffset, 0, -vertexOffset) + cellOffset;
                vertices[v + 1] = new Vector3(-vertexOffset, 0, vertexOffset) + cellOffset;
                vertices[v + 2] = new Vector3(vertexOffset, 0, -vertexOffset) + cellOffset;
                vertices[v + 3] = new Vector3(vertexOffset, 0, vertexOffset) + cellOffset;

                vertexColors[v + 0] = new Color(Random.value, Random.value, Random.value);
                vertexColors[v + 1] = new Color(Random.value, Random.value, Random.value);
                vertexColors[v + 2] = new Color(Random.value, Random.value, Random.value);

                vertexColors[v + 1] = new Color(Random.value, Random.value, Random.value);
                vertexColors[v + 3] = new Color(Random.value, Random.value, Random.value);
                vertexColors[v + 2] = new Color(Random.value, Random.value, Random.value);

                triangles[t + 0] = v + 0;
                triangles[t + 1] = v + 1;
                triangles[t + 2] = v + 2;
                triangles[t + 3] = v + 3;
                triangles[t + 4] = v + 2;
                triangles[t + 5] = v + 1;

                v += 4;
                t += 6;

            }
        }
    }
}
