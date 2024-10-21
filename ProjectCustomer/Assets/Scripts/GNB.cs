using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GNB : MonoBehaviour
{
    // Start is called before the first frame update
    public bool good = false;
    public bool bad = false;
    public bool neutral = false;

    public void gnb(int check)
    {
        switch (check)
        {
            case 1:
                good = true;
                bad = false;
                neutral = false;
                break;
            case 2:
                good = false;
                bad = false;
                neutral = true;
                break;
            case 3:
                good = false;
                bad = true;
                neutral = false;
                break;
        }
    }

    // Update is called once per frame
}
