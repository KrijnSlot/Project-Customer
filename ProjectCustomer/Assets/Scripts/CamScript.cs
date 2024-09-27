using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FirstPersonCam : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform playerOrien;
    [SerializeField] public Accel move;
    [SerializeField] public float mouseSenseX = 2f;
    [SerializeField] public float mouseSenseY = 2f;
    [SerializeField] Transform camHolder1;
    [SerializeField] Transform camHolder2;
    [SerializeField] Transform inBetweenPoint;
    public float camRotY = 0f;
    Quaternion targetRotation;
    float camRotX = 0f;
    float lookRange = 10f;
    bool onPlayer = true;
    GameObject NPC;
    [SerializeField] bool rotating = false;
    [SerializeField] float rotationTime;
    public Transform otherCol;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    private void Update()
    {
        BasicCamFunctions();

        CamSwitchCheck();

        Rotating();

    }

    void BasicCamFunctions()
    {
        if (onPlayer && !rotating) transform.position = camHolder1.position;
        if (!onPlayer && !rotating) transform.position = camHolder2.position;

        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSenseX * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSenseY * Time.deltaTime;

        camRotY += mouseX;
        camRotX -= mouseY;
        camRotX = Mathf.Clamp(camRotX, -90f, 90);

        if (!move.onCart && onPlayer && !rotating)
            playerOrien.rotation = Quaternion.Euler(0, camRotY, 0);

        transform.rotation = Quaternion.Euler(camRotX, camRotY, 0);
    }

    void CamSwitchCheck()
    {
        if (!NPCSript.colliding && !onPlayer)
        {
            move.enabled = true;
            onPlayer = true;

            Vector3 diff = new Vector3((gameObject.transform.position.x + playerOrien.transform.position.x) / 2, gameObject.transform.position.y, (gameObject.transform.position.z + playerOrien.transform.position.z) / 2);
            inBetweenPoint.position = diff;

            gameObject.transform.SetParent(inBetweenPoint);
            targetRotation = Quaternion.Euler(0, 0, 0);

            rotationTime = 0;
            rotating = true;
        }


        if (NPCSript.colliding && onPlayer)
        {
            camHolder2 = otherCol.GetChild(0);
            otherCol = otherCol.GetChild(1);
            move.enabled = false;
            onPlayer = false;

            Vector3 diff = new Vector3((otherCol.gameObject.transform.position.x + gameObject.transform.position.x) / 2, gameObject.transform.position.y, (otherCol.gameObject.transform.position.z + gameObject.transform.position.z) / 2);
            inBetweenPoint.position = diff;

            gameObject.transform.SetParent(inBetweenPoint);
            targetRotation = Quaternion.Euler(0, 180, 0);

            rotationTime = 0;
            NPC = otherCol.gameObject;

            rotating = true;
        }
        if(NPCSript.colliding && !onPlayer)
        {
            playerOrien.LookAt(NPC.transform.parent);
        }
}

void Rotating()
{
    if (rotating)
    {
        gameObject.transform.LookAt(inBetweenPoint);
        rotationTime += Time.deltaTime;
        inBetweenPoint.rotation = Quaternion.Lerp(inBetweenPoint.rotation, targetRotation, rotationTime * 0.5f);
        print(inBetweenPoint.rotation.eulerAngles.y);
        print(targetRotation.eulerAngles.y);
    }
    if (rotationTime > 1 && rotating)
    {
        rotating = false;
        gameObject.transform.SetParent(null);
        playerOrien.LookAt(NPC.transform.parent);
        if (onPlayer)
        {
            camRotY = playerOrien.rotation.y;
            camRotX = playerOrien.rotation.x;
        }
        else
        {
            camRotY = NPC.transform.rotation.eulerAngles.y;
            camRotX = NPC.transform.rotation.eulerAngles.x;
        }
    }
}
}
