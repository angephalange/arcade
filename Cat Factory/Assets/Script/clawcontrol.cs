using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clawcontrol : MonoBehaviour {
    public GameObject clawstatus;
    Animator anim;
    clawmovement testc;
    public string currentclaw;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        clawstatus = GameObject.Find("ball");
        testc = clawstatus.GetComponent<clawmovement>();
    }
	
	// Update is called once per frame
	void Update () {
        currentclaw = testc.clawstatus;
        if (currentclaw == "closed")
        {
            anim.SetBool("closed", true);
            anim.SetBool("open", false);
        }
        else {
            anim.SetBool("closed", false);
            anim.SetBool("open", true); }
	}
}
