using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpbar : MonoBehaviour
{
 //   Rigidbody rigid;
    // Start is called before the first frame update

    public float jumpForce ;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Trigger detected with: "+collision.gameObject.name );
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Debug.Log("มกวม");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

 
}
