using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;

public class VRInputModule : BaseInputModule
{
    public Camera vrCamera;
    public GameObject currentObject;
    public Animator handAnimator;
    private PointerEventData data;

    protected override void Awake()
    {
        base.Awake();

        data = new PointerEventData(eventSystem);
    }

    public override void Process()
    {
        ActionBasedController controller = GetComponent<ActionBasedController>();
        handAnimator.SetFloat("Trigger", controller.activateAction.action.ReadValue<float>());
        handAnimator.SetFloat("Grip", controller.selectAction.action.ReadValue<float>());


        data.Reset();
        data.position = new Vector2(vrCamera.pixelWidth / 2, vrCamera.pixelHeight / 2);

        eventSystem.RaycastAll(data, m_RaycastResultCache);
        data.pointerCurrentRaycast = FindFirstRaycast(m_RaycastResultCache);
        currentObject = data.pointerCurrentRaycast.gameObject;

        HandlePointerExitAndEnter(data, currentObject);

        if (Input.GetButtonDown("GripButton") || Input.GetButtonDown("TriggerButton"))
        {
            ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerClickHandler);
        }
    }
}
