using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCeilingCubes : MonoBehaviour
{
    //Script for creating ceiling cubes in scene
    List<GameObject> objects;
    public GameObject prefab;
    public AudioHandler audioH;
    public float startScale;
    public bool useBuffer;
    float specLength;
    int band = 4;
    int height = 25;
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        objects = new List<GameObject>();
        specLength = audioH.spectrum.Length;
        //Create array of shapes here
        for(int i = -21; i < 21; i++)
        {
            for (int j = -12; j < 12; j++)
            {
                Vector3 pos = new Vector3(i,height,j) * 10;
                pos = transform.TransformPoint(pos);
                GameObject go = GameObject.Instantiate<GameObject>(prefab, pos, Quaternion.identity);
                go.transform.parent = this.transform;
                go.GetComponent<Renderer>().material.color = Color.HSVToRGB(Random.value, 1, 5);
                objects.Add(go);
                
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Update transforms here
         index = 0;
        if (useBuffer)
        {
            foreach (GameObject g in objects)
            {
                g.transform.localScale = new Vector3(transform.localScale.x, audioH.bandBuffer[band] * startScale, transform.localScale.z);
                index++;
            }
        }
        if(!useBuffer)
        {
            foreach (GameObject g in objects)
            {
                g.transform.localScale = new Vector3(transform.localScale.x, audioH.spectrum[band] * startScale, transform.localScale.z);
                index++;
            }
        }
         
    }
}
