using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HistoricalRelics : MonoBehaviour
{
    public GameObject BigObj;
    public string Data;
    public string Date;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ClickButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickButton() {
        BigObj.SetActive(true);
        BigObj.transform.GetChild(0).GetComponent<Image>().sprite = this.GetComponent<Image>().sprite;
        BigObj.transform.GetChild(1).GetComponent<Text>().text = Date;
        BigObj.transform.GetChild(2).GetComponent<Text>().text = Data;

    }
}
