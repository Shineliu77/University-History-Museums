using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchUSR : MonoBehaviour
{
    public GameObject OpenPDF;
    static public bool PDFState;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
