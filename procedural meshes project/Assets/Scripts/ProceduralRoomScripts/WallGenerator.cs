using System.Collections.Generic;
using UnityEngine;


namespace Origin.ProceduralRoomScripts
{
    public class WallGenerator
    {
        Mesh wallMesh;

        Vector3[] vertices;
        Vector2[] uv;
        int[] triangles;

        List<GameObject> listOfWalls;

        public WallGenerator()
        {
            listOfWalls = new List<GameObject>();
        }

        public void GenerateWall(Vector2[] points, float wallHeigth, Material material)
        {

            SetData(points, wallHeigth, material);
        }

        private void SetData(Vector2[] points, float wallHeigth, Material material)
        {
            for (int i = 0; i < points.Length - 1; i++)
            {
                vertices = new Vector3[]
                {
                    new Vector3(points[i].x,0,points[i].y),
                    new Vector3(points[i].x,wallHeigth,points[i].y),
                    new Vector3(points[i + 1].x,0,points[i + 1].y),
                    new Vector3(points[i + 1].x,wallHeigth,points[i + 1].y),

                    new Vector3(points[i].x,0,points[i].y),
                    new Vector3(points[i].x,wallHeigth,points[i].y),
                    new Vector3(points[i + 1].x,0,points[i + 1].y),
                    new Vector3(points[i + 1].x,wallHeigth,points[i + 1].y)
                };

                triangles = new int[]
                {

                     0,1,2,
                     3,2,1,

                     6,7,4,
                     5,4,7

                };

                var wallLenght = Vector2.Distance(points[i], points[i + 1]);

                uv = new Vector2[]
                {
                    new Vector2(0,0),
                    new Vector2(0,1),
                    new Vector2(wallLenght / wallHeigth * 2, 0),
                    new Vector2(wallLenght / wallHeigth * 2, 1),
                    new Vector2(0,0),
                    new Vector2(0,1),
                    new Vector2(wallLenght / wallHeigth * 2, 0),
                    new Vector2(wallLenght / wallHeigth * 2, 1)
                };

                Generate(material);
            }
        }

        private void Generate(Material material)
        {
            GameObject go = new GameObject("Wall", typeof(MeshFilter), typeof(MeshRenderer));
            MeshRenderer rend = go.GetComponent<MeshRenderer>();
            Debug.Log(go.GetType());
            rend.sharedMaterial = material;
            wallMesh = go.GetComponent<MeshFilter>().mesh;

            //wallMesh.Clear();

            wallMesh.vertices = vertices;
            wallMesh.uv = uv;
            wallMesh.triangles = triangles;

            wallMesh.RecalculateNormals();

            listOfWalls.Add(go);
        }

        public void DestroyWalls()
        {
            foreach (var wall in listOfWalls)
            {
                Object.Destroy(wall);
            }
        }
        public void DestroyLastAdded()
        {
            for (int i = 0; i < listOfWalls.Count; i++)
            {
                if (i == listOfWalls.Count - 1)
                {
                    Object.Destroy(listOfWalls[i]);
                }
            }

            //listOfWalls.RemoveAt(listOfWalls.Count - 1);
        }
    }
}
