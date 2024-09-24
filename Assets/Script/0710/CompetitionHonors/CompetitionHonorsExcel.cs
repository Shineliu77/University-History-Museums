using UnityEngine;
using Excel;
using System.Data;
using System.IO;
using System.Collections.Generic;
using OfficeOpenXml;
using System;
using System.Collections;
using UnityEngine.UI;


public class CompetitionHonorsExcel : MonoBehaviour
{
	public List<string> ExcelData;
	public string ExcelDataPath;
	public int DataID;
	[Header("年份在ExcelData的ID")]
	public Vector2[] DateID;
	int ID;
	[Header("計算數量與顏色(0深綠/1淺綠)")]
	public Vector3[] DateCountColor;
	[Header("計算總長度")]
	public float TotalLength;
	[Header("卷軸")]
	public GameObject DarkGreen, LightGreen;
	public GameObject Content, Reel;
	public Scrollbar ScrollbarHorizontal;
	// Use this for initialization
	void Awake()
	{
		// Excel 檔案位置
		string filePath = Application.streamingAssetsPath + "/" + ExcelDataPath;

		// 你要抓取 Excel檔裡的工作表名稱
		string set = "data";

		// 讀取 Excel檔案
		FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);

		// 創建讀取 Excel檔-xlsx
		IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

		//創建讀取 Excel檔-xls
		//IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);

		// 將讀取到 Excel檔暫存至內存
		//DataSet result = excelRead.AsDataSet();
		//excelReader.IsFirstRowAsColumnNames = true;
		DataSet result = excelReader.AsDataSet();
		int columns = result.Tables[0].Columns.Count;
		int rows = result.Tables[0].Rows.Count;
		//ExcelData=new String[columns*rows];
		do
		{
			// sheet name
			Debug.Log(excelReader.Name);
			while (excelReader.Read())
			{
				for (int i = 0; i < excelReader.FieldCount; i++)
				{

					string value = excelReader.IsDBNull(i) ? "" : excelReader.GetString(i);
					if (value != "")
						ExcelData.Add(value);
					//Debug.Log(value);
					DataID++;
					DataID = Mathf.Min(DataID, columns * rows);
				}
			}
		} while (excelReader.NextResult());

		// 獲得 Excel檔的行與列的數目
		// int columns = result.Tables[set].Columns.Count;
		//int rows = result.Tables[set].Rows.Count;
		//儲存Data
		excelReader.Close();
		StartCoroutine(DataParse());
	}
	IEnumerator DataParse() {
		for (int i = 0; i < ExcelData.Count; i++) {
			if (ExcelData[i].Split('(').Length > 0)
			{
				if (ExcelData[i].Split('(')[0] == DateID[ID].x.ToString())
				{
					DateID[ID].y = i;
					ID++;
					ID = Mathf.Clamp(ID, 0, DateID.Length-1);
				}
			}
		}
		yield return new WaitForEndOfFrame();
		for (int j = 0; j < DateID.Length; j+=2) {
			if (j < DateID.Length - 1)
			{
				DateCountColor[j] = new Vector3((DateID[j + 1].y - DateID[j].y) / 3, 0, ((DateID[j + 1].y - DateID[j].y) / 3)*100+200);
				DateCountColor[j + 1] = new Vector3((DateID[j + 2].y - DateID[j + 1].y) / 3, 1, ((DateID[j + 2].y - DateID[j + 1].y) / 3) * 100 + 200);
			}
			else {
				DateCountColor[j] = new Vector3((DateID[DateID.Length-1].y - DateID[j-1].y) / 3, 0, ((DateID[DateID.Length - 1].y - DateID[j - 1].y) / 3) * 100 + 200);
			}
		}
		//計算總長度
		for (int p = 0; p < DateCountColor.Length; p++) {
			TotalLength +=DateCountColor[p].z;
			if (DateCountColor[p].y == 0)
			{
				GameObject DarkGreenPrefab = Instantiate(DarkGreen) as GameObject;
				DarkGreenPrefab.transform.parent = Reel.transform;
				DarkGreenPrefab.transform.localScale = new Vector3(1, 1, 1);
				DarkGreenPrefab.GetComponent<RectTransform>().sizeDelta = new Vector2(DateCountColor[p].z, 100f);
				DarkGreenPrefab.SetActive(true);
				DarkGreenPrefab.transform.GetChild(0).GetComponent<Text>().text = DateID[p].x.ToString();
				DarkGreenPrefab.GetComponent<CompetitionHonorsGroup>().StartID = DateID[p].y;
				if (p < DateCountColor.Length-1)
				{
					DarkGreenPrefab.GetComponent<CompetitionHonorsGroup>().EndID = DateID[p + 1].y;
				}
				else {
					DarkGreenPrefab.GetComponent<CompetitionHonorsGroup>().EndID = ExcelData.Count;
				}
			}
			else {
				GameObject LightGreenPrefab = Instantiate(LightGreen) as GameObject;
				LightGreenPrefab.transform.parent = Reel.transform;
				LightGreenPrefab.transform.localScale = new Vector3(1, 1, 1);
				LightGreenPrefab.GetComponent<RectTransform>().sizeDelta = new Vector2(DateCountColor[p].z, 100f);
				LightGreenPrefab.SetActive(true);
				LightGreenPrefab.transform.GetChild(0).GetComponent<Text>().text = DateID[p].x.ToString();
				LightGreenPrefab.GetComponent<CompetitionHonorsGroup>().StartID = DateID[p].y;
				if (p < DateCountColor.Length-1)
				{
					LightGreenPrefab.GetComponent<CompetitionHonorsGroup>().EndID = DateID[p + 1].y;
				}
				else
				{
					LightGreenPrefab.GetComponent<CompetitionHonorsGroup>().EndID = ExcelData.Count;
				}
			}
		}
		Content.GetComponent<RectTransform>().sizeDelta = new Vector2(TotalLength, 762.4696f);
		ScrollbarHorizontal.value = 1;
	}
	
}
