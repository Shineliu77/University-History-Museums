using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SetVideo : MonoBehaviour
{
    public string VideoName;
    // Start is called before the first frame update
    void Start()
    {
        Set();
    }
    public void Set()
    {
        VideoPlayer videoPlayer = GetComponent<VideoPlayer>();
        string path = System.IO.Path.Combine(Application.streamingAssetsPath, VideoName);
        videoPlayer.url = path;
        videoPlayer.Play();
    }
    public void ResetVideoImage()
    {
        VideoPlayer videoPlayer = GetComponent<VideoPlayer>();
        if (videoPlayer.targetTexture != null)
        {
            videoPlayer.targetTexture.Release();
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
