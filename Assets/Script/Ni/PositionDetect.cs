using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionDetect : MonoBehaviour
{
    public bool isIn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out CheckBGM check))
        {
            isIn =true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out CheckBGM check))
        {
            isIn = false;
        }
    }
}
