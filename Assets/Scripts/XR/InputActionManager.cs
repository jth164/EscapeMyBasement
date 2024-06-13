using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionManager : MonoBehaviour
{
    public InputActionAsset actionAsset;

    void OnEnable()
    {
        actionAsset.Enable();
    }

    void OnDisable()
    {
        actionAsset.Disable();
    }
}

