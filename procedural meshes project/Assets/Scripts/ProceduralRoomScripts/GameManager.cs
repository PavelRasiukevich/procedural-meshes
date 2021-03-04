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
        [SerializeField] Canvas canvas;
        [SerializeField] Font font;

        private WallGenerator wg;
        private FloorGenerator fg;
        private ArrayChecker arrayChecker;
        private InputChecker inputChecker;
        private PointCreator pointGenerator;

        private List<Vector2> list;

        private void Start()
        {
            list = new List<Vector2>
            {
                
            };

            wg = new WallGenerator();
            fg = new FloorGenerator();
            arrayChecker = new ArrayChecker();
            inputChecker = new InputChecker();
            pointGenerator = new PointCreator();
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
            
            if (inputChecker.Check(startPoint, endPoint, out float x, out float z))
            {
                Vector2 point = new Vector2(x, z); 

                list.Add(point);

                Vector2[] array = arrayChecker.Check(list.ToArray());

                pointGenerator.CreatePoint(point, canvas, font);

                wg.DestroyWalls();
                wg.GenerateWall(array, wallHeigth, wallMaterial);

                fg.DestroyFloor();
                fg.GenerateFloor(array, floorMaterial);

                startPoint.text = string.Empty;
                endPoint.text = string.Empty;
            }


        }

        private void OnUndoClick()
        {
            if (list.Count > 0)
            {
                list.RemoveAt(list.Count - 1);
                pointGenerator.DeleteLastPoint();
                wg.DestroyLastAdded();
                fg.DestroyFloor();
                fg.GenerateFloor(list.ToArray(), floorMaterial);
            }
        }
    }
}