using UnityEngine;

public class SyncAudioSources : MonoBehaviour
{
    public AudioSource[] Speakers;  // Assign your AudioSources here in the Inspector
    public AudioClip audioClip;         // Your song to sync


    public AudioChorusFilter[] chorusFilter;
    public AudioLowPassFilter[] lowPassFilter;
    public AudioHighPassFilter[] highPassFilter;
    public AudioReverbZone reverbZone;


    private void Update()
    {
        reverbZone.reverb = (int)(198 + (UI.insanity * 6.02));

        foreach (AudioChorusFilter filter in chorusFilter)
        {
            filter.depth = (float)(UI.insanity * 0.0065);
            filter.rate = (float)(UI.insanity * 0.01);
            filter.delay = (float)(UI.insanity * 0.4);
        }

        foreach (AudioLowPassFilter filter in lowPassFilter)
        {
            filter.cutoffFrequency = (int)(1500 - (UI.insanity * 11.5));
        }

        foreach (AudioHighPassFilter filter in highPassFilter)
        {
            filter.cutoffFrequency = UI.insanity * 4;
        }
    }
    void Start()
    {
        // Assign the same clip to all audio sources if not done manually
        foreach (AudioSource source in Speakers)
        {
            source.clip = audioClip;
        }

        // Get the current DSP time
        double startTime = AudioSettings.dspTime + 1.0; // Schedule the play to start in 1 second

        // Schedule each audio source to play at the same DSP time
        foreach (AudioSource source in Speakers)
        {
            source.PlayScheduled(startTime);
        }


    }
}
