using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OverseasVisits : MonoBehaviour
{
    public Dropdown SelectArea;
    public GameObject[] Areas;
    public ScrollRect scrollRectObj;
    public RectTransform Content;
   // public Vector2 ContentOffsetMin, ContentOffsetMax;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // Content.offsetMax = new Vector2(0f, Mathf.Clamp(Content.offsetMax.y, ContentOffsetMax.x, ContentOffsetMax.y));
      //  Content.offsetMin = new Vector2(0f, ContentOffsetMin.x);
    }
    public void ChangeArea() {
        for (int i = 0; i < Areas.Length; i++) {
            Areas[i].SetActive(false);
        }
        Content.offsetMax = new Vector2(0f,0f);

        switch (SelectArea.value) {
            case 1:
                Areas[0].SetActive(true);
                scrollRectObj.enabled = false;
                break;
            case 2:
                Areas[1].SetActive(true);
                scrollRectObj.enabled = false;
                break;
            case 3:
                Areas[2].SetActive(true);
                scrollRectObj.enabled = false;
                break;
            case 0:
                Areas[0].SetActive(true);
                Areas[1].SetActive(true);
                Areas[2].SetActive(true);
                scrollRectObj.enabled = true;

                break;
        }
    }
}
