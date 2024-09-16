using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShoppingList : MonoBehaviour
{
    public List<string> itemList = new List<string>();

    private int indexCheck = 1;
    private void Start()
    {
        itemList.Add("soup");
        itemList.Add("Item");
    }
    public void ItemCheck(string itemName)
    {
        Debug.Log(itemName + " " + "Check2");
        for(int i=0; i < itemList.Count; i++)
        {
            if (itemList[i] == itemName)
            {
                Debug.Log(itemList[i] + " " + "has been added");
                itemList[i] = itemName + "Done";
            }
            if (itemList[i] == itemName + "Done")
            {
                Debug.Log(itemList[i]);
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
