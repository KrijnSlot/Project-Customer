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

            Vector3 shelfPos = new Vector3(shelfList[i].transform.position.x, shelfList[rnd].transform.position.y, shelfList[i].transform.position.z);
            Quaternion shelfRot = shelfList[i].transform.rotation;

            shelfList[i].transform.position = new Vector3(shelfList[rnd].transform.position.x, shelfList[i].transform.position.y, shelfList[rnd].transform.position.z);
            shelfList[rnd].transform.position = shelfPos;

            shelfList[i].transform.rotation = shelfList[rnd].transform.rotation;
            shelfList[rnd].transform.rotation = shelfRot;
        }
    }
}
