using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Accel : MonoBehaviour
{
    [SerializeField] FirstPersonCam Cam;
    [SerializeField] GameObject Shoppingcart;
    [SerializeField] Transform Player;
    [SerializeField] LayerMask Cart;
    [SerializeField] Transform holdPos;
    [SerializeField] float rotate;
    [SerializeField] float rotate2;
    public bool onCart = true;
    bool cartRay;
    Rigidbody rb;

    [SerializeField] float thrust;
    [SerializeField] float Forwardthrust;

    Vector3 directionMoving;
    float horInput;
    float verInput;
    float yRot;

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
                rb.AddForce(Player.forward * thrust);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(Player.forward * -thrust);
            }
            if (Input.GetKey(KeyCode.A))
            {
                yRot += horInput * 0.5f;
                Cam.camRotY += horInput * 0.5f;
            }
            if (Input.GetKey(KeyCode.D))
            {
                yRot += horInput * 0.5f;
                Cam.camRotY += horInput * 0.5f;
            }
        }
        else
        {
            directionMoving = (Player.forward * verInput + Player.right * horInput).normalized;

            rb.AddForce(directionMoving * thrust * 10f, ForceMode.Force);
            yRot = Cam.camRotY;
        }
    }
    public void Update()
    {
        Inputs();
        rotate = Player.rotation.eulerAngles.y;
        rotate2 = yRot;
        if (exitTimer > 0)
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
                Shoppingcart.transform.position = holdPos.position;
                Shoppingcart.transform.rotation = Quaternion.Euler(Player.rotation.x, Cam.camRotY, Player.rotation.z);
                Player.rotation = Quaternion.Euler(0, Cam.camRotY, 0);
                Cam.clamp = Cam.camRotY - 90;
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
        if (onCart)
        {
            Player.transform.rotation = Quaternion.Euler(0, yRot, 0);
            Cam.clamp = Player.rotation.eulerAngles.y - 90;
        }
        else
        {
            Player.transform.rotation = Quaternion.Euler(0, yRot, 0);
        }
    }

}
