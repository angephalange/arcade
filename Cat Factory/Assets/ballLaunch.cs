using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballLaunch : MonoBehaviour {

    private Vector3 startPos;
    private Quaternion startrot;
    public Rigidbody rb;
    public int xsp;
        public int ysp;
        public int zsp;
    void Start()
    {
        startPos = transform.position;
        startrot = transform.rotation;
        rb = GetComponent<Rigidbody>();
        rb.velocity= new Vector3(xsp,ysp,zsp);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "spawner")
        {

            
            StartCoroutine(ballspawn());
         
        }
    }
IEnumerator ballspawn() {
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        transform.position = startPos;
        transform.rotation = startrot;
        yield return new WaitForSeconds(4f);
        rb.isKinematic = false;
        rb.velocity = new Vector3(xsp, ysp, zsp);

    }
}