using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor.Toolbars;
#endif
using Yarn.Unity;
using System;
using System.Reflection;

public class DialogueScript : MonoBehaviour
{
    InMemoryVariableStorage storage;
    DialogueRunner runner;

    public static bool colWait;

    private bool positive, neutral, negative;

    [SerializeField] float sanIncrease;
    [SerializeField] float sanDecrease;

    // Dictionary to track which NPCs have been talked to
    private HashSet<string> talkedToNPCs = new HashSet<string>();

    [SerializeField] private NPCSript[] npcList;  // Array to store NPCs

    private void Start()
    {
        storage = FindObjectOfType<InMemoryVariableStorage>();
        runner = FindObjectOfType<DialogueRunner>();
    }

    public void StartDialogue(string nodeName, string npcID)
    {
        // Check if the NPC has already been talked to
        if (!talkedToNPCs.Contains(npcID))
        {
            runner.StartDialogue(nodeName);
            talkedToNPCs.Add(npcID);  // Mark the NPC as talked to
        }
        else
        {
            Debug.Log("You've already talked to this NPC: " + npcID);
        }
    }

    private void Update()
    {
        Detection();
    }

    void Detection()
    {
        storage.TryGetValue("$positive", out positive);
        storage.TryGetValue("$neutral", out neutral);
        storage.TryGetValue("$negative", out negative);

        if (positive || neutral || negative)
        {
            Debug.Log("Positive: " + positive);
            Debug.Log("Neutral: " + neutral);
            Debug.Log("Negative: " + negative);
        }

        if (positive)
        {
            /*Increase the players sanity*/
            UI.insanity -= sanIncrease;

            DisableColliding();
        }
        if (neutral)
        {
            DisableColliding();
        }
        if (negative)
        {
            /*Decrease the players sanity*/
            UI.insanity -= sanDecrease;

            DisableColliding();
        }

        ResetValue();
    }

    void DisableColliding()
    {
        NPCSript.colliding = false;
        Debug.Log("colliding");
        colWait = true;
    }

    void ResetValue()
    {
        if (positive) storage.SetValue("$positive", false);
        if (neutral) storage.SetValue("$neutral", false);
        if (negative) storage.SetValue("$negative", false);
    }

    public void ClearLog()
    {
#if UNITY_EDITOR
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
#endif
    }
}
