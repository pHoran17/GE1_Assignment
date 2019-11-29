using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCubes : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject[] cubeArray = new GameObject[512];
    public float maxScale;
    public AudioSpectrum audioSpect;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 512; i++)
        {
            GameObject sampleCube = (GameObject)Instantiate(cubePrefab);
            sampleCube.transform.position = this.transform.position;
            sampleCube.transform.parent = this.transform;
            sampleCube.name = "SampleCube" + i;
            this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);//Y value comes from 360/512
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
                cubeArray[i].transform.localScale = new Vector3(10, (audioSpect.audSpec[i] * maxScale) + 2, 10);
            }
        }
    }
}
