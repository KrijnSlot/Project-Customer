using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class Accel : MonoBehaviour
{
    [SerializeField] FirstPersonCam Cam;
    Rigidbody rb;

    [SerializeField] float thrust;
    [SerializeField] float Forwardthrust;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * Forwardthrust);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(transform.forward * -thrust);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, Input.GetAxis("Horizontal") * 0.5f, 0);
            Cam.camRotY += Input.GetAxis("Horizontal") * 0.5f;
            Cam.clamp += Input.GetAxis("Horizontal") * 0.5f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, Input.GetAxis("Horizontal") * 0.5f, 0);
            Cam.camRotY += Input.GetAxis("Horizontal") * 0.5f;
            Cam.clamp += Input.GetAxis("Horizontal") * 0.5f;
        }
    }

}
