using UnityEngine;

public class AudioPuzzle : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    void Start()
    {
        if (audioClip == null)
        {
            Debug.Log("Audio clip is not assigned");
            return;
        }

        audioSource.clip = audioClip;
    }

    public void OnButtonPressed(int input)
    {
        if (input == 0)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            else
            {
                audioSource.Play();
            }
        }
    }
}
