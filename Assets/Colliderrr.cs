﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliderrr : MonoBehaviour
{
    public AudioSource AudioSource;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (AudioSource.isPlaying == false)
        {
            AudioSource.Play();
        }
    }
}
