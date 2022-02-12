using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateForce : MonoBehaviour
{
    public float pushForce = 0.1f;

    //public Transform joint;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("hand"))
        {
            
            Rigidbody handrb = other.GetComponent<Rigidbody>();
            Debug.Log("distance: " + Vector3.Distance(transform.position, other.transform.position));
            Vector3 direction = transform.position - other.transform.position;
            Vector3 force = direction.normalized * pushForce;
            GetComponent<Rigidbody>().AddForce(force);
        }
    }

}
