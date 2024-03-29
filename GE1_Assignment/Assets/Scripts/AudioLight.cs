﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class AudioLight : MonoBehaviour
{
    //Script for adjusting light insensity to music, not used
    public int band;
    public float minIntense, maxIntense;
    public Light changeLight;
    public AudioSpectrum aud;
    // Start is called before the first frame update
    void Start()
    {
        changeLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        changeLight.intensity = (aud.audioBandBuffer[band] * (maxIntense - minIntense) + minIntense);
    }
}
