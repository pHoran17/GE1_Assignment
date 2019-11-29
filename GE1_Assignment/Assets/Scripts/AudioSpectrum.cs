using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class AudioSpectrum : MonoBehaviour
{
    public float[] audSpec = new float[512];
    AudioSource aSource;
    //public static float specValue { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        //audSpec = new float[512];
        aSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //AudioListener.GetSpectrumData();
        /*if (audSpec != null && audSpec.Length > 0)
        {
            specValue = audSpec[0] * 100;//100 used to normalize spectrum data
        }
        */
        getSpectrumAudioSource();
    }
    void getSpectrumAudioSource()
    {
        aSource.GetSpectrumData(audSpec, 0, FFTWindow.Blackman);
    }
}
