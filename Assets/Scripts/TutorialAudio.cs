using UnityEngine;

public class TutorialAudio : MonoBehaviour
{
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    public void OnButtonPressed(int buttonNumber)
    {
        if (buttonNumber == 0)
        {
            if (audioSource != null)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                else
                {
                    audioSource.Stop();
                }
            }
            else
            {
                Debug.Log("No AudioSource component found on this GameObject.");
            }
        }
    }
}
