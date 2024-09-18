/*using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class camSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public float lookRange = 10f;
    public bool onPlayer = true;
    [SerializeField] Transform player;
    [SerializeField] FirstPersonCam cam;
    [SerializeField] Accel movement;
    [SerializeField] Vector3 diff;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !onPlayer)
        {
            movement.enabled = true;
            onPlayer = true;
            gameObject.transform.SetParent(player);
            gameObject.transform.position = new Vector3(player.position.x, gameObject.transform.position.y, player.position.z);
            cam.camRotY = player.rotation.eulerAngles.y;
            cam.camRotX = player.rotation.eulerAngles.x;
        }
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, lookRange))
        {
            //make sure pickup tag is attached
            if (hit.transform.gameObject.tag == "NPC")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    movement.enabled = false;
                    onPlayer = false;
                    gameObject.transform.SetParent(hit.transform.gameObject.transform);
                    *//*diff = new Vector3(gameObject.transform.position.x - hit.transform.gameObject.transform.position.x , gameObject.transform.position.y, gameObject.transform.position.z - hit.transform.gameObject.transform.position.z);*//*
                    gameObject.transform.position = new Vector3(hit.transform.gameObject.transform.position.x, gameObject.transform.position.y, hit.transform.gameObject.transform.position.z);
                    cam.camRotY = hit.transform.gameObject.transform.rotation.eulerAngles.y;
                    cam.camRotX = hit.transform.gameObject.transform.rotation.eulerAngles.x;

                    Debug.Log("Check");
                    //pass in object hit into the PickUpObject function
                }
            }
        }
    }
}
*/