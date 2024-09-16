using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShoppingList : MonoBehaviour
{
    List<string> itemList = new List<string>();
    private void Start()
    {
        itemList.Add("soup");
        itemList.Add("Item");
    }
    public void ItemCheck(string itemName)
    {
        Debug.Log(itemName + " " + "Check2");
        foreach (var item in itemList)
        {
            if (item == itemName)
            {
                Debug.Log(item + " " + "has been added");
                itemList.Remove(item);
            }
        }
    }
    void Update()
    {
        if(itemList.Count == 0)
        {
            Debug.Log("List is done");
        }
    }
}
