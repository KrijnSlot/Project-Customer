using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionScript : MonoBehaviour
{
    [SerializeField] ShoppingList shopList;
    [SerializeField] string itemName;
    private void OnTriggerEnter(Collider other)
    {
        itemName = other.gameObject.name;
        Debug.Log(itemName + " " + "Check1");
        shopList.ItemCheck(itemName);
    }
}
Camera.