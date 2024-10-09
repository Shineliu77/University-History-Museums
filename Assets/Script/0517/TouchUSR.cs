using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchUSR : MonoBehaviour
{
    public GameObject OpenPDF;
    static public bool PDFState;
    //ni新增
    public PositionDetect PosDetect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //新增
        if(TryGetComponent(out Button button))
        {
            if (PosDetect.isIn)
            {
                button.interactable = true;
            }
            else
            {
                button.interactable = false;
            }
        }
    }
    public void OnMouseDown() {
        if (!PDFState)
        {
            OpenPDF.SetActive(true);
            PDFState = true;
        }
    }
    public void ClosePDF() {
        PDFState = false;
    }
}
