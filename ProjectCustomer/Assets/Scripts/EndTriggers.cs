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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (triggerNumb == 1 && shoplist.itemsDone == 0 && other.CompareTag("Player"))
        {
            shoplist.itemsDone = 1;
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
    }
}
