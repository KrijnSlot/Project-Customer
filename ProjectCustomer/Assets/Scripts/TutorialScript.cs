using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI wasd;
    [SerializeField] private TextMeshProUGUI openlist;
    [SerializeField] private TextMeshProUGUI closelist;

    private int tutorialSection = 0;

    // Start is called before the first frame update
    void Start()
    {
        wasd.enabled = false;
        openlist.enabled = false;
        closelist.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        TutorialFunction();
        Debug.Log(tutorialSection);

    }


    private void TutorialFunction()
    {

        if (tutorialSection == 0)
        {
            Time.timeScale = 0.4f;
            openlist.enabled = true;

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                
                    openlist.enabled = false;
                    tutorialSection += 1;
                
            }
        } 
        else if (tutorialSection == 1)
        {
            closelist.enabled = true;
            Debug.Log("in here");
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                    closelist.enabled = false;
                    tutorialSection += 1;
                
            }
        }
        else if (tutorialSection == 2)
        {
            wasd.enabled = true;

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                {
                    Time.timeScale = 1f;
                    wasd.enabled = false;
                    tutorialSection += 1;
                }
            }


        }
    }
}
