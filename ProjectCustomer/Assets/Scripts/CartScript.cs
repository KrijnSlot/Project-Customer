using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartScript : MonoBehaviour
{

    float originalY;
    void Start()
    {
        originalY = transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, originalY, transform.position.z);
    }
}
