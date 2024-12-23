﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Logic : MonoBehaviour
{
    public float speed = 1.2f;
    public float rotateSpeed = 50.0f;
    private Animator anim;
    public float x, y;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * rotateSpeed, 0);
        transform.Translate(0, 0, y * Time.deltaTime * speed);

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);
       

    }
}
