using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompetitionHonorsButton : MonoBehaviour
{
    public GameObject BigObj;
    public string Date;
    public Transform Parent;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(ClickButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ClickButton() {
        BigObj.SetActive(true);
        BigObj.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = Parent.transform.GetChild(1).GetComponent<Image>().sprite;
        BigObj.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = Date;
        BigObj.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = Parent.transform.GetChild(2).GetComponent<Text>().text;
    }
}
