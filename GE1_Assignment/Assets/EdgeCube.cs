using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeCube : MonoBehaviour
{
    public int band;
    public float startScale, scaleMultiplier;
    public AudioSpectrum audioSpect;
    public bool useBuffer;
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().materials[0];
        mat.EnableKeyword("_EMISSION");
        Color color = new Color(audioSpect.audioBandBuffer[band], audioSpect.audioBandBuffer[band], audioSpect.audioBandBuffer[band]);
        mat.SetColor("_EmissionColor", color);
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
            //Color color = new Color(audioSpect.audioBand[band], audioSpect.audioBand[band], audioSpect.audioBand[band]);
            //mat.SetColor("_EmissionColor", color);
        }
    }
}
