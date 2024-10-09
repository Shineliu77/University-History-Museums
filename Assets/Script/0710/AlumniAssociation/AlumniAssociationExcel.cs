using UnityEngine;
using Excel;
using System.Data;
using System.IO;
using System.Collections.Generic;
using OfficeOpenXml;
using System;
using UnityEngine.UI;
using LitJson;

public class AlumniAssociationExcel : MonoBehaviour
{
	public List<string> ExcelData;
	public string ExcelDataPath;
	public int DataID;

	#region Ni_修改
	public string N_JsonName;
	public List<AlumniSortData> N_SortJsonDatas;
	[Serializable]
	public class AlumniJsonData
	{
		public string Num;
		public string Year;
		public string State;
	}
	[Serializable]
	public class AlumniSortData
	{
		public string Name;//我這邊先設好?
		public List<AlumniJsonData> SortData;
	}
	void N_SetData()
	{
        for (int i = 0; i < N_SortJsonDatas.Count; i++)
        {
			TextAsset dataFile = Resources.Load<TextAsset>(N_JsonName+"/"+i);
			List<AlumniJsonData> jsondatas = JsonMapper.ToObject<List<AlumniJsonData>>(dataFile.text);
			N_SortJsonDatas[i].SortData = jsondatas;
		}
	}
	#endregion//Ni_修改
	// Use this for initialization
	void Awake()
	{
		N_SetData();
		 
        #region OLD
  //      // Excel 檔案位置
  //      string filePath = Application.streamingAssetsPath + "/" + ExcelDataPath;

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
		//	// sheet name
		//	Debug.Log(excelReader.Name);
		//	while (excelReader.Read())
		//	{
		//		for (int i = 0; i < excelReader.FieldCount; i++)
		//		{

		//			string value = excelReader.IsDBNull(i) ? "" : excelReader.GetString(i);
		//			if (value != "")
		//				ExcelData.Add(value);
		//			//Debug.Log(value);
		//			DataID++;
		//			DataID = Mathf.Min(DataID, columns * rows);
		//		}
		//	}
		//} while (excelReader.NextResult());

		//// 獲得 Excel檔的行與列的數目
		//// int columns = result.Tables[set].Columns.Count;
		////int rows = result.Tables[set].Rows.Count;
		////儲存Data
		//excelReader.Close();
        #endregion//OLD

    }

}
