using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSurface : MonoBehaviour
{
    public GameObject gObject;
    float highestFreqVal;
    public AudioSpectrum audioSpec;
    // Start is called before the first frame update
    void Start()
    {

    }
    void ColorChanger()
    {
        //gObject.GetComponent<Renderer>().material.color = Color.Lerp()
    }
    // Update is called once per frame
    void Update()
    {
        //Surface rotates on y axis only
        transform.Rotate(0, 10, 0);
        ColorChanger();
        //gObject.GetComponent<Renderer>().material.color = Color.HSVToRGB((float)audioSpec.audSpec.Length, 1, 1);
        //highestFreqVal = 0;
    }
}
