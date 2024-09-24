using UnityEngine;
using Excel;
using System.Data;
using System.IO;
using System.Collections.Generic;
using OfficeOpenXml;
using System;
using System.Collections;


public class ChairmanExcel : MonoBehaviour
{
	public List<string> ExcelData;
	public string ExcelDataPath;
	public int DataID;
	public bool CanLoadData;
	public GameObject[] ChairmanObj;
	// Use this for initialization
	void Awake()
	{
		// Excel �ɮצ�m
		string filePath = Application.streamingAssetsPath + "/" + ExcelDataPath;

		// �A�n��� Excel�ɸ̪��u�@��W��
		string set = "data";

		// Ū�� Excel�ɮ�
		FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);

		// �Ы�Ū�� Excel��-xlsx
		IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

		//�Ы�Ū�� Excel��-xls
		//IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);

		// �NŪ���� Excel�ɼȦs�ܤ��s
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

		// ��o Excel�ɪ���P�C���ƥ�
		// int columns = result.Tables[set].Columns.Count;
		//int rows = result.Tables[set].Rows.Count;
		//�x�sData
		excelReader.Close();
		StartCoroutine(AnalyzeData());

		
	}
	IEnumerator AnalyzeData()
	{
		yield return new WaitForEndOfFrame();
		for (int i = 0; i < ChairmanObj.Length; i++)
		{
			ChairmanObj[i].GetComponent<ChairmanButton>().DisplayData();
		}
	}
	}
