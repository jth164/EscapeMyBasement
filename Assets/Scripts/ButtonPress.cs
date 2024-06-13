using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonPress : MonoBehaviour
{
    private XRSimpleInteractable _interactable;
    private Vector3 _originalPosition;
    public VendButton vendButton;  // Add this line to reference the VendButton script.

    private void Awake()
    {
        _interactable = GetComponent<XRSimpleInteractable>();
        _originalPosition = transform.localPosition;
    }

    private void OnEnable()
    {
        _interactable.selectEntered.AddListener(MoveButton);
        _interactable.selectExited.AddListener(ResetButton);
    }

    private void OnDisable()
    {
        _interactable.selectEntered.RemoveListener(MoveButton);
        _interactable.selectExited.RemoveListener(ResetButton);
    }

    private void MoveButton(SelectEnterEventArgs args)
    {
        // Move the button into the base.
        transform.localPosition = _originalPosition + Vector3.right * 0.3f;

        // Call the OnButtonPressed method from the VendButton script.
        vendButton.OnButtonPressed();
    }

    private void ResetButton(SelectExitEventArgs args)
    {
        // Reset the button to its original position.
        transform.localPosition = _originalPosition;
    }
}
