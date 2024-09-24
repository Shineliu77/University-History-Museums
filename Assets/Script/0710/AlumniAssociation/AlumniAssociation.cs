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
    // Start is called before the first frame update
    void Start()
    {
        DateAnDatas.Clear();
        for (int i = 0; i < ExcelData.ExcelData.Count; i++) {
            if (ExcelData.ExcelData[i].Split('-')[0] == BigPhotoName) {
                DateAnDatas.Add(ExcelData.ExcelData[i + 1]);
                DateAnDatas.Add(ExcelData.ExcelData[i + 2]);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Content.offsetMax = new Vector2(0f, Mathf.Clamp(Content.offsetMax.y, ContentOffsetMax.x, ContentOffsetMax.y));
       // Content.offsetMin = new Vector2(0f, ContentOffsetMin.x);
    }
    public void ClickPhotoButton(int ID) {
        BigPhotoInfo.SetActive(true);
        BigPhotoInfo.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite=Resources.Load<Sprite>("AlumniAssociation/"+BigPhotoName +"/"+ ID);
        BigPhotoInfo.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = DateAnDatas[(ID)*2];
        BigPhotoInfo.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = DateAnDatas[(ID*2)+1];
    }
}
