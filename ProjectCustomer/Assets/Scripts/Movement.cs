using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class Accel : MonoBehaviour
{
    [SerializeField] FirstPersonCam Cam;
    [SerializeField] GameObject Shoppingcart;
    [SerializeField] Transform Player;
    [SerializeField] LayerMask Cart;
    bool onCart = true;
    bool cartRay;
    Rigidbody rb;

    [SerializeField] float thrust;
    [SerializeField] float Forwardthrust;

    Vector3 directionMoving;
    float horInput;
    float verInput;

    float exitTime = 1;
    float exitTimer;
    bool exiting;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Inputs()
    {
        horInput = Input.GetAxisRaw("Horizontal");
        verInput = Input.GetAxisRaw("Vertical");
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        if (onCart)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(transform.forward * thrust);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(transform.forward * -thrust);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, horInput * 0.5f, 0);
                Cam.camRotY += horInput * 0.5f;
                Cam.clamp += horInput * 0.5f;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, horInput * 0.5f, 0);
                Cam.camRotY += horInput * 0.5f;
                Cam.clamp += horInput * 0.5f;
            }
        }
        else
        {
            directionMoving = (Player.forward * verInput + Player.right * horInput).normalized;

            rb.AddForce(directionMoving * thrust * 10f, ForceMode.Force);
        }
    }
    public void Update()
    {
        Inputs();
        if(exitTimer > 0)
        {
            exitTimer -= Time.deltaTime;
        }
        else
        {
            exiting = false;
        }
        cartRay = Physics.Raycast(Cam.transform.position, Cam.transform.forward, 10f, Cart);
        if (Input.GetKeyUp(KeyCode.F))
        {
            if (cartRay && !onCart)
            {
                Shoppingcart.transform.SetParent(Player);
                Shoppingcart.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
                onCart = true;
                exitTimer = exitTime;
                exiting = true;
            }
            if (onCart && !exiting)
            {
                Shoppingcart.transform.SetParent(null);
                onCart = false;
            }
        }
    }

}
