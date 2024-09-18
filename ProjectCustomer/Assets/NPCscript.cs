using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCscript : MonoBehaviour
{
    [SerializeField] GameObject Player;
    public Transform holdPos;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(Player.transform);
    }
}
