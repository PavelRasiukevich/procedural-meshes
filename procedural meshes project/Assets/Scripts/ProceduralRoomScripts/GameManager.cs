using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Origin.ProceduralRoomScripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] float wallHeigth;
        [SerializeField] Material material;
        [SerializeField] Material material_1;

        [SerializeField] InputField startPoint;
        [SerializeField] InputField endPoint;
        [SerializeField] ButtonBhv submitButton;
        [SerializeField] ButtonBhv undoButton;

        private WallGenerator wg;
        private FloorGenerator fg;
        private Checker checker;

        private List<Vector2> list;
        private Vector2 lastAdded;

        private void Start()
        {
            list = new List<Vector2>
        {
            Vector2.zero
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

            float.TryParse(startPoint.text, out float x);
            float.TryParse(endPoint.text, out float z);

            list.Add(new Vector2(x, z));

            Vector2[] array = checker.Check(list.ToArray());

            wg.DestroyWalls();
            wg.GenerateWall(array, wallHeigth, material);

            fg.DestroyFloor();
            fg.GenerateFloor(array,material_1);

            startPoint.text = string.Empty;
            endPoint.text = string.Empty;

        }

        private void OnUndoClick()
        {
            if (list.Count > 1)
            {
                list.RemoveAt(list.Count - 1);
                wg.DestroyLastAdded();
                fg.DestroyFloor();
                fg.GenerateFloor(list.ToArray(),material_1);
            }
        }
    }
}