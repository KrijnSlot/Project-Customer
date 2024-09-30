using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Accel : MonoBehaviour
{
    //[HideInInspector] public static bool inDialogue = false;

    [SerializeField] FirstPersonCam Cam;
    [SerializeField] GameObject Shoppingcart;
    [SerializeField] LayerMask Cart;
    [SerializeField] Transform holdPos;
    public bool onCart = true;
    bool cartRay;
    Rigidbody rb;

    [SerializeField] float NoCartThrust;
    [SerializeField] float CartThrust;

    [SerializeField] float Forwardthrust;

    Vector3 directionMoving;
    float horInput;
    float verInput;
    float yRot;

    float exitTime = 1;
    float exitTimer;
    bool exiting;

    [SerializeField] float invertTimer = 10;
    [SerializeField] bool moveInvert = false;
    float reverseTimer = 0;

    [SerializeField] TMP_Text cartHover;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Inputs()
    {
        if (!moveInvert)
        {
            horInput = Input.GetAxisRaw("Horizontal");
            verInput = Input.GetAxisRaw("Vertical");
        }
        else
        {
            horInput = -Input.GetAxisRaw("Horizontal");
            verInput = -Input.GetAxisRaw("Vertical");
        }
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        if (onCart)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (!moveInvert) rb.AddForce(gameObject.transform.forward * CartThrust);
                else rb.AddForce(gameObject.transform.forward * -CartThrust);
            }
            if (Input.GetKey(KeyCode.S))
            {
                if (!moveInvert) rb.AddForce(gameObject.transform.forward * -CartThrust);
                else rb.AddForce(gameObject.transform.forward * CartThrust);
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
            if (Input.GetKey(KeyCode.L))
            {
                Insanity.insanity += 25;
            }
        }
        else
        {
            directionMoving = (gameObject.transform.forward * verInput + gameObject.transform.right * horInput).normalized;

            rb.AddForce(directionMoving * NoCartThrust * 10f, ForceMode.Force);
            yRot = Cam.camRotY;

            if (Input.GetKey(KeyCode.L))
            {
                Insanity.insanity += 25;
            }
        }

        if (reverseTimer > 0)
        {
            reverseTimer -= Time.deltaTime;
        }
        else if (invertTimer < 0)
        {
            invertTimer = UnityEngine.Random.Range(10, 20);
            moveInvert = false;
        }
        if (invertTimer > 0 && Insanity.insanity > 75)
        {
            invertTimer -= Time.deltaTime;
        }

    }

    public void Update()
    {
        Inputs();

        UseCart();

        if (onCart)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, yRot, 0);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, yRot, 0);
        }

        if (!moveInvert && Insanity.insanity > 75 && invertTimer <= 0)
        {
            /*int random = UnityEngine.Random.Range(0, 2);
            if(random == 1)
            {
                invertTimer = 5;
            }
            else*/
            {
                moveInvert = true;
                reverseTimer = UnityEngine.Random.Range(2, 5);
            }
        }
    }

    void UseCart()
    {
        if (exitTimer > 0) exitTimer -= Time.deltaTime;
        else exiting = false;

        cartRay = Physics.Raycast(Cam.transform.position, Cam.transform.forward, 3f, Cart);
        if (cartRay && !onCart)
        {
            cartHover.enabled = true;
        } else cartHover.enabled = false;

            if (Input.GetKeyUp(KeyCode.F))
        {
            if (cartRay && !onCart)
            {
                cartHover.enabled = false;
                Shoppingcart.transform.SetParent(gameObject.transform);
                Shoppingcart.transform.position = holdPos.position;
                Shoppingcart.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, Cam.camRotY, gameObject.transform.rotation.z);
                gameObject.transform.rotation = Quaternion.Euler(0, Cam.camRotY, 0);
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
