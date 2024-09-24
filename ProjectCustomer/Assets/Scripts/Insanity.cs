using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class Insanity : MonoBehaviour
{
    public static float insanity;
    [SerializeField] float insanityCheck;
    [SerializeField] float insanitySpeed;
    [SerializeField] Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = insanity;
        if(insanity<100)
        insanity += Time.deltaTime * insanitySpeed;
        insanityCheck = insanity;
    }
}
