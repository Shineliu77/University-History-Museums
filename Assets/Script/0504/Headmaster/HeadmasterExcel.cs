using UnityEngine;
using Excel;
using System.Data;
using System.IO;
using System.Collections.Generic;
using OfficeOpenXml;
using System;
using System.Collections;
using UnityEngine.UI;
using LitJson;


public class HeadmasterExcel : MonoBehaviour
{
	public List<string> ExcelData;
	public string ExcelDataPath;
	public int DataID;
	public bool CanLoadData;
	public GameObject[] HeadmasterObj;
	public int[] IDs;
	public List<string> HeadmasterStrings;
	public Dropdown DropdownObj;
	#region Ni_修改
	public string N_JsonName;
	[Serializable]
	public class HeadmasterJsonData
	{
		public int Num;
		public string Order;
		public string Name;
		public string States;
	}
	public List<HeadmasterJsonData> JsonDatas;
	#endregion// Ni_修改
	// Use this for initialization
	void Awake()
	{
        #region Ni_修改
        TextAsset dataFile = Resources.Load<TextAsset>(N_JsonName);
        JsonDatas.Clear();
        JsonDatas = JsonMapper.ToObject<List<HeadmasterJsonData>>(dataFile.text);
        SetObjID(0);
        #endregion//Ni_修改

        #region OLD
        //// Excel 檔案位置
        //string filePath = Application.streamingAssetsPath + "/" + ExcelDataPath;

        //// 你要抓取 Excel檔裡的工作表名稱
        //string set = "data";

        //// 讀取 Excel檔案
        //FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);

        //// 創建讀取 Excel檔-xlsx
        //IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

        ////創建讀取 Excel檔-xls
        ////IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);

        //// 將讀取到 Excel檔暫存至內存
        ////DataSet result = excelRead.AsDataSet();
        ////excelReader.IsFirstRowAsColumnNames = true;
        //DataSet result = excelReader.AsDataSet();
        //int columns = result.Tables[0].Columns.Count;
        //int rows = result.Tables[0].Rows.Count;
        ////ExcelData=new String[columns*rows];
        //do
        //{
        //    // sheet name
        //    Debug.Log(excelReader.Name);
        //    while (excelReader.Read())
        //    {
        //        for (int i = 0; i < excelReader.FieldCount; i++)
        //        {

        //            string value = excelReader.IsDBNull(i) ? "" : excelReader.GetString(i);
        //            if (value != "")
        //                ExcelData.Add(value);
        //            //Debug.Log(value);
        //            DataID++;
        //            DataID = Mathf.Min(DataID, columns * rows);
        //        }
        //    }
        //} while (excelReader.NextResult());

        //// 獲得 Excel檔的行與列的數目
        //// int columns = result.Tables[set].Columns.Count;
        ////int rows = result.Tables[set].Rows.Count;
        ////儲存Data
        //excelReader.Close();
        //SetObjID(0);
        #endregion //OLD

    }
    public void DropdownSetValue() {

		IDs[0] = DropdownObj.value+3;
			IDs[1] = DropdownObj.value+2;
			IDs[2] = DropdownObj.value+1;
			IDs[3] = DropdownObj.value;
			IDs[4] = DropdownObj.value-1;
			IDs[5] = DropdownObj.value-2;
			IDs[6] = DropdownObj.value-3;
			IDs[7] = DropdownObj.value-4;
			IDs[8] =DropdownObj.value-5;
		HeadmasterObj[2].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

		for (int i = 0; i < IDs.Length; i++)
		{
			if (IDs[i] > IDs.Length)
			{
				IDs[i]= IDs[i]%9;
			}
			if (IDs[i] < 1)
			{
				IDs[i] = IDs.Length+ IDs[i];
			}
			if (i % 2 == 0)
			{
				HeadmasterObj[i].GetComponent<HeadmasterButton>().isRed = false;
			}
			if (i % 2 == 1)
			{
				HeadmasterObj[i].GetComponent<HeadmasterButton>().isRed = true;
			}
			HeadmasterObj[i].name = IDs[i] + "";
		}
		HeadmasterObj[2].transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
		//StartCoroutine(AnalyzeData());
		StartCoroutine(N_AnalyzeData());
	}
	public void SetObjID(int ID)
	{
		HeadmasterObj[2].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
		for (int i = 0; i < IDs.Length; i++)
		{
			IDs[i] += ID;
			if (IDs[i] > IDs.Length)
			{
				IDs[i] = 1;
			}
			if (IDs[i] < 1)
			{
				IDs[i] = IDs.Length;
			}
			if (i % 2 == 0)
			{
				HeadmasterObj[i].GetComponent<HeadmasterButton>().isRed = false;
			}
			if (i % 2 == 1)
			{
				HeadmasterObj[i].GetComponent<HeadmasterButton>().isRed = true;
			}
			HeadmasterObj[i].name = IDs[i] + "";
		}

		HeadmasterObj[2].transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
		//StartCoroutine(AnalyzeData());
		StartCoroutine(N_AnalyzeData());

	}
	IEnumerator N_AnalyzeData()
	{
		HeadmasterStrings.Clear();

		yield return new WaitForEndOfFrame();
		for (int i = 0; i < JsonDatas.Count; i++)
		{
			yield return new WaitForEndOfFrame();
			string[] text = JsonDatas[i].States.Split('：');
			HeadmasterStrings.Add(JsonDatas[i].Order + " 民" + text[1]);
		}
		yield return new WaitForEndOfFrame();
		for (int i = 0; i < HeadmasterObj.Length; i++)
		{
			HeadmasterObj[i].GetComponent<HeadmasterButton>().DisplayData();
		}
		if (DropdownObj.options.Count < 1)
		{
			DropdownObj.AddOptions(HeadmasterStrings);
			DropdownObj.value = HeadmasterObj.Length - 1;
		}
	}
	IEnumerator AnalyzeData()
	{
		HeadmasterStrings.Clear();
		
		yield return new WaitForEndOfFrame();

		for (int o = 5; o < ExcelData.Count; o+=4)
		{
			yield return new WaitForEndOfFrame();
			string[] text = ExcelData[o + 2].Split('：');
			HeadmasterStrings.Add(ExcelData[o] + " 民" + text[1]);
		}
		yield return new WaitForEndOfFrame();

		for (int i = 0; i < HeadmasterObj.Length; i++)
		{
			//HeadmasterStrings.Add(ExcelData[]);
			HeadmasterObj[i].GetComponent<HeadmasterButton>().DisplayData();
		}
		if (DropdownObj.options.Count < 1)
		{
			DropdownObj.AddOptions(HeadmasterStrings);
			DropdownObj.value = HeadmasterObj.Length - 1;
		}
	}
}
