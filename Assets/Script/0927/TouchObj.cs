using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;
public class TouchObj : MonoBehaviour
{
    //public GameObject Tips;
    public GameObject BigInfo;
    static public bool IsUIOpen;
    [Header("關閉校歌打勾")]
    public bool isStopSchoolVideo;
    public VideoPlayer SchoolVideo;
    //ni新增
    public PositionDetect PosDetect;
    public UnityEvent TouchEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(IsUIOpen);
        //新增
        if (TryGetComponent(out Collider collider))
        {
            if (PosDetect.isIn)
            {
                collider.enabled = true;
            }
            else
            {
                collider.enabled = false;
            }
        }
    }
    private void OnMouseDown()
    {
        if (!IsUIOpen)
        {
            BigInfo.SetActive(true);
            TouchEvent.Invoke();
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
