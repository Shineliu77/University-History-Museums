using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public string WebPath;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenWeb() {
        //Application.OpenURL(WebPath);
        Application.ExternalEval("window.open('" + WebPath + "','_self')");

    }
}
