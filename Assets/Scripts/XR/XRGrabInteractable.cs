using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRHandedGrabInteractable : XRGrabInteractable
{
    [SerializeField]
    private Transform LeftHandAttachTransform;
    [SerializeField]
    private Transform RightHandAttachTransform;
    [SerializeField]
    XRRayInteractor LeftController;
    [SerializeField]
    XRRayInteractor RightController;

    private Transform m_OriginalAttachTransform;

    protected override void Awake()
    {
        base.Awake();
        m_OriginalAttachTransform = attachTransform;
    }

    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        XRRayInteractor interactor = args.interactorObject as XRRayInteractor;

        if (interactor != null)
        {
            if (interactor == LeftController)
            {
                Debug.Log("Left hand");
                attachTransform = LeftHandAttachTransform;
            }
            else if (interactor == RightController)
            {
                Debug.Log("Right hand");
                attachTransform = RightHandAttachTransform;
            }
            else
            {
                attachTransform = m_OriginalAttachTransform;
            }
        }
        base.OnSelectEntering(args);
    }
}
