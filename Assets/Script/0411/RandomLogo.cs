using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLogo : MonoBehaviour
{
    public Texture[] LogoTextures;
    public float SetTime;
    float Timer;
    public Material LOGOMaterial;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= SetTime) {
            i++;
            if (i >= LogoTextures.Length-1) {
                i = 0;
            }
            LOGOMaterial.SetTexture("_MainTex", LogoTextures[i]);
            Timer = 0;
        }
    }
}
