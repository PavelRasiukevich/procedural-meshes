using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class ProceduralMesh : MonoBehaviour
{
   
    [SerializeField] float yValue;

    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    private void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    private void Update()
    {
        MakeMeshData();
        GenerateMesh();
        mesh.RecalculateNormals();
    }

    void MakeMeshData()
    {
        vertices = new Vector3[]
        {
            new Vector3(0,0,0),
            new Vector3(0,0,1),
            new Vector3(1,0,0),
            new Vector3(1,yValue,1)
        };

        triangles = new int[]
        {
            0,
            1,
            2,
            1,
            3,
            2
        };
    }

    void GenerateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }
}
