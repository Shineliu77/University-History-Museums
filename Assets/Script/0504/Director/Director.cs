using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Director : MonoBehaviour
{
    public Dropdown DropdownObj;
    [Header("董事長")]
    public List<GameObject> ChairmanObjs;
    [Header("董事")]
    public List<GameObject> DirectorObjs;
    [Header("理監事")]
    public List<GameObject> SupervisorObjs;

    public GameObject ChairmanPrefabObj, ChairmanParentObj, DirectorPrefabObj, DirectorParentObj, SupervisorPrefabObj, SupervisorParentObj;
    [Header("理監事整體物件")]
    public GameObject SupObj;

    public Scrollbar ScrollbarObj;

    // Start is called before the first frame update
    void Start()
    {
   

    }

    // Update is called once per frame
    void Update()
    {
     
    }
    public void CreateDropdownOptions() 
    {
        DropdownObj.AddOptions(GetComponent<LoadExcel_Director>().SessionText);
        DropdownObj.value = GetComponent<LoadExcel_Director>().SessionText.Count;

        N_ChangeDrop();
        //ChangeDropdown();
    }
    #region Ni_修改
    public void N_ChangeDrop()
    {
        #region 清除資料
        SupObj.SetActive(false);
        if (ChairmanObjs.Count > 0)
        {
            for (int j = 0; j < ChairmanObjs.Count; j++)
            {
                Destroy(ChairmanObjs[j]);
            }
            ChairmanObjs.Clear();
        }
        if (DirectorObjs.Count > 0)
        {
            for (int j = 0; j < DirectorObjs.Count; j++)
            {
                Destroy(DirectorObjs[j]);
            }
            DirectorObjs.Clear();
        }
        if (SupervisorObjs.Count > 0)
        {
            for (int j = 0; j < SupervisorObjs.Count; j++)
            {
                Destroy(SupervisorObjs[j]);
            }
            SupervisorObjs.Clear();
        }
        #endregion//清除資料
        if (DropdownObj.value < GetComponent<LoadExcel_Director>().SessionText.Count - 1)
        {

            for (int i = GetComponent<LoadExcel_Director>().N_StartID[DropdownObj.value]; i < GetComponent<LoadExcel_Director>().N_StartID[DropdownObj.value + 1]; i++)
            {
                N_LoadData(i);
            }
        }
        else
        {
            for (int i = GetComponent<LoadExcel_Director>().N_StartID[DropdownObj.value]; i < GetComponent<LoadExcel_Director>().JsonDatas.Count; i++)
            {
                //Debug.Log(GetComponent<LoadExcel_Director>().SessionID[DropdownObj.value]);
                //Debug.Log(GetComponent<LoadExcel_Director>().ExcelData.Count);
                N_LoadData(i);
            }
        }
    }

    void N_LoadData(int ID)
    {
        if (GetComponent<LoadExcel_Director>().JsonDatas[ID].Job == "董事長")
        {
            GameObject ChairmanObj = Instantiate(ChairmanPrefabObj);
            ChairmanObjs.Add(ChairmanObj);
            ChairmanObj.transform.parent = ChairmanParentObj.transform;
            ChairmanObj.transform.localScale = new Vector3(1, 1, 1);
            ChairmanObj.SetActive(true);
            ChairmanObj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Director/" + GetComponent<LoadExcel_Director>().JsonDatas[ID].Num);
            ChairmanObj.GetComponentInChildren<Text>().text = GetComponent<LoadExcel_Director>().JsonDatas[ID].Name;

        }
        if (GetComponent<LoadExcel_Director>().JsonDatas[ID].Job == "董　事")
        {
            GameObject DirectorObj = Instantiate(DirectorPrefabObj);
            DirectorObjs.Add(DirectorObj);
            DirectorObj.transform.parent = DirectorParentObj.transform;
            DirectorObj.transform.localScale = new Vector3(1, 1, 1);
            DirectorObj.SetActive(true);
            DirectorObj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Director/" + GetComponent<LoadExcel_Director>().JsonDatas[ID].Num);
            DirectorObj.GetComponentInChildren<Text>().text = GetComponent<LoadExcel_Director>().JsonDatas[ID].Name;
        }
        if (GetComponent<LoadExcel_Director>().JsonDatas[ID].Job == "監察人")
        {
            SupObj.SetActive(true);
            GameObject SupervisorObj = Instantiate(SupervisorPrefabObj);
            SupervisorObjs.Add(SupervisorObj);
            SupervisorObj.transform.parent = SupervisorParentObj.transform;
            SupervisorObj.transform.localScale = new Vector3(1, 1, 1);
            SupervisorObj.SetActive(true);
            SupervisorObj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Director/" + GetComponent<LoadExcel_Director>().JsonDatas[ID].Num);
            SupervisorObj.GetComponentInChildren<Text>().text = GetComponent<LoadExcel_Director>().JsonDatas[ID].Name;
        }
    }
    #endregion
    public void ChangeDropdown()
    {
        SupObj.SetActive(false);

        if (ChairmanObjs.Count > 0) {
            for (int j = 0; j < ChairmanObjs.Count; j++) {
                Destroy(ChairmanObjs[j]);
            }
            ChairmanObjs.Clear();
        }
        if (DirectorObjs.Count > 0)
        {
            for (int j = 0; j < DirectorObjs.Count; j++)
            {
                Destroy(DirectorObjs[j]);
            }
            DirectorObjs.Clear();
        }
        if (SupervisorObjs.Count > 0)
        {
            for (int j = 0; j < SupervisorObjs.Count; j++)
            {
                Destroy(SupervisorObjs[j]);
            }
            SupervisorObjs.Clear();
        }
        if (DropdownObj.value < GetComponent<LoadExcel_Director>().SessionText.Count - 1)
        {
            for (int i = GetComponent<LoadExcel_Director>().SessionID[DropdownObj.value]; i < GetComponent<LoadExcel_Director>().SessionID[DropdownObj.value + 1]; i++)
            {
                LoadData(i);
            }
        }
        else {
            for (int i = GetComponent<LoadExcel_Director>().SessionID[DropdownObj.value]; i < GetComponent<LoadExcel_Director>().ExcelData.Count; i++)
            {
                Debug.Log(GetComponent<LoadExcel_Director>().SessionID[DropdownObj.value]);
                Debug.Log(GetComponent<LoadExcel_Director>().ExcelData.Count);

                LoadData(i);
            }
        }
    }
    void LoadData(int ID) {
        if (GetComponent<LoadExcel_Director>().ExcelData[ID] == "董事長")
        {
            GameObject ChairmanObj = Instantiate(ChairmanPrefabObj);
            ChairmanObjs.Add(ChairmanObj);
            ChairmanObj.transform.parent = ChairmanParentObj.transform;
            ChairmanObj.transform.localScale = new Vector3(1, 1, 1);
            ChairmanObj.SetActive(true);
            ChairmanObj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Director/" + GetComponent<LoadExcel_Director>().ExcelData[ID + 1]);
            ChairmanObj.GetComponentInChildren<Text>().text = GetComponent<LoadExcel_Director>().ExcelData[ID + 2];

        }
        if (GetComponent<LoadExcel_Director>().ExcelData[ID] == "董　事")
        {
            GameObject DirectorObj = Instantiate(DirectorPrefabObj);
            DirectorObjs.Add(DirectorObj);
            DirectorObj.transform.parent = DirectorParentObj.transform;
            DirectorObj.transform.localScale = new Vector3(1, 1, 1);
            DirectorObj.SetActive(true);
            DirectorObj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Director/" + GetComponent<LoadExcel_Director>().ExcelData[ID + 1]);
            DirectorObj.GetComponentInChildren<Text>().text = GetComponent<LoadExcel_Director>().ExcelData[ID + 2];
        }
        if (GetComponent<LoadExcel_Director>().ExcelData[ID] == "監察人")
        {
            SupObj.SetActive(true);
            GameObject SupervisorObj = Instantiate(SupervisorPrefabObj);
            SupervisorObjs.Add(SupervisorObj);
            SupervisorObj.transform.parent = SupervisorParentObj.transform;
            SupervisorObj.transform.localScale = new Vector3(1, 1, 1);
            SupervisorObj.SetActive(true);
            SupervisorObj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Director/" + GetComponent<LoadExcel_Director>().ExcelData[ID + 1]);
            SupervisorObj.GetComponentInChildren<Text>().text = GetComponent<LoadExcel_Director>().ExcelData[ID + 2];
        }
    }
}
