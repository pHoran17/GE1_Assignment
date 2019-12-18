using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialColor : MonoBehaviour
{ 
    public AudioSpectrum aud;
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        mat.EnableKeyword("_EMISSION");
        Color newCol = new Color(1, Random.value, 1);
        mat.SetColor("_EmissionColor", newCol);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
