using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Paroxe.PdfRenderer;
public class ChairmanButton : MonoBehaviour
{
    public ChairmanExcel GetChairmanExcel;
     int ID;
    public bool isRed;
    public GameObject Red, Blue;
    public PDFViewer PDFViewerObj;
    public string[] PDFNames;
    private void Awake()
    {
        ID = int.Parse(gameObject.name);
        if (ID % 2 == 0) {
            isRed = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisplayData() {

        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Chairman/" + GetChairmanExcel.ExcelData[(ID*4)]);
     //  transform.GetChild(1).GetComponent<Text>().text = GetChairmanExcel.ExcelData[(ID * 4) + 1];
       transform.GetChild(2).GetComponent<Text>().text = GetChairmanExcel.ExcelData[(ID * 4) + 1];
    }
    public void ClickButton() {
        PDFViewerObj.FileName = PDFNames[(ID-1)]+ ".pdf";

        if (isRed)
        {
            Red.SetActive(true);
            Red.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = transform.GetChild(1).GetComponent<Text>().text;
            Red.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
            Red.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = transform.GetChild(2).GetComponent<Text>().text;
            Red.transform.GetChild(0).GetChild(3).GetComponent<Text>().text = GetChairmanExcel.ExcelData[(ID * 4) + +2]+"\n\n"+ GetChairmanExcel.ExcelData[(ID * 4) + 3];
        }
        else {
            Blue.SetActive(true);
            Blue.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = transform.GetChild(1).GetComponent<Text>().text;
            Blue.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
            Blue.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = transform.GetChild(2).GetComponent<Text>().text;
            Blue.transform.GetChild(0).GetChild(3).GetComponent<Text>().text = GetChairmanExcel.ExcelData[(ID * 4) + +2] + "\n\n" + GetChairmanExcel.ExcelData[(ID * 4) + 3];
        }
    }
}
