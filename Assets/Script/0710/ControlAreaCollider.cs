using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAreaCollider : MonoBehaviour
{
    [Header("管區所有碰撞器")]
    public Collider[] AreaColliders;
void OnEnable()
    {
        for (int i = 0; i < AreaColliders.Length; i++) {
            AreaColliders[i].enabled = false;
        }
    }
    private void OnDisable()
    {
        for (int i = 0; i < AreaColliders.Length; i++)
        {
            AreaColliders[i].enabled = true;
        }
    }
}
