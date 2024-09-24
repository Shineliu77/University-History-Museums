using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCameraScriptState : MonoBehaviour
{
    public Cam_Control Cam_ControlObj;
    public PlayerController PlayerController_Scr;
    void OnEnable() {
        Cam_ControlObj.enabled = false;
        PlayerController_Scr.enabled = false;
    }
    private void Update()
    {
        if (gameObject.active) {
            Cam_ControlObj.enabled = false;
            PlayerController_Scr.enabled = false;
        }
    }
    void OnDisable() {
        Cam_ControlObj.enabled = true;
        PlayerController_Scr.enabled = true;

    }
}
