using System;
using UnityEngine;

namespace Origin.ProceduralRoomScripts
{
    public class ButtonBhv : MonoBehaviour
    {
        public Action onButtonClicked;

        public void RiseEvent()
        {
            onButtonClicked.Invoke();
        }
    }
}
