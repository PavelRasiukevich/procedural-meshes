using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Origin.ProceduralRoomScripts
{
    public class InputChecker
    {
        public bool Check(InputField startPoint, InputField endPoint, out float _x,out float _z)
        {

            if (string.IsNullOrEmpty(startPoint.text) || string.IsNullOrEmpty(endPoint.text))
            {
                Debug.Log("Text Fields are empty");
                _x = 0;
                _z = 0;
                return false;
            }
            else
            {
                if (float.TryParse(startPoint.text, out float x) && float.TryParse(endPoint.text, out float z))
                {
                    _x = x;
                    _z = z;
                    return true;
                }
                else
                {
                    Debug.Log("Ivalid Input. Try more");
                    _x = 0;
                    _z = 0;
                    return false;
                }

            }

        }
    }
}