using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AlumniAssociation : MonoBehaviour
{
    public RectTransform Content;
    //public Vector2 ContentOffsetMin, ContentOffsetMax;
    //點照片出現照片說明
    public GameObject BigPhotoInfo;
    public string BigPhotoName;
    public List<string> DateAnDatas;
    public AlumniAssociationExcel ExcelData;
    int N_DataNum;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < ExcelData.N_SortJsonDatas.Count; i++)
        {
            if (ExcelData.N_SortJsonDatas[i].Name == BigPhotoName)
            {
                N_DataNum = i;
                break;
            }
        }
        #region OLD
        //DateAnDatas.Clear();
        //for (int i = 0; i < ExcelData.ExcelData.Count; i++) {
        //    if (ExcelData.ExcelData[i].Split('-')[0] == BigPhotoName) {
        //        DateAnDatas.Add(ExcelData.ExcelData[i + 1]);
        //        DateAnDatas.Add(ExcelData.ExcelData[i + 2]);

        //    }
        //}
        #endregion// OLD
    }

    // Update is called once per frame
    void Update()
    {
        //Content.offsetMax = new Vector2(0f, Mathf.Clamp(Content.offsetMax.y, ContentOffsetMax.x, ContentOffsetMax.y));
       // Content.offsetMin = new Vector2(0f, ContentOffsetMin.x);
    }
    public void ClickPhotoButton(int ID) 
    {
        #region Ni_修改
        BigPhotoInfo.SetActive(true);
        BigPhotoInfo.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("AlumniAssociation/" + BigPhotoName + "/" + ID);
        BigPhotoInfo.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = ExcelData.N_SortJsonDatas[N_DataNum].SortData[ID].Year;
        BigPhotoInfo.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = ExcelData.N_SortJsonDatas[N_DataNum].SortData[ID].State;
        #endregion//Ni_修改
       
        #region OLD
        //BigPhotoInfo.SetActive(true);
        //BigPhotoInfo.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("AlumniAssociation/" + BigPhotoName + "/" + ID);
        //BigPhotoInfo.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = DateAnDatas[(ID)*2];
        //BigPhotoInfo.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = DateAnDatas[(ID*2)+1];
        #endregion //OLD
    }
}
