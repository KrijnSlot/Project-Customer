using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "soup")
        {
            Debug.Log("soup");
        }
        if (other.gameObject.name == "Item")
        {
            Debug.Log("Item");
        }
    }
}
