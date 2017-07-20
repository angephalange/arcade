using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movecat : MonoBehaviour {
    public KeyCode moveL;
    public KeyCode moveR;

    public float horizVel = 0;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 4);

        if (Input.GetKeyDown("a"))
        {
            horizVel = -4;
            StartCoroutine(stopSlide());
        }

    }
    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(.5f);
        horizVel = 0;
    }
}
