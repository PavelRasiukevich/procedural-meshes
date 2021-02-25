using System;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ProceduralUVTest : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vert;
    int[] tri;
    Vector2[] uv;

    private void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    private void Start()
    {
        SetMeshData();
        GenerateMesh();
    }

    private void SetMeshData()
    {
        vert = new Vector3[]
        {
            new Vector3(0,0,0),
            new Vector3(0,1,0),
            new Vector3(1,0,0),
            new Vector3(1,1,0)
        };

        uv = new Vector2[]
        {
            new Vector2(1,0),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(0,1)
        };

        tri = new int[]
        {
            0,1,2,3,2,1
        };
    }

    private void GenerateMesh()
    {
        mesh.Clear();
        mesh.vertices = vert;
        mesh.uv = uv;
        mesh.triangles = tri;
        mesh.RecalculateNormals();
    }

}
