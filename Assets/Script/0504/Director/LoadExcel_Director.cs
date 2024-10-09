using UnityEngine;
using Excel;
using System.Data;
using System.IO;
using System.Collections.Generic;
using UnityEngine.Networking;
using OfficeOpenXml;
using System;
using System.Collections;
using LitJson;

public class LoadExcel_Director : MonoBehaviour {
    public List<string> ExcelData;
    public string ExcelDataPath;

    public int DataID;
    public List<string> SessionText;
    public List<int> SessionID;

    #region  Ni_修改
    public string N_JsonName;
    [Serializable]
    public class DirectorData
    {
        //public bool isHead;
        public string DropNames;
        public string Job;
        public string Num;
        public string Name;
    }
    public List<DirectorData>JsonDatas;
    //顯示每屆的人物欄有幾個
    public int N_NowCount;
    public List<int> N_StartID;//資料的順序
    public List<int> N_DataCount = new List<int>();
    #endregion// Ni_修改

    // Use this for initialization
    void Awake() {
        #region Ni_修改
        TextAsset dataFile = Resources.Load<TextAsset>(N_JsonName);
        JsonDatas.Clear();
        JsonDatas = JsonMapper.ToObject<List<DirectorData>>(dataFile.text);
        StartCoroutine(N_Analyze());
        #endregion//Ni_修改

        #region OLD
        //  // Excel 檔案位置
        //  //Ni 新增
        //  //string filePath =Application.streamingAssetsPath+"/"+ExcelDataPath;
        ////  string filePath = Path.Combine(Application.streamingAssetsPath, ExcelDataPath);

        //  // 你要抓取 Excel檔裡的工作表名稱
        //  string set = "data";

        //  // 讀取 Excel檔案
        //  FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);

        //  // 創建讀取 Excel檔-xlsx
        //  IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

        //  //創建讀取 Excel檔-xls
        //  //IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);

        //  // 將讀取到 Excel檔暫存至內存
        //  //DataSet result = excelRead.AsDataSet();
        //  //excelReader.IsFirstRowAsColumnNames = true;
        //  DataSet result = excelReader.AsDataSet();
        //  int columns = result.Tables[0].Columns.Count;
        //  int rows = result.Tables[0].Rows.Count;
        //  //ExcelData=new String[columns*rows];
        //  do
        //  {
        //      // sheet name
        //      Debug.Log(excelReader.Name);
        //      while (excelReader.Read())
        //      {
        //          for (int i = 0; i < excelReader.FieldCount; i++)
        //          {

        //              string value = excelReader.IsDBNull(i) ? "" : excelReader.GetString(i);
        //              if (value != "")
        //                  ExcelData.Add(value);
        //              //Debug.Log(value);
        //              DataID++;
        //              DataID = Mathf.Min(DataID, columns * rows);
        //          }
        //      }
        //  } while (excelReader.NextResult());

        //  // 獲得 Excel檔的行與列的數目
        //  // int columns = result.Tables[set].Columns.Count;
        //  //int rows = result.Tables[set].Rows.Count;
        //  //儲存Data


        //  excelReader.Close();
        // StartCoroutine(AnalyzeData());
        #endregion OLD

    }
    IEnumerator N_Analyze()
    {
        yield return new WaitForEndOfFrame();
        for (int i = 0; i < JsonDatas.Count; i++)
        {
            if (JsonDatas[i].DropNames!=null)
            {
                if (i == 0)
                {
                    N_StartID.Add(0);
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
                SessionText.Add(JsonDatas[i].DropNames);
                SessionID.Add(i);
            }
            if (i == JsonDatas.Count-1)//最後一個
            {
                N_DataCount.Add((i - (N_NowCount-1)));
                N_NowCount = i;
            }
        }
        GetComponent<Director>().CreateDropdownOptions();
    }
    IEnumerator AnalyzeData() {
		yield return new WaitForEndOfFrame();
		for (int i = 0; i < ExcelData.Count; i++) {
			if (ExcelData[i].Contains("第") && ExcelData[i].Contains("屆") && ExcelData[i].Contains("民")) {
				SessionText.Add(ExcelData[i]);
				SessionID.Add(i);
			}
		}
		yield return new WaitForEndOfFrame();
		GetComponent<Director>().CreateDropdownOptions();

	}
}