using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animations : MonoBehaviour
{

    int animint;
    Animator anim;
    public bool SpaceIsPressed;

    // Use this for initialization
    void Start()
    {
        animint = 0;
        SpaceIsPressed = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))

        {
            animint++;
            anim.SetInteger("Clawstate", animint);
            print("anim int = " + animint);
        }
    }
}



