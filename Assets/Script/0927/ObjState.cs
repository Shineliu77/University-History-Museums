using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjState : MonoBehaviour
{
    private void OnEnable()
    {
        TouchObj.IsUIOpen = true;
    }
    private void OnDisable()
    {
        TouchObj.IsUIOpen = false;
    }
}
