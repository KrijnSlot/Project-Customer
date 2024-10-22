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


    private int tutorialSection = 0;

    // Start is called before the first frame update
    void Start()
    {
        wasd.enabled = false;
        openList.enabled = false;
        closeList.enabled = false;
        wasdIcon.enabled = false;
        tabIcon.enabled = false;
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
            openList.enabled = true;
            tabIcon.enabled = true;

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                
                    openList.enabled = false;
                    tutorialSection += 1;
                
            }
        } 
        else if (tutorialSection == 1)
        {
            closeList.enabled = true;
            Debug.Log("in here");
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                    tabIcon.enabled = false;
                    closeList.enabled = false;
                    tutorialSection += 1;
                
            }
        }
        else if (tutorialSection == 2)
        {
            wasd.enabled = true;
            wasdIcon.enabled= true;

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                {
                    Time.timeScale = 1f;
                    wasd.enabled = false;
                    wasdIcon.enabled = false;
                    tutorialSection += 1;
                }
            }


        }
    }
}
