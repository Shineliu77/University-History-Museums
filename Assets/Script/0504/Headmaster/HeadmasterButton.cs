using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadmasterButton : MonoBehaviour
{
    public HeadmasterExcel GetHeadmasterExcel;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetID() {
        ID = int.Parse(gameObject.name);
      
    }
    public void DisplayData() 
    {
        SetID();
        #region Ni_新增
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Headmaster/" + GetHeadmasterExcel.JsonDatas[ID - 1].Num);
        transform.GetChild(1).GetComponent<Text>().text = GetHeadmasterExcel.JsonDatas[ID - 1].Order;
        transform.GetChild(2).GetComponent<Text>().text = GetHeadmasterExcel.JsonDatas[ID - 1].Name;
        #endregion// Ni_新增
        #region OLD
        //gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Headmaster/" + GetHeadmasterExcel.ExcelData[(ID * 4)]);
        //transform.GetChild(1).GetComponent<Text>().text = GetHeadmasterExcel.ExcelData[(ID * 4) + 1];
        //transform.GetChild(2).GetComponent<Text>().text = GetHeadmasterExcel.ExcelData[(ID * 4) + 2];
        #endregion// OLD
    }
    public void ClickButton() 
    {
        #region Ni_新增
        if (isRed)
        {
            Red.SetActive(true);
            Red.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = transform.GetChild(1).GetComponent<Text>().text;
            Red.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
            Red.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = transform.GetChild(2).GetComponent<Text>().text;
            Red.transform.GetChild(0).GetChild(3).GetComponent<Text>().text = GetHeadmasterExcel.JsonDatas[ID - 1].States;
        }
        else
        {
            Blue.SetActive(true);
            Blue.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = transform.GetChild(1).GetComponent<Text>().text;
            Blue.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
            Blue.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = transform.GetChild(2).GetComponent<Text>().text;
            Blue.transform.GetChild(0).GetChild(3).GetComponent<Text>().text = GetHeadmasterExcel.JsonDatas[ID - 1].States;
        }
        #endregion //Ni_新增

        #region OLD
        //if (isRed)
        //{
        //    Red.SetActive(true);
        //    Red.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = transform.GetChild(1).GetComponent<Text>().text;
        //    Red.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
        //    Red.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = transform.GetChild(2).GetComponent<Text>().text;
        //    Red.transform.GetChild(0).GetChild(3).GetComponent<Text>().text = GetHeadmasterExcel.ExcelData[(ID * 4) + 3];
        //}
        //else
        //{
        //    Blue.SetActive(true);
        //    Blue.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = transform.GetChild(1).GetComponent<Text>().text;
        //    Blue.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
        //    Blue.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = transform.GetChild(2).GetComponent<Text>().text;
        //    Blue.transform.GetChild(0).GetChild(3).GetComponent<Text>().text = GetHeadmasterExcel.ExcelData[(ID * 4) + 3];
        //}
        #endregion //OLD
    }
}
