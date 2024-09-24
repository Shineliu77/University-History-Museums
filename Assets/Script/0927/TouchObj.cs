using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class TouchObj : MonoBehaviour
{
    //public GameObject Tips;
    public GameObject BigInfo;
    static public bool IsUIOpen;
    [Header("Ãö³¬®Õºq¥´¤Ä")]
    public bool isStopSchoolVideo;
    public VideoPlayer SchoolVideo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (!IsUIOpen)
        {
            BigInfo.SetActive(true);
            if (isStopSchoolVideo) {
                SchoolVideo.Stop();
            }
        }
    }

    /*void OnMouseOver()
    {
        Tips.SetActive(true);
    }
    void OnMouseExit()
    {
        Tips.SetActive(false);

    }*/
}
