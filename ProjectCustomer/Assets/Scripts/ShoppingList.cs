using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.CodeDom.Compiler;


public class ShoppingList : MonoBehaviour
{
    public List<GameObject> itemListObj = new List<GameObject>();
    List<string> itemList = new List<string>();
    List<string> textList = new List<string>();

    [SerializeField] TMP_Text text;
    [SerializeField] Image image;

    bool checkingList = false;
    private int itemsDone;
    private void Start()
    {
        foreach (GameObject item in itemListObj)
        {
            itemList.Add(item.name);
        }

        itemsDone = itemList.Count;

        textList = new List<string>(itemList);
        foreach (string item in textList)
        {
            text.text += item;
            text.text += "\n";
        }
    }
    public void ItemCheck(string itemName)
    {
        Debug.Log(itemName + " " + "Check2");
        textList.Clear();
        text.text = "";
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i] == itemName)
            {
                Debug.Log(itemList[i] + " " + "has been added");
                itemList[i] = "<s>" + itemName + "</s>";
                itemsDone--;
            }
        }
        textList = new List<string>(itemList);
        foreach (string item in textList)
        {
            text.text += item;
            text.text += "\n";
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
