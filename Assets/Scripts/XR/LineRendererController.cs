using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections.Generic;

public class LineRendererController : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public XRInteractorLineVisual interactorLineVisual;
    public List<string> targetTags = new List<string>{"Grabbable", "MenuItem", "gGPU", "gMB", "gCase", "Button"};

    void Start()
    {
        lineRenderer.positionCount = 2;
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (targetTags.Contains(hit.collider.tag))
            {
                lineRenderer.enabled = true;
                interactorLineVisual.enabled = true;
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, hit.point);
            }
            else
            {
                lineRenderer.enabled = false;
                interactorLineVisual.enabled = false;
            }
        }
        else
        {
            lineRenderer.enabled = false;
            interactorLineVisual.enabled = false;
        }
    }
}
