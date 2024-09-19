using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ShoppingList : MonoBehaviour
{
    public List<string> itemList = new List<string>();

    [SerializeField] TMP_Text text;
    [SerializeField] Image image;

    bool checkingList = false;
    private int itemsDone;
    private void Start()
    {
        itemList.Add("soup");
        itemList.Add("Item");

        itemsDone = itemList.Count;
        foreach (string item in itemList)
        {
            text.text += " ";
            text.text += item;
            text.text += " ";
        }
    }
    public void ItemCheck(string itemName)
    {
        Debug.Log(itemName + " " + "Check2");
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i] == itemName)
            {
                Debug.Log(itemList[i] + " " + "has been added");
                itemList[i] = itemName + "Done";
                itemsDone--;
            }
            if (itemList[i] == itemName + "Done")
            {
                Debug.Log(itemList[i]);
            }
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!checkingList)
            {
                text.enabled = true;
                image.enabled = true;
                checkingList = true;
            }
            else
            {
                text.enabled = false;
                image.enabled = false;
                checkingList = false;
            }
        }
        if (itemsDone == 0)
        {
            Debug.Log("List is done");
        }
    }
}
