using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOnAmplitude : MonoBehaviour
{
    public float startScale, maxScale;
    public bool useBuffer;
    public float r, g, b;
    public AudioSpectrum aud;
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Material>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (!useBuffer)
        {
            transform.localScale = new Vector3((aud.amplitude * maxScale) + startScale, (aud.amplitude * maxScale) + startScale, (aud.amplitude * maxScale) + startScale);
            Color col = new Color(r * aud.amplitude, g * aud.amplitude, b * aud.amplitude);
            mat.SetColor("_EmissionColor", col);
        }
        if (useBuffer)
        {
            transform.localScale = new Vector3((aud.amplitudeBuffer * maxScale) + startScale, (aud.amplitudeBuffer * maxScale) + startScale, (aud.amplitudeBuffer * maxScale) + startScale);
            Color col = new Color(r * aud.amplitudeBuffer, g * aud.amplitudeBuffer, b * aud.amplitudeBuffer);
            mat.SetColor("_EmissionColor", col);
        }
    }
}
