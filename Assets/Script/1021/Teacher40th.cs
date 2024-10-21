using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teacher40th : MonoBehaviour
{
    public string Name, Class, Year, Info;

    public GameObject BigInfoObj;
    private void Awake()
    {
        transform.GetChild(0).GetChild(0).GetComponent<Text>().text = Name;
        GetComponent<Button>().onClick.AddListener(BigInfo);

    }

    public void BigInfo() {
        BigInfoObj.SetActive(true);
        BigInfoObj.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = GetComponent<Image>().sprite;
        BigInfoObj.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<Text>().text = Name;
        BigInfoObj.transform.GetChild(1).GetChild(2).GetChild(1).GetComponent<Text>().text = "單位/科系:"+Class;
        BigInfoObj.transform.GetChild(1).GetChild(2).GetChild(2).GetComponent<Text>().text = "到職年份:"+Year;
        BigInfoObj.transform.GetChild(1).GetChild(2).GetChild(3).GetComponent<Text>().text = "說明:"+Info;

    }
}
