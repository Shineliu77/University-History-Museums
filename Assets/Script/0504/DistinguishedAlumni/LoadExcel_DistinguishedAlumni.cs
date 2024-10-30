using UnityEngine;
using Excel;
using System.Data;
using System.IO;
using System.Collections.Generic;
using OfficeOpenXml;
using System;
using System.Collections;
using LitJson;


public class LoadExcel_DistinguishedAlumni : MonoBehaviour {
	public List<string> ExcelData;
	public string ExcelDataPath;
	public int DataID;
	public List<string> SessionText;
	public List<int> SessionID;
	public int[] Number;

	#region Ni_修改
	public string N_JsonName;
	[Serializable]
	public class DistinguishJsonData
	{
		public string ChosenTime;
		public string Photo;
		public string Name;
		public string Department;
		public string Year;
		public string State;
		public string Contribute;
	}
	public List<DistinguishJsonData> JsonDatas;
	//顯示每屆的人物欄有幾個
	public int N_NowCount;
	public List<int> N_StartID;//資料的順序
	public List<int> N_DataCount = new List<int>();
	#endregion// Ni_修改

	// Use this for initialization
	void Awake () {

        #region  Ni_修改
        TextAsset dataFile = Resources.Load<TextAsset>(N_JsonName);
        JsonDatas.Clear();
        JsonDatas = JsonMapper.ToObject<List<DistinguishJsonData>>(dataFile.text);
        StartCoroutine(N_AnalyzeData());
        #endregion// Ni_修改
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
        //StartCoroutine(AnalyzeData());
        #endregion //OLD

    }
	#region Ni_修改
	IEnumerator N_AnalyzeData()
	{
		yield return new WaitForEndOfFrame();
		for (int i = 0; i < JsonDatas.Count; i++)
		{
			if (JsonDatas[i].ChosenTime != null)
			{
				if (i == 0)
				{
					int id = 0;
					N_StartID.Add(id);
					N_NowCount = 0;
				}
				else
				{
					if (N_NowCount != i)
					{
						N_StartID.Add(i);
						N_DataCount.Add((i - N_NowCount));
						N_NowCount = i;
					}
				}
				SessionText.Add(JsonDatas[i].ChosenTime);
				SessionID.Add(i);
			}
			if (i == JsonDatas.Count - 1)//最後一個
			{
				N_DataCount.Add((i - (N_NowCount - 1)));
				N_NowCount = i;
			}
		}
		GetComponent<DistinguishedAlumni>().CreateDropdownOptions();
	}
	#endregion// Ni_修改
	IEnumerator AnalyzeData() {
		yield return new WaitForEndOfFrame();
		for (int i = 0; i < ExcelData.Count; i++) {
			if (ExcelData[i].Contains("第") && ExcelData[i].Contains("屆") && ExcelData[i].Contains("民") && ExcelData[i].Contains("年")) {
				SessionText.Add(ExcelData[i]);
				SessionID.Add(i);
			}
		}
		yield return new WaitForEndOfFrame();
		Number = new int[SessionText.Count];
		for (int j = 0; j < SessionText.Count; j++)
		{
			if(j < SessionText.Count-1)
			Number[j] = (SessionID[j+1] - SessionID[j]) / 6;
			else
			Number[j] = (ExcelData.Count - SessionID[j]) / 6;

		}
		GetComponent<DistinguishedAlumni>().CreateDropdownOptions();
	}
}