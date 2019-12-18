using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlatterColor : MonoBehaviour
{
    // Start is called before the first frame update
    private Material mat;
    public AudioSpectrum aud;
    private float intensity;
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        intensity =  (float)aud.audSpec.Length / 12;
        Color newCol = new Color(Random.value, Random.value, Random.value);//Alter to change color with data from aud
        newCol *= intensity;
        mat.color= newCol; //Needs work
        //mat.SetColor("_EmissionColor", newCol);
    }
}
