using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioSync : MonoBehaviour
{
    public AudioSource master;
    public AudioSource[] slaves;


    private IEnumerator SyncSources()
    {
        while (true)
        {
            foreach (var slave in slaves)
            {
                slave.timeSamples = master.timeSamples;
                yield return null;
            }
        }
    }
}