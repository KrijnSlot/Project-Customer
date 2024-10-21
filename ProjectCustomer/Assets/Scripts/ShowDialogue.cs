using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShowDialogue : MonoBehaviour
{
    /*[SerializeField] GameObject dialogueSystem;
    [SerializeField] FirstPersonCam fpc;
    public NPCSript npcscript;

    float xSens;
    float ySens;

    private void Start()
    {
        //dialogueSystem.SetActive(false);

        xSens = fpc.mouseSenseX;
        ySens = fpc.mouseSenseY;
    }
    private void FixedUpdate()
    {
*//*        NPCCollision();*//*
    }

    void NPCCollision()
    {
        if (npcscript.colliding)
        {
            Debug.Log("locked");
            //dialogueSystem.SetActive(true);

            PlayerLock();
        }
        else
        {
            Debug.Log("unlocked");
            //dialogueSystem.SetActive(false);

            PlayerUnlock();
            NotColliding();
        }
    }

    public void NotColliding()
    {
        print("NotCol");
        npcscript.colliding = false;
        Invoke("WaitOff", 20f);
    }

    void WaitOff()
    {
        //Debug.Log("wait");
        print("waitOff");

    }

    public void PlayerLock()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        fpc.move.enabled = false;
        fpc.mouseSenseX = 1;
        fpc.mouseSenseY = 1;

    }
    public void PlayerUnlock()
    {
        print("PlayerUnlock");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        fpc.move.enabled = true;
        fpc.mouseSenseX = xSens;
        fpc.mouseSenseY = ySens;
    }*/
}
