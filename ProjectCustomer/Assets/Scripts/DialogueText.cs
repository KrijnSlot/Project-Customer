using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueText : MonoBehaviour
{
    public string Button(int option)
    {
        string Buttontext;
        int rnd = Random.Range(1, 4);
        switch (option)
        {
            case 1:
                if (rnd == 1)
                    Buttontext = "Can I help you?";
                else if (rnd == 2)
                    Buttontext = "Are you ok?";
                else
                    Buttontext = "Do I need to get you help?";
                return Buttontext;
            case 2:
                if (rnd == 1)
                    Buttontext = "Walk away";
                else if (rnd == 2)
                    Buttontext = "Damn";
                else
                    Buttontext = "Oh Mah Goh";
                return Buttontext;
            case 3:
                if (rnd == 1)
                    Buttontext = "ARE YOU BLIND OR SOMETHING?!";
                else if (rnd == 2)
                    Buttontext = "FUCK YOU";
                else
                    Buttontext = "I WILL BEAT YOU UP";
                return Buttontext;
            default:
                return null;
        }
    }
}
