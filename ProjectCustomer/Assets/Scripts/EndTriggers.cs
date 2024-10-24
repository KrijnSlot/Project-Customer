using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class EndTriggers : MonoBehaviour
{
    [SerializeField] int triggerNumb;
    [SerializeField] UI ui;
    [SerializeField] ShelfSwitchScript script;
    [SerializeField] ShoppingList shoplist;

    [SerializeField]
    List<GameObject> shelfsToDelete = new List<GameObject>();

    public static int triggersPassed = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (triggerNumb == 1 && shoplist.itemsDone == 0 && other.CompareTag("Player"))
        {
            ui.SetDialogue(1,true);
            shoplist.itemsDone = 1;
            triggersPassed = 1;
            shoplist.itemList.Add("Cereal");
            shoplist.text.text += "Cereal";
            shoplist.text.text += "\n";
            script.Switch();
            for (int i = 0; i < shelfsToDelete.Count;)
            {
                Destroy(shelfsToDelete[i]);
                shelfsToDelete.Remove(shelfsToDelete[i]);
            }
            triggerNumb = 0;
        }
        if (triggerNumb == 2 && triggersPassed == 1 && other.CompareTag("Player"))
        {
            triggerNumb = 0;
            triggersPassed = 2;
            ui.SetDialogue(2,false);
        }
    }
}
