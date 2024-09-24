using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memorabilia : MonoBehaviour
{
    public Material[] MemorabiliaMaterials;
    public Texture[] MaterialTextures;
    public float UpdateTexture;
    bool isChange;
    // Start is called before the first frame update
    void Start()
    {
        MemorabiliaMaterials[0].mainTexture = MaterialTextures[0];
        MemorabiliaMaterials[1].mainTexture = MaterialTextures[1];
        MemorabiliaMaterials[2].mainTexture = MaterialTextures[2];
        MemorabiliaMaterials[3].mainTexture = MaterialTextures[3];
        InvokeRepeating("ChangeTexture", UpdateTexture, UpdateTexture);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ChangeTexture() {
        isChange = !isChange;
        switch (isChange) {
            case true:
                MemorabiliaMaterials[0].mainTexture = MaterialTextures[4];
                MemorabiliaMaterials[1].mainTexture = MaterialTextures[5];
                MemorabiliaMaterials[2].mainTexture = MaterialTextures[6];
                MemorabiliaMaterials[3].mainTexture = MaterialTextures[7];
                break;
            case false:
                MemorabiliaMaterials[0].mainTexture = MaterialTextures[0];
                MemorabiliaMaterials[1].mainTexture = MaterialTextures[1];
                MemorabiliaMaterials[2].mainTexture = MaterialTextures[2];
                MemorabiliaMaterials[3].mainTexture = MaterialTextures[3];
                break;
        }

    }
}
