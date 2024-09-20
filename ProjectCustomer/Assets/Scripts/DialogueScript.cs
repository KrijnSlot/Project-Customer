using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Toolbars;
using Yarn.Unity;
using System;
using System.Reflection;

public class DialogueScript : MonoBehaviour
{
    InMemoryVariableStorage storage;

    public static bool colWait;

    private bool positive, neutral, negative;

    private void Start()
    {
        storage = FindObjectOfType<InMemoryVariableStorage>();
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

            DisableColliding();
        }
        if (neutral)
        {
            /*Dont affect the players sanity*/

            DisableColliding();
        }
        if (negative)
        {
            /*Decrease the players sanity*/

            DisableColliding();
        }

        ResetValue();
    }

    void DisableColliding()
    {
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
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }
}
