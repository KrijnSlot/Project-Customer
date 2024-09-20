using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insanity : MonoBehaviour
{
    public static float insanity;
    [SerializeField] float insanityCheck;
    [SerializeField] float insanitySpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(insanity<100)
        insanity += Time.deltaTime * insanitySpeed;
        insanityCheck = insanity;
    }
}
