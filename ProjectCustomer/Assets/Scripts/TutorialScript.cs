using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI wasd;
    [SerializeField] private MeshRenderer wasdIcon;
    [SerializeField] private TextMeshProUGUI openList;
    [SerializeField] private TextMeshProUGUI closeList;
    [SerializeField] private MeshRenderer tabIcon;
    [SerializeField] private FirstPersonCam Player;
    [SerializeField] private MeshRenderer tutorial1;
    [SerializeField] private MeshRenderer tutorial2;
    [SerializeField] private MeshRenderer tutorial3;
    [SerializeField] private TextMeshProUGUI continueTutorial;


    private int tutorialSection = 0;

    // Start is called before the first frame update
    void Start()
    {
        Player.enabled = false;
        wasd.enabled = false;
        openList.enabled = false;
        closeList.enabled = false;
        wasdIcon.enabled = false;
        tabIcon.enabled = false;
        tutorial1.enabled = false;
        tutorial2.enabled = false;
        tutorial3.enabled = false;
        continueTutorial.enabled = false;
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
            tutorial1.enabled = true;
            continueTutorial.enabled = true;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                tutorial1.enabled = false;
                tutorialSection += 1;
            }
        }

        else if (tutorialSection == 1)
        {
            tutorial2.enabled = true;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                tutorial2.enabled = false;
                tutorialSection += 1;
            }
        }

        else if (tutorialSection == 2)
        {
            tutorial3.enabled = true;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                tutorial3.enabled = false;
                continueTutorial.enabled = false;
                tutorialSection += 1;
            }
        }

        if (tutorialSection == 3)
        {
            
            openList.enabled = true;
            tabIcon.enabled = true;

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                
                    openList.enabled = false;
                    tutorialSection += 1;
                
            }
        } 
        else if (tutorialSection == 4)
        {
            closeList.enabled = true;
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                    tabIcon.enabled = false;
                    closeList.enabled = false;
                    tutorialSection += 1;
                
            }
        }
        else if (tutorialSection == 5)
        {
            wasd.enabled = true;
            wasdIcon.enabled= true;

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                {
                    Player.enabled = true;
                    wasd.enabled = false;
                    wasdIcon.enabled = false;
                    tutorialSection += 1;
                }
            }


        }
    }
}
