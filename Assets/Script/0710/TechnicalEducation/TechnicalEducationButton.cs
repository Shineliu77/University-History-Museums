using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TechnicalEducationButton : MonoBehaviour
{
    public TechnicalEducationExcel GetTechnicalEducationExcel;
     int ID;
    public bool isRed;
    public GameObject Red, Blue;

    private void Awake()
    {
        SetID();
    }
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ClickButton);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetID() {
        ID = int.Parse(gameObject.name)-1;
      
    }
    public void DisplayData() {
        SetID();
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = GetTechnicalEducationExcel.SinglePhoto[ID];
       transform.GetChild(1).GetComponent<Text>().text = GetTechnicalEducationExcel.ExcelData[(ID * 6) + 1];
       transform.GetChild(2).GetComponent<Text>().text = GetTechnicalEducationExcel.ExcelData[(ID * 6) + 2]+"-"+GetTechnicalEducationExcel.ExcelData[(ID * 6) + 3];
    }
    public void ClickButton() {
        if (isRed)
        {
            Red.SetActive(true);
            Red.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = transform.GetChild(1).GetComponent<Text>().text;
            Red.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = GetTechnicalEducationExcel.WinningPhoto[ID];
            Red.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = GetTechnicalEducationExcel.ExcelData[(ID * 6) + 4];

            Red.transform.GetChild(0).GetChild(3).GetComponent<Text>().text = transform.GetChild(2).GetComponent<Text>().text;
            Red.transform.GetChild(0).GetChild(4).GetComponent<Text>().text = GetTechnicalEducationExcel.ExcelData[(ID * 6) + 5];
        }
        else {
            Blue.SetActive(true);
            Blue.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = transform.GetChild(1).GetComponent<Text>().text;
            Blue.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = GetTechnicalEducationExcel.WinningPhoto[ID];
            Blue.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = GetTechnicalEducationExcel.ExcelData[(ID * 6) + 4];

            Blue.transform.GetChild(0).GetChild(3).GetComponent<Text>().text = transform.GetChild(2).GetComponent<Text>().text;
            Blue.transform.GetChild(0).GetChild(4).GetComponent<Text>().text = GetTechnicalEducationExcel.ExcelData[(ID * 6) + 5];
        }
    }
}
