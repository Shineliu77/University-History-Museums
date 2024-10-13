using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjRotate : MonoBehaviour
{
    public Vector3 Speed;
    public float Angle;
    public bool Angles_X, Angles_Y,Angles_Z;
    public GameObject CloseObj;
    [Header("琌ノ菲公北 菲公北ゴつ")]
    public bool isMouse;
    //臂锣
    float OffsetY;
    float OffsetX;
    public float SpeedObj;

    public Vector2 SetPlusMinus;

    //罽
    public float MinScale;
    public float MaxScale;
    float scale=1f;
    public float RangeScale;

    [Header("ゴつ璶セUI")]
    public bool isOpenOriginalUI;
    public GameObject OriginalUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMouse)
        {
            if (Input.GetMouseButton(1)) {
                OffsetX = Input.GetAxis("Mouse X");
                OffsetY = Input.GetAxis("Mouse Y");
                transform.Rotate(new Vector3(OffsetY* SetPlusMinus.x, OffsetX * SetPlusMinus.y, 0) * SpeedObj, Space.World);
              /*  if (Angles_Y) transform.localEulerAngles = new Vector3(Angle, transform.localEulerAngles.y, Angle);
                if (Angles_X) transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Angle, Angle);
                if (Angles_Z) transform.localEulerAngles = new Vector3(Angle, Angle, transform.localEulerAngles.z);*/
            }
        }
        else
        {
            transform.Rotate(Speed.x * Time.deltaTime, Speed.y * Time.deltaTime, Speed.z * Time.deltaTime);
           

        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0) {
            scale += RangeScale * Input.GetAxis("Mouse ScrollWheel");
            scale = Mathf.Clamp(scale, MinScale, MaxScale);
            transform.localScale = new Vector3(scale, scale, scale);
        }
    }
   /* private void OnMouseDown()
    {
        CloseObj.SetActive(false);
        if (isOpenOriginalUI) {
            OriginalUI.SetActive(true);
        }
    }*/
}
