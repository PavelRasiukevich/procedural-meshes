using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Origin.ProceduralRoomScripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] float wallHeigth;
        [SerializeField] Material material;

        [SerializeField] InputField startPoint;
        [SerializeField] InputField endPoint;
        [SerializeField] ButtonBhv button;

        private WallGenerator wg;
        private FloorGenerator fg;

        private List<Vector2> list;

        private Vector2 origin = Vector2.zero;


        private void Start()
        {
            list = new List<Vector2>
        {
            origin
        };

            wg = new WallGenerator();
            fg = new FloorGenerator();
        }

        private void OnEnable()
        {
            button.onButtonClicked += OnButtonClickHandler;
        }

        private void OnDisable()
        {
            button.onButtonClicked -= OnButtonClickHandler;
        }

        private void OnButtonClickHandler()
        {

            float.TryParse(startPoint.text, out float x);
            float.TryParse(endPoint.text, out float z);

            list.Add(new Vector2(x, z));

            wg.DestroyWalls();
            wg.GenerateWall(list.ToArray(), wallHeigth, material);

            fg.DestroyFloor();
            fg.GenerateFloor(list.ToArray());

            startPoint.text = string.Empty;
            endPoint.text = string.Empty;

        }
    }
}