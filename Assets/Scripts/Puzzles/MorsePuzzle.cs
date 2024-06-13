using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MorsePuzzle : MonoBehaviour
{
    public AudioClip shortClip;
    public AudioClip longClip;
    public AudioSource audioSource;
    private string morseCode = "-.... ----. -.... ----.";
    private List<InputDevice> devices = new List<InputDevice>();

    public float characterSpeed = 0.1f;
    public float farnsworthSpeed = 0.1f;

    void Start()
    {
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Controller, devices);
    }

    public void OnButtonPressed(int input)
    {
        if (input == 0)
        {
            StartCoroutine(PlayMorseCode());
        }
    }

    IEnumerator PlayMorseCode()
    {
        foreach (char c in morseCode)
        {
            if (!audioSource.isPlaying)
            {
                if (c == '-')
                {
                    audioSource.clip = longClip;
                    audioSource.Play();
                    SendHapticImpulse(1f, characterSpeed);
                }
                else if (c == '.')
                {
                    audioSource.clip = shortClip;
                    audioSource.Play();
                    SendHapticImpulse(0.5f, characterSpeed);
                }

                while (audioSource.isPlaying)
                {
                    yield return null;
                }

                yield return new WaitForSeconds(farnsworthSpeed);
            }
            else
            {
                audioSource.Stop();
            }
        }
    }

    void SendHapticImpulse(float amplitude, float duration)
    {
        foreach (var device in devices)
        {
            HapticCapabilities capabilities;
            if (device.TryGetHapticCapabilities(out capabilities))
            {
                if (capabilities.supportsImpulse)
                {
                    uint channel = 0;
                    device.SendHapticImpulse(channel, amplitude, duration);
                }
            }
        }
    }
}
