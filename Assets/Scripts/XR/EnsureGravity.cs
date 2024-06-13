using UnityEngine;

public class EnsureGravity : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (rb != null)
        {
            if (rb.useGravity == false)
            {
                rb.useGravity = true;
            }
        }
    }
}
