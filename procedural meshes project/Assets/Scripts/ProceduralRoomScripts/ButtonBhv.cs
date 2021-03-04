using System;
using UnityEngine;

namespace Origin.ProceduralRoomScripts
{
    public class ButtonBhv : MonoBehaviour
    {
        public Action OnSubmitButtonClick;
        public Action OnUndoButtonClick;

        public void Submit()
        {
            OnSubmitButtonClick.Invoke();
        }

        public void Undo()
        {
            OnUndoButtonClick.Invoke();
        }
    }
}
