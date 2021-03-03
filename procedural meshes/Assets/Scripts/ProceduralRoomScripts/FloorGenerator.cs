using UnityEngine;

namespace Origin.ProceduralRoomScripts
{
    public class FloorGenerator
    {
        private GameObject floor;
        private Mesh floorMesh;
        private Vector3[] fVertices;
        private int[] fTriangles;

        public void GenerateFloor(Vector2[] data)
        {
            Triangulator triangulator = new Triangulator(data);

            fTriangles = triangulator.Triangulate();

            fVertices = new Vector3[data.Length];

            for (int i = 0; i < fVertices.Length; i++)
            {
                fVertices[i] = new Vector3(data[i].x, 0, data[i].y);
            }

            floor = new GameObject("Floor", typeof(MeshFilter), typeof(MeshRenderer));
            floorMesh = new Mesh();

            floor.GetComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Standard"));
            floorMesh = floor.GetComponent<MeshFilter>().mesh;

            floorMesh.vertices = fVertices;
            floorMesh.triangles = fTriangles;

            floorMesh.RecalculateNormals();
        }

        public void DestroyFloor()
        {
            Object.Destroy(floor);
        }
    }
}