using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class QuitButton : MonoBehaviour
{
    public AudioClip buttonSound;
    public AudioSource audioSource;
    private XRSimpleInteractable _interactable;

    private void Awake()
    {
        _interactable = GetComponent<XRSimpleInteractable>();
    }

    private void OnEnable()
    {
        _interactable.selectEntered.AddListener(PressButton);
    }

    private void OnDisable()
    {
        if (_interactable != null)
        {
            _interactable.selectEntered.RemoveListener(PressButton);
        }
    }

    private void PressButton(SelectEnterEventArgs args)
    {
        OnButtonPressed();
    }

    public void OnButtonPressed()
    {
        audioSource.PlayOneShot(buttonSound);

        Application.Quit();
    }
}
