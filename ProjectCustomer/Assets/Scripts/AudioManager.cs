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
        reverbZone.reverb = (int)(198 + (Insanity.insanity * 6.02));

        foreach (AudioChorusFilter filter in chorusFilter)
        {
            filter.depth = (float)(Insanity.insanity * 0.0065);
            filter.rate = (float)(Insanity.insanity * 0.01);
            filter.delay = (float)(Insanity.insanity * 0.4);
        }

        foreach (AudioLowPassFilter filter in lowPassFilter)
        {
            filter.cutoffFrequency = (int)(1500 - (Insanity.insanity * 11.5));
        }

        foreach (AudioHighPassFilter filter in highPassFilter)
        {
            filter.cutoffFrequency = Insanity.insanity * 4;
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
