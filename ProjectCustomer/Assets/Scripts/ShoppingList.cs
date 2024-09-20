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

    [SerializeField] TMP_FontAsset gibFont;

    [SerializeField] TMP_Text text;
    [SerializeField] TMP_Text gibberish;
    [SerializeField] Image image;

    [SerializeField] int gibberishCount;

    [SerializeField] Image crosshair;

    [SerializeField] float Check;

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
                crosshair.enabled = false;
            }
            else
            {
                gibberish.enabled = false;
                text.enabled = false;
                image.enabled = false;
                checkingList = false;
                crosshair.enabled = true;
            }
        }
        Check -= Time.deltaTime;
        if (Check <= 0)
        {
            if (Insanity.insanity > 25)
            {
                int insanityCheck = 0;
                int insanityCheck2 = 0;
                if (Insanity.insanity > 25 && Insanity.insanity < 75)
                {
                    gibberishCount = 1;
                    insanityCheck = Random.Range(0, 11);
                }
                else if (Insanity.insanity > 75)
                {
                    gibberishCount = 2;
                    insanityCheck2 = Random.Range(0, 11);
                }
                if (insanityCheck == 10 || insanityCheck2 == 10)
                {
                    print("text");
                    List<int> list = new List<int>();
                    gibberish.font = gibFont;
                    int gib;
                    while (list.Count < gibberishCount)
                    {
                        gib = Random.Range(0, textList.Count);
                        list.Add(gib);
                    }
                    text.text = "";
                    for (int i = 0; i < itemList.Count; i++)
                    {
                        if (list.Contains(i))
                        {
                            Debug.Log(itemList[i] + " " + "has been added");
                            text.text += "";
                            text.text += "\n";
                        }
                        else
                        {
                            text.text += itemList[i];
                            text.text += "\n";
                        }
                    }

                    gibberish.text = "";

                    for (int i = 0; i < textList.Count; i++)
                    {
                        if (list.Contains(i))
                        {
                            gibberish.text += textList[i];
                            gibberish.text += "\n";
                        }
                        else
                        {
                            gibberish.text += "";
                            gibberish.text += "\n";
                        }
                    }
                    Check = Random.Range(10,25);
                }
            }

        }

        if (itemsDone == 0)
        {
            Debug.Log("List is done");
        }
    }
}
