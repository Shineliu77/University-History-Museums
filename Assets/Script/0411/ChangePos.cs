using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePos : MonoBehaviour
{

    public Vector3 Pos;
    public Vector3 Angle;
    public Transform MainCamera;
    public GameObject FadObj;
    public GameObject MainCameraCube;
    [Header("每個區域的地圖")]
    public GameObject BigArea,BigAreaButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        if (mousePos.x >= (Screen.width / 5 * 4) && mousePos.y >= (Screen.height / 3))
        {
            MainCamera.GetComponent<Cam_Control>().enabled = false;
        }
        else
        {
            MainCamera.GetComponent<Cam_Control>().enabled = true;
        }
    }

    public void Change() {
        FadObj.SetActive(true);
        MainCamera.GetComponent<PlayerController>().enabled = false;
        MainCamera.position = Pos;
        MainCamera.eulerAngles = Angle;

        for (int i = 0; i < MainCamera.transform.childCount; i++) {
            MainCamera.transform.GetChild(i).gameObject.SetActive(false);
        }
        StartCoroutine(Wait());
    }
    private IEnumerator Wait()
    {
        Animator animator = FadObj.GetComponent<Animator>();
        AnimatorClipInfo[] m_CurrentClipInfo;
        m_CurrentClipInfo = animator.GetCurrentAnimatorClipInfo(0);
        yield return new WaitForSeconds(m_CurrentClipInfo[0].clip.length);
        MainCamera.GetComponent<PlayerController>().enabled = true;
        FadObj.SetActive(false);
        MainCameraCube.SetActive(true);
    }
    public void SetBigArea(bool State) {
        BigArea.SetActive(State);
           BigAreaButton.SetActive(State);
    }
}
