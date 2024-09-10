using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCam : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform playerOrien;
    [SerializeField] float mouseSenseX = 2f;
    [SerializeField] float mouseSenseY = 2f;
    float camRotX = 0f;
    public float camRotY = 0f;
    public float clamp = -90;

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
        camRotY = Mathf.Clamp(camRotY, clamp, clamp+180);
        transform.rotation = Quaternion.Euler(camRotX, camRotY, 0);
    }
}
