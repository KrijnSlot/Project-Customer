using UnityEngine;

public class SyncAudioSources : MonoBehaviour
{
    public AudioSource[] Speakers;  // Assign your AudioSources here in the Inspector
    public AudioClip audioClip;         // Your song to sync

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
