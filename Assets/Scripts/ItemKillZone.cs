using UnityEngine;

public class ItemKillZone : MonoBehaviour
{
    public Transform targetPosition;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("IKZ"))
        {
            transform.position = targetPosition.position;
        }
    }
}
