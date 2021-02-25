using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ProceduralContiguousGrid : MonoBehaviour
{
    Vector3[] vertices;
    int[] triangles;
    Color[] vertexColors;
    Vector2[] uv;

    public float cellSize = 1;
    public Vector3 gridOffset;
    public int gridSize;

    Mesh mesh;

    private void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    private void Start()
    {
        ContiguousGridData();
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }

    private void ContiguousGridData()
    {

        vertices = new Vector3[(gridSize + 1) * (gridSize + 1)];
        triangles = new int[gridSize * gridSize * 6];

        float vertexOffset = cellSize * 0.5f;

        int v = 0;
        int t = 0;

        for (int i = 0; i <= gridSize; i++)
        {

            for (int j = 0; j <= gridSize; j++)
            {
                vertices[v] = new Vector3((i * cellSize) - vertexOffset, 0, (j * cellSize) - vertexOffset);

                v++;
            }
        }

        v = 0;

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                triangles[t + 0] = v + 0;
                triangles[t + 1] = v + 1;
                triangles[t + 2] = v + (gridSize + 1);
                triangles[t + 3] = v + (gridSize + 1);
                triangles[t + 4] = v + 1;
                triangles[t + 5] = v + (gridSize + 1) + 1;

                v++;
                t += 6;
            }
            v++;
        }
    }
}
