using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeCube : MonoBehaviour
{
    public int band;
    public float startScale, scaleMultiplier;
    public AudioSpectrum audioSpect;
    public bool useBuffer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (audioSpect.bandBuffer[band]) * startScale, transform.localScale.z);
        }
        if (!useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (audioSpect.audSpec[band]) * startScale, transform.localScale.z);
        }
    }
}
