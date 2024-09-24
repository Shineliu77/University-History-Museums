using UnityEngine;
using Excel;
using System.Data;
using System.IO;
using System.Collections.Generic;
using OfficeOpenXml;
using System;
using System.Collections;
using UnityEngine.UI;

public class CampusHonorsExcel : MonoBehaviour
{
	public List<string> ExcelData;
	public string ExcelDataPath;
	public int DataID;
	public int OtherID, HigherEducationID, AwardSubsidyID;
	[Header("��L")]
	public GameObject Generate1, Prefab1;
	[Header("�����Ш|�p�e�ɧU�g�O")]
	public GameObject Generate2, Prefab2;
	[Header("�Ш|���ɧU�g�O")]
	public GameObject Generate3, Prefab3;

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
		CuttingData();
	}
	void CuttingData() {
		for (int i = 0; i < ExcelData.Count; i++) {
			if (ExcelData[i] == "Other") {
				OtherID = i;
			}
			if (ExcelData[i] == "HigherEducation")
			{
				HigherEducationID = i;
			}
			if (ExcelData[i] == "AwardSubsidy")
			{
				AwardSubsidyID = i;
			}
		}
		//��L
		for (int i = 0; i < HigherEducationID/2; i++)
		{
			GameObject Prefab1Obj = Instantiate(Prefab1) as GameObject;
			Prefab1Obj.transform.parent = Generate1.transform;
			Prefab1Obj.transform.localScale = new Vector3(1f, 1f, 1f);
			Prefab1Obj.SetActive(true);
			Prefab1Obj.transform.GetChild(0).GetComponent<Text>().text = ExcelData[(i *2) + 1];
			Prefab1Obj.transform.GetChild(1).GetComponent<Text>().text = ExcelData[(i *2) + 2];

		}
		//�����Ш|�p�e�ɧU�g�O
		for (int i = 0; i < (AwardSubsidyID - HigherEducationID) / 4; i++)
		{
			GameObject Prefab2Obj = Instantiate(Prefab2) as GameObject;
			Prefab2Obj.transform.parent = Generate2.transform;
			Prefab2Obj.transform.localScale = new Vector3(1f, 1f, 1f);
			Prefab2Obj.SetActive(true);
			Prefab2Obj.transform.GetChild(0).GetComponent<Text>().text = "����"+ExcelData[(i * 4) + 1 + HigherEducationID].Split('-')[0]+"�~("+ ExcelData[(i * 4) + 1 + HigherEducationID].Split('-')[1] + ")";
			Prefab2Obj.transform.GetChild(1).GetComponent<Text>().text = "$" + int.Parse(ExcelData[(i * 4) + 2 + HigherEducationID]).ToString("N0") + "��";
			Prefab2Obj.transform.GetChild(2).GetComponent<Text>().text = "����ƦW��" + ExcelData[(i * 4) + 3 + HigherEducationID] + "�W\n"+ "�p�߱ƦW��" + ExcelData[(i * 4) + 4+ HigherEducationID] + "�W" ;
		}
		//�Ш|���ɧU�g�O
		for (int i = 0; i < (ExcelData.Count - AwardSubsidyID) / 3; i++) {
			GameObject Prefab3Obj=Instantiate(Prefab3)as GameObject;
			Prefab3Obj.transform.parent = Generate3.transform;
			Prefab3Obj.transform.localScale = new Vector3(1f, 1f, 1f);
			Prefab3Obj.SetActive(true);
			Prefab3Obj.transform.GetChild(0).GetComponent<Text>().text = ExcelData[(i*3)+1+ AwardSubsidyID];
			Prefab3Obj.transform.GetChild(1).GetComponent<Text>().text = "$"+int.Parse(ExcelData[(i * 3) + 2 + AwardSubsidyID]).ToString("N0") +"��";
			Prefab3Obj.transform.GetChild(2).GetComponent<Text>().text = "����ƦW��"+ExcelData[(i * 3) + 3 + AwardSubsidyID]+"�W";
		}

	}
}
