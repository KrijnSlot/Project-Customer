using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShelfSwitchScript : MonoBehaviour
{
    [SerializeField]
    List<GameObject> dontSwitch = new List<GameObject>();

    [SerializeField]
    List<GameObject> shelfList = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < shelfList.Count; i++)
        {
            int rnd = Random.Range(0, shelfList.Count - 1);

            if (dontSwitch.Contains(shelfList[i])) continue;

            Vector3 shelfPos = shelfList[i].transform.position;
            Quaternion shelfRot = shelfList[i].transform.rotation;

            shelfList[i].transform.position = shelfList[rnd].transform.position;
            shelfList[rnd].transform.position = shelfPos;

            shelfList[i].transform.rotation = shelfList[rnd].transform.rotation;
            shelfList[rnd].transform.rotation = shelfRot;
        }
    }
}
