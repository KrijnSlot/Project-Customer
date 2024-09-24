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

    [SerializeField]
    List<Vector3> CubePosition = new List<Vector3>();

    [SerializeField]
    List<Vector3> NewCubePosition = new List<Vector3>();

    [SerializeField]
    float canSwitch = 0;

    private void Awake()
    {
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
                shelfList.Add(row[i].gameObject.transform.GetChild(j).gameObject);
            }
        }

    }
    private void FixedUpdate()
    {
        canSwitch -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Insanity.insanity > 25 && canSwitch <0)
        {
            shelfList.Clear();
            for (int i = 0; i < row.Count; i++)
            {
                for (int j = 0; j < row[i].gameObject.transform.childCount; j++)
                {
                    print(row[i].gameObject.transform.GetChild(j).name);
                    if (dontSwitch.Contains(row[i])) continue;
                    shelfList.Add(row[i].gameObject.transform.GetChild(j).gameObject);
                }

            }
            for (int i = 0; i < shelfList.Count; i++)
            {
                int rnd = Random.Range(0, shelfList.Count - 1);
                if (dontSwitch.Contains(shelfList[i])) continue;
                int maxLoop = 0;
                while (dontSwitch.Contains(shelfList[rnd]) && maxLoop < 20)
                {
                    rnd = Random.Range(0, shelfList.Count - 1);
                    maxLoop++;
                }

                Vector3 shelfPos = new Vector3(shelfList[i].transform.position.x, shelfList[rnd].transform.position.y, shelfList[i].transform.position.z);
                Quaternion shelfRot = shelfList[i].transform.rotation;

                shelfList[i].transform.position = new Vector3(shelfList[rnd].transform.position.x, shelfList[i].transform.position.y, shelfList[rnd].transform.position.z);
                shelfList[rnd].transform.position = shelfPos;

                shelfList[i].transform.rotation = shelfList[rnd].transform.rotation;
                shelfList[rnd].transform.rotation = shelfRot;
            }
            canSwitch = Random.Range(25,50);
            if(Insanity.insanity > 75) canSwitch = Random.Range(10,20);
        }

    }
}
