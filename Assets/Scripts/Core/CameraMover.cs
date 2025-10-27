using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    Transform cam;

    float speed;

    // Start is called before the first frame update
    void Start()
    {
        cam = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 30.0f;
        }
        else
        {
            speed = 10.0f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += Vector3.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += Vector3.left * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position += Vector3.back * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += Vector3.right * Time.deltaTime * speed;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            this.transform.position += Vector3.up * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.E))
        {
            this.transform.position += Vector3.down * Time.deltaTime * speed;
        }
    }
}
