using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistinguishedAlumni : MonoBehaviour
{
    public Dropdown DropdownObj;
    public List<GameObject> Objs;
    public GameObject PrefabObj, ParentObj;
    public List<int> ObjIDs;


    // Start is called before the first frame update
    void Start()
    {
   

    }

    // Update is called once per frame
    void Update()
    {
     
    }
    public void CreateDropdownOptions() {
        DropdownObj.AddOptions(GetComponent<LoadExcel_DistinguishedAlumni>().SessionText);
        DropdownObj.value = GetComponent<LoadExcel_DistinguishedAlumni>().SessionText.Count;
        ChangeDropdown();
    }
    public void ChangeDropdown()
    {
        #region Ni_修改
        if (Objs.Count > 0)
        {
            for (int j = 0; j < Objs.Count; j++)
            {
                Destroy(Objs[j]);
            }
            ObjIDs.Clear();
            Objs.Clear();
        }
        int StartID = GetComponent<LoadExcel_DistinguishedAlumni>().N_StartID[DropdownObj.value];
        for (int i = 0; i < GetComponent<LoadExcel_DistinguishedAlumni>().N_DataCount[DropdownObj.value]; i++)
        {
            GameObject obj = Instantiate(PrefabObj);
            Objs.Add(obj);
            obj.transform.parent = ParentObj.transform;
            obj.transform.localScale = new Vector3(1, 1, 1);
            obj.SetActive(true);
          //  ObjIDs.Add((GetComponent<LoadExcel_DistinguishedAlumni>().SessionID[DropdownObj.value] + 1) + (6 * i));
            obj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Distinguished Alumni/" + GetComponent<LoadExcel_DistinguishedAlumni>().JsonDatas[i+StartID].Photo);
           // obj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Distinguished Alumni/" + GetComponent<LoadExcel_DistinguishedAlumni>().ExcelData[ObjIDs[i]]);
            obj.GetComponentInChildren<Text>().text = GetComponent<LoadExcel_DistinguishedAlumni>().JsonDatas[i + StartID].Name;
            obj.GetComponent<DistinguishedAlumniB>().Pic = obj.GetComponent<Image>().sprite;
            obj.GetComponent<DistinguishedAlumniB>().Name = obj.GetComponentInChildren<Text>().text;
            obj.GetComponent<DistinguishedAlumniB>().info = "畢業系科:" + GetComponent<LoadExcel_DistinguishedAlumni>().JsonDatas[i + StartID].Department+
                "\n\n畢業年度:" + GetComponent<LoadExcel_DistinguishedAlumni>().JsonDatas[i + StartID].Year +
                "\n\n經歷:" + GetComponent<LoadExcel_DistinguishedAlumni>().JsonDatas[i + StartID].State +
                "\n\n對學校貢獻或優良事蹟:" + GetComponent<LoadExcel_DistinguishedAlumni>().JsonDatas[i + StartID].Contribute;
        }
        #endregion //Ni_修改
        #region OLD
        //if (Objs.Count > 0) {
        //    for (int j = 0; j < Objs.Count; j++) {
        //        Destroy(Objs[j]);
        //    }
        //    ObjIDs.Clear();
        //    Objs.Clear();
        //}
        //for (int i = 0; i < GetComponent<LoadExcel_DistinguishedAlumni>().Number[DropdownObj.value]; i++){
        //   GameObject obj=Instantiate(PrefabObj);
        //    Objs.Add(obj);
        //    obj.transform.parent = ParentObj.transform;
        //    obj.transform.localScale = new Vector3(1,1,1);
        //    obj.SetActive(true);
        //    ObjIDs.Add((GetComponent<LoadExcel_DistinguishedAlumni>().SessionID[DropdownObj.value]+1) + (6 * i));
        //    obj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Distinguished Alumni/" + GetComponent<LoadExcel_DistinguishedAlumni>().ExcelData[ObjIDs[i]]);
        //    obj.GetComponentInChildren<Text>().text = GetComponent<LoadExcel_DistinguishedAlumni>().ExcelData[ObjIDs[i] + 1];
        //    obj.GetComponent<DistinguishedAlumniB>().Pic = obj.GetComponent<Image>().sprite;
        //    obj.GetComponent<DistinguishedAlumniB>().Name = obj.GetComponentInChildren<Text>().text;
        //    obj.GetComponent<DistinguishedAlumniB>().info = "畢業系科:" + GetComponent<LoadExcel_DistinguishedAlumni>().ExcelData[ObjIDs[i] + 2] +
        //        "\n\n畢業年度:" + GetComponent<LoadExcel_DistinguishedAlumni>().ExcelData[ObjIDs[i] + 3] +
        //        "\n\n經歷:" + GetComponent<LoadExcel_DistinguishedAlumni>().ExcelData[ObjIDs[i] + 4] +
        //        "\n\n對學校貢獻或優良事蹟:" + GetComponent<LoadExcel_DistinguishedAlumni>().ExcelData[ObjIDs[i] + 5];
        //}
        #endregion //OLD
    }

}
