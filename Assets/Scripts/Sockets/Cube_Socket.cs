using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Cube_Socket : MonoBehaviour
{
    private IXRSelectInteractable item;
    public void ItemAdded()
    {
        item = GetComponent<XRSocketInteractor>().GetOldestInteractableSelected();
    }
    public void ItemRemoved()
    {
        item = null;
    }
}
