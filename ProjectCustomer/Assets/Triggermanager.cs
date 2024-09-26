using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggermanager : MonoBehaviour
{
    public
    float canSwitch = 25;
    // Start is called before the first frame update

    // Update is called once per frame
    private void FixedUpdate()
    {
        canSwitch -= Time.deltaTime;
    }
}
