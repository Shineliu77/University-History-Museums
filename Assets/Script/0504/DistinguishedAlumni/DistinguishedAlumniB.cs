using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistinguishedAlumniB : MonoBehaviour
{
    public Sprite Pic;
    public string Name;
    public string info;
    public Image BigPic;
    public Text BigName;
    public Text Biginfo;
    public GameObject BigObj;
    public RectTransform Content;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Content.offsetMax = new Vector2(0f, Mathf.Clamp(Content.offsetMax.y,0f,700f));
        //Content.offsetMin = new Vector2(0f, Mathf.Clamp(Content.offsetMin.y, -492.34f, 0f));

    }
    public void ClickButton() {
        BigObj.SetActive(true);
        BigPic.sprite = Pic;
        BigName.text = Name;
        Biginfo.text = info;
        /*Left- rectTransform.offsetMin.x;
        Right - rectTransform.offsetMax.x;
        Top - rectTransform.offsetMax.y;
        Bottom - rectTransform.offsetMin.y;*/
        Content.offsetMin = new Vector2(0f, -1500f);
        Content.offsetMax = new Vector2(0f, 0f);

       // Biginfo.rectTransform.offsetMin=new Vector2(0f, -675.0123f);
       // Biginfo.rectTransform.offsetMax = new Vector2(0f,0f);

    }
}
