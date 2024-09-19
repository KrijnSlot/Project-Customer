using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FirstPersonCam : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform playerOrien;
    [SerializeField] Accel move;
    [SerializeField] float mouseSenseX = 2f;
    [SerializeField] float mouseSenseY = 2f;
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

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    private void Update()
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
        /*else if (!onPlayer && !rotating) playerOrien.LookAt(NPC.transform);*/

        transform.rotation = Quaternion.Euler(camRotX, camRotY, 0);


        if (Input.GetKeyDown(KeyCode.Q) && !onPlayer)
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

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, lookRange))
        {
            //make sure pickup tag is attached
            if (hit.transform.gameObject.tag == "NPC")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    move.enabled = false;
                    onPlayer = false;

                    Vector3 diff = new Vector3((hit.transform.gameObject.transform.position.x + gameObject.transform.position.x) / 2, gameObject.transform.position.y, (hit.transform.gameObject.transform.position.z + gameObject.transform.position.z) / 2);
                    inBetweenPoint.position = diff;

                    gameObject.transform.SetParent(inBetweenPoint);
                    targetRotation = Quaternion.Euler(0, 180, 0);

                    rotationTime = 0;
                    NPC = hit.transform.gameObject;

                    rotating = true;
                }
            }
        }
        if (rotating)
        {
            gameObject.transform.LookAt(inBetweenPoint);
            rotationTime += Time.deltaTime /2;
            inBetweenPoint.rotation = Quaternion.Lerp(inBetweenPoint.rotation, targetRotation, rotationTime);
            print(inBetweenPoint.rotation.eulerAngles.y);
            print(targetRotation.eulerAngles.y);
        }
        if (rotationTime > 0.5 && rotating)
        {
            rotating = false;
            gameObject.transform.SetParent(null);
            playerOrien.LookAt(NPC.transform);
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
