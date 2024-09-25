using System;
using System.Data;
using UnityEngine;


public class SyncAudioSources : MonoBehaviour
{
    public AudioSource[] audioSources;  // Assign your AudioSources here in the Inspector
    public AudioChorusFilter[] audioChorusFilters;  // Assign your AudioSources here in the Inspector
    public AudioHighPassFilter[] audioHighPassFilter;  // Assign your AudioSources here in the Inspector
    public AudioLowPassFilter[] audioLowPassFilter;  // Assign your AudioSources here in the Inspector
    public AudioClip audioClip;         // Your song to sync
    public AudioReverbZone audioReverbZone;

    void Start()
    {
        // Assign the same clip to all audio sources if not done manually
        foreach (AudioSource source in audioSources)
        {
            source.clip = audioClip;
        }

        // Get the current DSP time
        double startTime = AudioSettings.dspTime + 1.0; // Schedule the play to start in 1 second

        // Schedule each audio source to play at the same DSP time
        foreach (AudioSource source in audioSources)
        {
            source.PlayScheduled(startTime);
        }
    }

    private void Update()
    {
        audioReverbZone.reverb = (int)(198 + (Insanity.insanity * 6.02)); 


        foreach (AudioChorusFilter filter in audioChorusFilters)
        {
            filter.delay = (float)(Insanity.insanity * 0.4);
            filter.rate = (float)(Insanity.insanity * 0.01);
            filter.depth = (float)(Insanity.insanity * 0.65);
        }

        foreach (AudioLowPassFilter filter in audioLowPassFilter)
        {
            filter.cutoffFrequency = (int)(1500 - (Insanity.insanity * 11.5));
        }

        foreach (AudioHighPassFilter filter in audioHighPassFilter)
        {
            filter.cutoffFrequency = Insanity.insanity * 4;
        }


    }
}
