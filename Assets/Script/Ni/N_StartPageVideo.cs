using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class N_StartPageVideo : MonoBehaviour
{
    public GameObject BigInfo;
    public AudioSource BGM;
    public VideoPlayer Video;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayVideo()
    {
        BigInfo.SetActive(true);
        Video.targetTexture.Release();
        BGM.mute = true;
        Video.Play();

        StartCoroutine(EndPlay());
       // Invoke("SetCoroutine", 1f);
    }
    public void SetCoroutine()
    {
    }
    IEnumerator EndPlay()
    {
        yield return new WaitUntil(() => Video.isPlaying);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => !Video.isPlaying);
        Video.Stop();
        BigInfo.SetActive(false);
        BGM.mute = false;
    }
    public void CloseVideo()
    {
       // CancelInvoke("SetCoroutine");
        StopCoroutine(EndPlay());
        Video.Stop();
        BigInfo.SetActive(false);
        BGM.mute = false;
    }
}
