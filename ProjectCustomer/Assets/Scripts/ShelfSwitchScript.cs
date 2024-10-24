using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ShelfSwitchScript : MonoBehaviour
{
    [SerializeField]
    List<GameObject> dontSwitch = new List<GameObject>();

    [SerializeField]
    List<GameObject> row = new List<GameObject>();

    [SerializeField]
    List<GameObject> shelfList = new List<GameObject>();

    List<GameObject> listOfShelves = new List<GameObject>();

    [SerializeField]
    List<Vector3> CubePosition = new List<Vector3>();

    [SerializeField]
    List<Vector3> NewCubePosition = new List<Vector3>();

    public int Treshhold = 35;

    Triggermanager trigger;
    [SerializeField] private AudioSource shelfSound;




    private void Awake()
    {
        trigger = GetComponentInParent<Triggermanager>();
        for (int i = 0; i < shelfList.Count; i++)
        {
            CubePosition.Add(shelfList[i].transform.position);
            NewCubePosition.Add(shelfList[i].transform.position);
        }
        for (int i = 0; i < row.Count; i++)
        {
            for (int j = 0; j < row[i].gameObject.transform.childCount; j++)
            {
                print(row[i].gameObject.transform.GetChild(j).name);
                if (dontSwitch.Contains(row[i])) continue;
                listOfShelves.Add(row[i].gameObject.transform.GetChild(j).gameObject);
            }
        }
        for(int i = 0; i < shelfList.Count; i++)
        {
            listOfShelves.Add(shelfList[i]);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Switch();

    }

    public void Switch()
    {
        if (UI.insanity > Treshhold && trigger.canSwitch < 0)
        {
            listOfShelves.Clear();
            for (int i = 0; i < row.Count; i++)
            {
                for (int j = 0; j < row[i].gameObject.transform.childCount; j++)
                {
                    print(row[i].gameObject.transform.GetChild(j).name);
                    if (dontSwitch.Contains(row[i])) continue;
                    listOfShelves.Add(row[i].gameObject.transform.GetChild(j).gameObject);
                }

            }
            for (int i = 0; i < shelfList.Count; i++)
            {
                listOfShelves.Add(shelfList[i]);
            }
            for (int i = 0; i < listOfShelves.Count; i++)
            {
                int rnd = Random.Range(0, listOfShelves.Count - 1);
                if (dontSwitch.Contains(listOfShelves[i])) continue;
                int maxLoop = 0;
                while (dontSwitch.Contains(listOfShelves[rnd]) && maxLoop < 20)
                {
                    rnd = Random.Range(0, listOfShelves.Count - 1);
                    maxLoop++;
                }

                Vector3 shelfPos = new Vector3(listOfShelves[i].transform.position.x, listOfShelves[rnd].transform.position.y, listOfShelves[i].transform.position.z);
                Quaternion shelfRot = listOfShelves[i].transform.rotation;

                listOfShelves[i].transform.position = new Vector3(listOfShelves[rnd].transform.position.x, listOfShelves[i].transform.position.y, listOfShelves[rnd].transform.position.z);
                listOfShelves[rnd].transform.position = shelfPos;

                listOfShelves[i].transform.rotation = listOfShelves[rnd].transform.rotation;
                listOfShelves[rnd].transform.rotation = shelfRot;
                shelfSound.Play();
            }
            trigger.canSwitch = Random.Range(25, 50);
            if (UI.insanity > 75) trigger.canSwitch = Random.Range(10, 20);
        }
    }
}
