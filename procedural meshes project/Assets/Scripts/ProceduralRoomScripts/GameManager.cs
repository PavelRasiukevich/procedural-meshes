using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Origin.ProceduralRoomScripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] float wallHeigth;
        [SerializeField] Material wallMaterial;
        [SerializeField] Material floorMaterial;

        [SerializeField] InputField startPoint;
        [SerializeField] InputField endPoint;
        [SerializeField] ButtonBhv submitButton;
        [SerializeField] ButtonBhv undoButton;

        private WallGenerator wg;
        private FloorGenerator fg;
        private Checker checker;

        private List<Vector2> list;

        private void Start()
        {
            list = new List<Vector2>
            {

            };

            wg = new WallGenerator();
            fg = new FloorGenerator();
            checker = new Checker();
        }

        private void OnEnable()
        {
            submitButton.OnSubmitButtonClick += OnSubmitClick;
            undoButton.OnUndoButtonClick += OnUndoClick;
        }

        private void OnDisable()
        {
            submitButton.OnSubmitButtonClick -= OnSubmitClick;
            undoButton.OnUndoButtonClick -= OnUndoClick;
        }

        private void OnSubmitClick()
        {

            if (string.IsNullOrEmpty(startPoint.text) || string.IsNullOrEmpty(endPoint.text))
            {
                Debug.Log("Text Fields are empty");
            }
            else
            {
                if (float.TryParse(startPoint.text, out float x) && float.TryParse(endPoint.text, out float z))
                {
                    list.Add(new Vector2(x, z));
                }
                else
                {
                    Debug.Log("Ivalid Input. Try more");
                }

            }

            Vector2[] array = checker.Check(list.ToArray());

            wg.DestroyWalls();
            wg.GenerateWall(array, wallHeigth, wallMaterial);

            fg.DestroyFloor();
            fg.GenerateFloor(array, floorMaterial);

            startPoint.text = string.Empty;
            endPoint.text = string.Empty;

        }

        private void OnUndoClick()
        {
            if (list.Count > 0)
            {
                wg.DestroyLastAdded();
                fg.DestroyFloor();
                fg.GenerateFloor(list.ToArray(), floorMaterial);
                list.RemoveAt(list.Count - 1);
            }
        }
    }
}