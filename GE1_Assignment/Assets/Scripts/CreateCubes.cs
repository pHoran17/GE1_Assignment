using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCubes : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject[] cubeArray = new GameObject[512];
    public float maxScale;
    public AudioSpectrum audioSpect;
    public AudioHandler audioH;
    //public bool useBuffer;
    Material mat;
    //public int band;

    // Start is called before the first frame update
    void Start()
    {
        //Attempting to initialise material in start 
        //mat = GetComponent<Renderer>().material;
        for (int i = 0; i < 512; i++)
        {
            GameObject sampleCube = (GameObject)Instantiate(cubePrefab);
            sampleCube.transform.position = this.transform.position;
            sampleCube.transform.parent = this.transform;
            sampleCube.name = "SampleCube" + i;
            this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);//Y value comes from 360/512
            //sampleCube.GetComponent<Renderer>().material.color = Color.HSVToRGB(1, (i / ((float)audioSpect.audioBand.Length * maxScale)), 1);
            sampleCube.GetComponent<Renderer>().material.color = Color.HSVToRGB(1, (i / ((float)audioH.bands.Length * maxScale)), 1);
            sampleCube.transform.position = Vector3.forward * 100;
            cubeArray[i] = sampleCube;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 512; i++)
        {
            if (cubeArray != null)
            {
                cubeArray[i].transform.localScale = new Vector3(10, (audioH.spectrum[i] * maxScale) + 2, 10);
                //cubeArray[i].transform.localScale = new Vector3(10, (audioSpect.audSpec[i] * maxScale) + 2, 10);
                //cubeArray[i].GetComponent<Renderer>().material.color = Color.HSVToRGB(i / ((float)audioSpect.audSpec.Length * maxScale), 1, 1);
                //Color color = new Color(audioSpect.audioBandBuffer[band], audioSpect.audioBandBuffer[band], audioSpect.audioBandBuffer[band]);
                //mat.SetColor("_EmissionColor", color);
            }
        }
    }
}
