using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class CheckBGM : MonoBehaviour
{
    public GameObject BGM;
    public GameObject Video;
    public string OldGroundTag;
    public List<Collider> HitFloors;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      /*  RaycastHit hit;

        if (Physics.Raycast(transform.position, -Vector3.up, out hit)) {
            Debug.DrawLine(transform.position, hit.collider.gameObject.transform.position, Color.red);
           if(OldGroundTag!= hit.collider.tag)
            {
                if (hit.collider.tag == "Ground") {
                    BGM.GetComponent<AudioSource>().mute=false;
                    Video.GetComponent<VideoPlayer>().SetDirectAudioMute(0,true);
                }
                if (hit.collider.tag == "Ground1")
                {
                    BGM.GetComponent<AudioSource>().mute = true;
                    Video.GetComponent<VideoPlayer>().SetDirectAudioMute(0, false);
                }
                OldGroundTag = hit.collider.tag;
            }      
        }
      */
    }
    private void OnTriggerStay(Collider hit)
    {
        if (OldGroundTag != hit.GetComponent<Collider>().tag)
        {
            if (hit.GetComponent<Collider>().tag == "Ground")
            {
               // HitFloors.Add(hit);
                BGM.GetComponent<AudioSource>().mute = false;
                Video.GetComponent<VideoPlayer>().SetDirectAudioMute(0, true);
                //if (HitFloors.Count == 0)
                //{
                //    HitFloors.Add(hit);
                //    BGM.GetComponent<AudioSource>().mute = false;
                //    Video.GetComponent<VideoPlayer>().SetDirectAudioMute(0, true);
                //}
                //else
                //{
                //    bool isObj = false;
                //    for (int i = 0; i < HitFloors.Count; i++)
                //    {
                //        if (HitFloors[i] == hit)
                //        {
                //            isObj = true;
                //            break;
                //        }
                //    }
                //    if (!isObj)
                //    {
                //        HitFloors.Add(hit);
                //        BGM.GetComponent<AudioSource>().mute = false;
                //        Video.GetComponent<VideoPlayer>().SetDirectAudioMute(0, true);
                //    }
                //}
            }
            if (hit.GetComponent<Collider>().tag == "Ground1")
            {
             //   HitFloors.Add(hit);
                BGM.GetComponent<AudioSource>().mute = true;
                Video.GetComponent<VideoPlayer>().SetDirectAudioMute(0, false);
                //if (HitFloors.Count == 0)
                //{
                //    HitFloors.Add(hit);
                //    BGM.GetComponent<AudioSource>().mute = true;
                //    Video.GetComponent<VideoPlayer>().SetDirectAudioMute(0, false);
                //}
                //else
                //{
                //    bool isObj = false;
                //    for (int i = 0; i < HitFloors.Count; i++)
                //    {
                //        if (HitFloors[i] == hit)
                //        {
                //            isObj = true;
                //            break;
                //        }
                //    }
                //    if (!isObj)
                //    {
                //        HitFloors.Add(hit);
                //        BGM.GetComponent<AudioSource>().mute = true;
                //        Video.GetComponent<VideoPlayer>().SetDirectAudioMute(0, false);
                //    }
                //}

            }
            OldGroundTag = hit.GetComponent<Collider>().tag;
        }
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    if (HitFloors.Count != 0)
    //    {
    //        for (int i = 0; i < HitFloors.Count; i++)
    //        {
    //            if (HitFloors[i] == other)
    //            {
    //                HitFloors.Remove(HitFloors[i]);
    //            }
    //        }
    //    }
    //}
}
