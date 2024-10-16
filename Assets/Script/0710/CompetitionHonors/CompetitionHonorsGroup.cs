using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompetitionHonorsGroup : MonoBehaviour
{
    public GameObject[] Contents;
    public float StartID, EndID;
    public CompetitionHonorsExcel ExcelData;
    public GameObject Content;
    // Start is called before the first frame update
    void Start()
    {
        N_LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region Ni_�ק�
    void N_LoadData()
    {
        for (int i = 0; i < (EndID - StartID); i++)
        {
            GameObject Obj = Instantiate(Contents[i % 4]);
            Obj.transform.parent = Content.transform;
            Obj.SetActive(true);
            Obj.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>("CompetitionHonors/" + ExcelData.JsonDatas[i + (int)StartID].Num);
            Obj.transform.GetChild(2).GetComponent<Text>().text = ExcelData.JsonDatas[i + (int)StartID].State;
            Obj.transform.GetChild(1).GetComponent<CompetitionHonorsButton>().Date = ExcelData.JsonDatas[i + (int)StartID].Year;
        }
    }
    #endregion// Ni_�ק�

    void LoadData() {
        for (int i = 0; i < (EndID - StartID) / 3; i++) {
            GameObject Obj=Instantiate(Contents[i % 4]);
            Obj.transform.parent = Content.transform;
            Obj.SetActive(true);
            Obj.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>("CompetitionHonors/" + ExcelData.ExcelData[(i * 3)+2+(int)StartID]);
            Obj.transform.GetChild(2).GetComponent<Text>().text =ExcelData.ExcelData[(i * 3)+1 + (int)StartID];
            Obj.transform.GetChild(1).GetComponent<CompetitionHonorsButton>().Date= ExcelData.ExcelData[(i * 3)  + (int)StartID];
        }
    }
}
