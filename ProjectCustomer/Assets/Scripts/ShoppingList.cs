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
    [SerializeField] TMP_Text gibberish;
    [SerializeField] Image image;

    [SerializeField] int gibberishCount;

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

            gibberish.text += item;
            gibberish.text += "\n";
        }
    }
    public void ItemCheck(string itemName)
    {
        Debug.Log(itemName + " " + "Check2");
        textList.Clear();
        text.text = "";
        gibberish.text = "";

        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i] == itemName)
            {
                Debug.Log(itemList[i] + " " + "has been added");
                itemList[i] = "<s>" + itemName + "</s>";
                itemsDone--;
                break;
            }
        }

        textList = new List<string>(itemList);

        foreach (string item in textList)
        {
            text.text += item;
            text.text += "\n";

            gibberish.text += item;
            gibberish.text += "\n";
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!checkingList)
            {
                gibberish.enabled = true;
                text.enabled = true;
                image.enabled = true;
                checkingList = true;
            }
            else
            {
                gibberish.enabled = false;
                text.enabled = false;
                image.enabled = false;
                checkingList = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            List<int> list = new List<int>();

            while (list.Count < gibberishCount)
            {
                int gib = Random.Range(0, textList.Count);
                list.Add(gib);
            }

            gibberish.text = "";

            for (int i = 0; i < textList.Count; i++)
            {
                if (list.Contains(i))
                {
                    gibberish.text += "dskjd";
                    gibberish.text += "\n";
                }
                else
                {
                    gibberish.text += textList[i];
                    gibberish.text += "\n";
                }
            }
        }

        if (itemsDone == 0)
        {
            Debug.Log("List is done");
        }
    }
}
