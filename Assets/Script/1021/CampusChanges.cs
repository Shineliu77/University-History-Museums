using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CampusChanges : MonoBehaviour
{
    public Dropdown ChangesDropdown;
    public GameObject[] Campus;

    public GameObject BigInfoObj;

    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Button>())
        GetComponent<Button>().onClick.AddListener(BigInfo);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Change()
    {
        for (int i = 0; i < Campus.Length;i++) {
            Campus[i].SetActive(false);    
        }
        Campus[ChangesDropdown.value].SetActive(true);
    }

    public void BigInfo()
    {
        BigInfoObj.SetActive(true);
        BigInfoObj.transform.GetChild(0).GetComponent<Image>().sprite = GetComponent<Image>().sprite;
       // BigInfoObj.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = Year;
       // BigInfoObj.transform.GetChild(0).GetChild(3).GetComponent<Text>().text = Info;

    }
}
