using UnityEngine;
using UnityEngine.Events;

public class VendButton : MonoBehaviour
{
    public UnityEvent<int> onButtonPressed;
    public int buttonNumber;
    public AudioClip buttonSound;
    public AudioSource audioSource;

    public void OnButtonPressed()
    {
        onButtonPressed?.Invoke(buttonNumber);

        if (audioSource != null && buttonSound != null)
        {
            audioSource.clip = buttonSound;
            audioSource.Play();
        }
    }
}
