using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShowDialogue : MonoBehaviour
{
    [SerializeField] GameObject dialogueSystem;
    [SerializeField] FirstPersonCam fpc;

        float xSens;
        float ySens;

    private void Start()
    {
        dialogueSystem.SetActive(false);

        xSens = fpc.mouseSenseX;
        ySens = fpc.mouseSenseY;
    }
    private void FixedUpdate()
    {
        NPCCollision();
    }

    void NPCCollision()
    {
        if (NPCSript.colliding)
        {
            dialogueSystem.SetActive(true);

            PlayerLock();
        }
        else
        {
            dialogueSystem.SetActive(false);

            PlayerUnlock();
        }
    }

    void PlayerLock()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        fpc.move.enabled = false;
        fpc.mouseSenseX = 1;
        fpc.mouseSenseY = 1;
    }
    void PlayerUnlock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        fpc.move.enabled = true;
        fpc.mouseSenseX = xSens;
        fpc.mouseSenseY = ySens;
    }
}
