using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Drawing;

public class UI : MonoBehaviour
{
    [HideInInspector] public static float insanity;
    [SerializeField] float insanitySpeed;
    [SerializeField] int addAlzheimers;
    [SerializeField] string sceneName;
    // Start is called before the first frame update
    float insanityCheck;
    Slider slider;

    [SerializeField] GameObject TextHolder;
    [SerializeField] Button button1;
    [SerializeField] Button button2;
    [SerializeField] Button button3;

    DialogueText DialogueText;

    TextMeshProUGUI text;
    TextMeshProUGUI button1Text;
    TextMeshProUGUI button2Text;
    TextMeshProUGUI button3Text;

    public NPCSript npcscript;
    FirstPersonCam fpc;


    int random;
    bool once;
    public bool done;
    float xSense;
    float ySense;


    GNB gnb1;
    GNB gnb2;
    GNB gnb3;

    void Start()
    {
       GettingComponents();

        xSense = fpc.mouseSenseX; 
        ySense = fpc.mouseSenseY;
        SetButtons(false);

    }

    void GettingComponents()
    {
        slider = transform.GetChild(1).gameObject.GetComponentInChildren<Slider>();
        fpc = GetComponent<FirstPersonCam>();
        DialogueText = GetComponent<DialogueText>();

        text = TextHolder.GetComponent<TextMeshProUGUI>();
        button1Text = button1.GetComponentInChildren<TextMeshProUGUI>();
        button2Text = button2.GetComponentInChildren<TextMeshProUGUI>();
        button3Text = button3.GetComponentInChildren<TextMeshProUGUI>();

        gnb1 = button1.GetComponent<GNB>();
        gnb2 = button2.GetComponent<GNB>();
        gnb3 = button3.GetComponent<GNB>();
    }
    void SetButtons(bool check)
    {
        if (!check)
        {
            button1.enabled = false;
            button2.enabled = false;
            button3.enabled = false;

            button1.image.enabled = false;
            button2.image.enabled = false;
            button3.image.enabled = false;

            button1Text.enabled = false;
            button2Text.enabled = false;
            button3Text.enabled = false;

            text.enabled = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            fpc.move.enabled = true;
            fpc.mouseSenseX = xSense;
            fpc.mouseSenseY = ySense;
            
        }
        else
        {
            button1.enabled = true;
            button2.enabled = true;
            button3.enabled = true;

            button1.image.enabled = true;
            button2.image.enabled = true;
            button3.image.enabled = true;

            button1Text.enabled = true;
            button2Text.enabled = true;
            button3Text.enabled = true;

            text.enabled = true;
            fpc.move.enabled = false;
            fpc.mouseSenseX = 1;
            fpc.mouseSenseY = 1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (npcscript != null)
        {
            if (npcscript.colliding && !once)
            {
                print("Dialogue starting");
                random = Random.Range(1, 4);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SetText();
                once = true;
            }
        }

        slider.value = insanity;
        if (insanity < 100)
            insanity += Time.deltaTime * insanitySpeed;
        insanityCheck = insanity;
        if (insanity >= 100)
        {
            SceneManager.LoadScene(sceneName);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void SetText()
    {
        SetButtons(true);
        text.text = "Someone seemed to have accidentally bumped into you";
        switch (random)
        {
            case 1:
                button1Text.text = DialogueText.Button(1);
                gnb1.gnb(1);
                button2Text.text = DialogueText.Button(2);
                gnb2.gnb(2);
                button3Text.text = DialogueText.Button(3);
                gnb3.gnb(3);
                break;
            case 2:
                button1Text.text = DialogueText.Button(3);
                gnb1.gnb(3);
                button2Text.text = DialogueText.Button(1);
                gnb2.gnb(1);
                button3Text.text = DialogueText.Button(2);
                gnb3.gnb(2);
                break;
            case 3:
                button1Text.text = DialogueText.Button(2);
                gnb1.gnb(2);
                button2Text.text = DialogueText.Button(3);
                gnb2.gnb(3);
                button3Text.text = DialogueText.Button(1);
                gnb3.gnb(1);
                break;


        }

    }

    public void OnButtonPress(int buttonPressed)
    {
        if (buttonPressed == 1)
        {
            if (gnb1.good)
            {
                insanity -= addAlzheimers;
            }
            else if (gnb1.bad)
            {
                insanity += addAlzheimers;
            }
        }
        else if (buttonPressed == 2)
        {
            if (gnb2.good)
            {
                insanity -= addAlzheimers;
            }
            else if (gnb2.bad)
            {
                insanity += addAlzheimers;
            }
        }
        else if (buttonPressed == 3)
        {
            if (gnb3.good)
            {
                insanity -= addAlzheimers;
            }
            else if (gnb3.bad)
            {
                insanity += addAlzheimers;
            }
        }
        if (insanity < 0)
        {
            insanity = 0;
        }
        SetButtons(false);
        print("Done");
        npcscript = null;
        done = true;
        once = false;
    }

}
