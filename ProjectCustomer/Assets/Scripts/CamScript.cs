using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCam : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform playerOrien;
    [SerializeField] Accel move;
    [SerializeField] float mouseSenseX = 2f;
    [SerializeField] float mouseSenseY = 2f;
    public float camRotY = 0f;
    float camRotX = 0f;
    float lookRange = 10f;
    bool onPlayer = true;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSenseX * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSenseY * Time.deltaTime;

        camRotY += mouseX;
        camRotX -= mouseY;
        camRotX = Mathf.Clamp(camRotX, -90f, 90);
        if (!move.onCart && onPlayer)
            playerOrien.rotation = Quaternion.Euler(0, camRotY, 0);
        else if (!onPlayer) playerOrien.rotation = playerOrien.rotation;
        transform.rotation = Quaternion.Euler(camRotX, camRotY, 0);


        if (Input.GetKeyDown(KeyCode.Q) && !onPlayer)
        {
            move.enabled = true;
            onPlayer = true;
            gameObject.transform.SetParent(playerOrien);
            gameObject.transform.position = new Vector3(playerOrien.position.x, gameObject.transform.position.y, playerOrien.position.z);
            camRotY = playerOrien.rotation.eulerAngles.y;
            camRotX = playerOrien.rotation.eulerAngles.x;
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
                    gameObject.transform.SetParent(hit.transform.gameObject.transform);
                    /*diff = new Vector3(gameObject.transform.position.x - hit.transform.gameObject.transform.position.x , gameObject.transform.position.y, gameObject.transform.position.z - hit.transform.gameObject.transform.position.z);*/
                    gameObject.transform.position = new Vector3(hit.transform.gameObject.transform.position.x, gameObject.transform.position.y, hit.transform.gameObject.transform.position.z);
                    camRotY = hit.transform.gameObject.transform.rotation.eulerAngles.y;
                    camRotX = hit.transform.gameObject.transform.rotation.eulerAngles.x;

                    Debug.Log("Check");
                    //pass in object hit into the PickUpObject function
                }
            }
        }
    }
}
