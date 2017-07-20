using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinSpawn : MonoBehaviour
{

    private Vector3 startPos;
    private Quaternion startrot;
    public Rigidbody rb;
    void Start()
    {
        startPos = transform.position;
        startrot = transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag =="spawner" )
        {
            StartCoroutine(pinWait());
          
        }
    }
    IEnumerator pinWait() {

       yield return new WaitForSeconds(2f);
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        transform.position = startPos;
        transform.rotation = startrot;
        rb.isKinematic = false;


    }
}