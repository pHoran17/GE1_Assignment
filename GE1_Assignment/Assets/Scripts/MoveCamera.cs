using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    //Script for moving camera with keyboard + mouse or Xbox Controller

    public GameObject cam;
    public float speed = 40.0f;
    public bool allowPitch = true;
    // Start is called before the first frame update
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main.gameObject;
        }
    }
    void Yaw(float angle)
    {
        Quaternion r = Quaternion.AngleAxis(angle, Vector3.up);
        transform.rotation = r * transform.rotation;
    }
    void Pitch(float angle)
    {
        float invcosTheta1 = Vector3.Dot(transform.forward, Vector3.up);
        float threshold = 0.95f;
        if ((angle > 0 && invcosTheta1 < (-threshold)) || (angle < 0 && invcosTheta1 > (threshold)))
        {
            return;
        }
        Quaternion r = Quaternion.AngleAxis(angle, transform.right);

        transform.rotation = r * transform.rotation;
    }
    void Roll (float angle)
    {
        Quaternion r = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = r * transform.rotation;
    }
    void Walk(float units)
    {
        transform.position += cam.transform.forward * units;
    }
    void Fly(float units)
    {
        transform.position += Vector3.up * units;
    }

    void Strafe(float units)
    {
        transform.position += cam.transform.right * units;
    }

    // Update is called once per frame
    void Update()
    {
        float x, y;//Mouse inputs
        float speed = this.speed;

        float rAxis = 0;//Run Axis

        if (Input.GetKey(KeyCode.Escape) || Input.GetButton("Exit"))
        {
            Application.Quit();
        }
        if (Input.GetKey(KeyCode.E)|| Input.GetButton("FlyUp"))
        {
            Fly(Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.F)|| Input.GetButton("FlyDown"))
        {
            Fly(-Time.deltaTime * speed);
        }

        Vector3 v = new Vector3();
        v.x = 10;
        x = Input.GetAxis("LookX");
        y = Input.GetAxis("LookY");

        Yaw(x * speed * Time.deltaTime);
        if (allowPitch)
        {
            Pitch(-y * speed * Time.deltaTime);
        }
       
        float contWalk = Input.GetAxis("Vertical");
        float contStrafe = Input.GetAxis("Horizontal");
        Walk(contWalk * speed * Time.deltaTime);
        Strafe(contStrafe * speed * Time.deltaTime);
    }
}
