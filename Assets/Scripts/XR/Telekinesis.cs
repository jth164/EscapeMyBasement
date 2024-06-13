using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telekinesis : MonoBehaviour
{
    public float force = 10.0f;
    public Transform hand; // This is the separate "hand" object
    private GameObject heldObject = null;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (hit.transform.gameObject.tag == "grabable")
                {
                    heldObject = hit.transform.gameObject;
                    heldObject.GetComponent<Rigidbody>().isKinematic = true;
                    heldObject.transform.SetParent(hand); // Make the object a child of the hand
                }

                if (hit.transform.gameObject.tag == "football")
                {
                    heldObject = hit.transform.gameObject;
                    heldObject.GetComponent<Rigidbody>().isKinematic = true;
                    heldObject.transform.SetParent(hand); // Make the object a child of the hand
                }
            }
        }

        if (Input.GetButtonUp("Fire1") && heldObject)
        {
            heldObject.transform.SetParent(null); // Unparent the object
            heldObject.GetComponent<Rigidbody>().isKinematic = false;
            heldObject = null;
        }

        if (heldObject)
        {
            heldObject.transform.position = Vector3.Lerp(heldObject.transform.position, hand.position + hand.forward * 2, force * Time.deltaTime);
        }
    }
}
