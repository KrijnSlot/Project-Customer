using UnityEngine;

public class SyncAudioSources : MonoBehaviour
{
    [SerializeField]
    public AudioSource audioSource;    // Your single AudioSource
    public Transform[] soundPositions; // Different target positions

    private int currentTargetIndex = 0;

    void Start()
    {
        audioSource.clip = Resources.Load<AudioClip>("Assets/Art/music/Funky beat_Normalized"); // Load your audio clip
        audioSource.spatialBlend = 1.0f; // Make the sound 3D (fully spatial)
        audioSource.Play();
    }

    void Update()
    {
        // Move the audio source to the next target position (or however you want to move it)
        if (soundPositions.Length > 0)
        {
            audioSource.transform.position = soundPositions[currentTargetIndex].position;

            // Example: Change target after some condition, like time
            currentTargetIndex = (currentTargetIndex + 1) % soundPositions.Length;
        }
    }
}
