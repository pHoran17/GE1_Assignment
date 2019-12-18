using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWallCubes : MonoBehaviour
{
    public GameObject prefab;
    List<GameObject> cubes;
    public AudioHandler audioH;
    int frameSize = 512;
    public float radius = 10;
    public float scale = 20;
    // Start is called before the first frame update
    void Start()
    {
        CreateCircleOfCubes();
        //Debug.Log(cubes.Count);
    }
    void CreateCircleOfCubes()
    {
        cubes = new List<GameObject>();
        float theta = (Mathf.PI * 2.0f) / frameSize;
        for (int i = 0; i < frameSize; i++)
        {
            Vector3 pos = new Vector3(Mathf.Sin(theta * i) * radius, Mathf.Cos(theta * i) * radius,0 );
            pos = transform.TransformPoint(pos);
            Quaternion quat = Quaternion.AngleAxis(theta * i * Mathf.Rad2Deg, Vector3.forward);
            quat = transform.rotation * quat;

            GameObject c = (GameObject)Instantiate(prefab);
            c.transform.SetPositionAndRotation(pos, quat);
            c.transform.parent = this.transform;
            c.GetComponent<Renderer>().material.color = Color.HSVToRGB(i / frameSize, 1, 5);
            cubes.Add(c);
        }
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < cubes.Count; i++)
        {
            cubes[i].transform.localScale = new Vector3(transform.localScale.x, audioH.spectrum[i] * scale, audioH.spectrum[i] * scale);
            if (i > 256)
            {
                cubes[i].transform.localScale = new Vector3(transform.localScale.x, (audioH.spectrum[i] * scale) * 20, audioH.spectrum[i] * scale);
            }
            cubes[i].transform.parent.Rotate(0, 0, 5);
        }
    }
}
