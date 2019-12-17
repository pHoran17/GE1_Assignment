using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTower : MonoBehaviour
{
    int band = 3;
    public float startScale, scaleMultiplier;
    public AudioHandler audioH;
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
            transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y , audioH.bandBuffer[band] * startScale);
        }
        if (!useBuffer)
        {

            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, audioH.spectrum[band] * startScale);
            //transform.localScale = new Vector3(transform.localScale.x, (audioSpect.audSpec[band]) * startScale, transform.localScale.z);
            //Color color = new Color(audioSpect.audioBand[band], audioSpect.audioBand[band], audioSpect.audioBand[band]);
            //mat.SetColor("_EmissionColor", color);
        }
    }
}
