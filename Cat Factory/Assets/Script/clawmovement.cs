using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clawmovement : MonoBehaviour {
    public float speed;
    public float speed2;
    public Transform leftlimit;
    public Transform rightlimit;
    public Transform backlimit;
    public Transform frontlimit;
    public Transform botlimit;
    public Transform toplimit;
    public Transform homelimit;
    public Transform Camera1;
    public Transform Camera2;
    public Transform Camera3;
    public Transform Camera4;
    public GameObject thecamera;
    public string clawstatus;
    public string camerastatus;
    public string direction;
    private Quaternion rot1;
    private Vector3 pos1;
    private Vector3 des;
    private Quaternion des2;
    private float fraction;
    // Use this for initialization
    void Start () {
        direction = "left";
        clawstatus = "open";
        camerastatus = "front";
        fraction = 0;
       
        des = new Vector3(Camera2.transform.position.x, Camera2.transform.position.y, Camera2.transform.position.z);
        pos1 = new Vector3(Camera1.transform.position.x, Camera1.transform.position.y, Camera1.transform.position.z);
        rot1 = new Quaternion(Camera1.transform.rotation.x, Camera1.transform.rotation.y, Camera1.transform.rotation.z, Camera1.transform.rotation.w);
        des2 = new Quaternion(Camera2.transform.rotation.x, Camera2.transform.rotation.y, Camera2.transform.rotation.z, Camera2.transform.rotation.w);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("c"))
        {
            if (camerastatus == "front")
            {
                camerastatus = "side";
            }
            else
            {
                camerastatus = "front";
            }
        }
        
        //  if (direction == "forward"  || direction == "backward" ) {
        if (camerastatus == "front") {    
            thecamera.transform.position = Vector3.Lerp(thecamera.transform.position, des, speed2 * Time.deltaTime);
            thecamera.transform.rotation = Quaternion.Slerp(thecamera.transform.rotation, des2, speed2 * Time.deltaTime);

        }
        // if (direction == "left" || direction == "right")
       if (camerastatus == "side")
            {

            thecamera.transform.position = Vector3.Lerp(thecamera.transform.position, pos1, speed2 * Time.deltaTime);
            thecamera.transform.rotation = Quaternion.Slerp(thecamera.transform.rotation, rot1, speed2 * Time.deltaTime);

        }
        if (transform.position.z >= leftlimit.transform.position.z + 0.5f & direction == "left" )
        {

            transform.Translate(0, 0, speed * -1 * Time.deltaTime);
            if (transform.position.z <= leftlimit.transform.position.z +0.5f) {
                direction = "right";
            }
        }
        if (transform.position.z <= rightlimit.transform.position.z +0.5f & direction == "right")
        {
            transform.Translate(0, 0, speed * 1 * Time.deltaTime);

            if (transform.position.z >= rightlimit.transform.position.z + 0.5f)
            {

                transform.Translate(0, 0, speed * -1 * Time.deltaTime);
                direction = "left";
            }
        }
        if (transform.position.x >= backlimit.transform.position.x + 0.5f & direction == "forward")
        {

            transform.Translate(speed * -1 * Time.deltaTime, 0, 0);
            if (transform.position.x <= backlimit.transform.position.x + 0.5f)
            {
                direction = "backward";
            }
        }
        if (transform.position.x <= frontlimit.transform.position.x + 0.5f & direction == "backward")
        {
            transform.Translate(speed * 1 * Time.deltaTime, 0, 0);

            if (transform.position.x >= frontlimit.transform.position.x + 0.5f)
            {

                transform.Translate(speed * -1 * Time.deltaTime, 0, 0);
                direction = "forward";
            }
        }
        if (Input.GetKeyDown("space"))
        {
            if (direction == "forward" || direction == "backward")
            {
                direction = "down";
                camerastatus = "side";
            }
        }
        if (Input.GetKeyDown("space")) {
            if (direction == "left" || direction == "right")
            {
                direction = "forward";

                camerastatus = "front";
            }
        }
        
            if (transform.position.y >= botlimit.transform.position.y + 0.5f & direction == "down")
        {

            transform.Translate(0, speed * -1 * Time.deltaTime, 0);
            if (transform.position.y <= botlimit.transform.position.y + 0.5f)
            {
                clawstatus = "closed";
               
                StartCoroutine(liftclaw());

            }
        }

        if (transform.position.y <= toplimit.transform.position.y + 0.5f & direction == "up") {

            transform.Translate(0, speed * 1 * Time.deltaTime, 0);

            if (transform.position.y >= toplimit.transform.position.y + 0.5f) {
                direction = "home";

            }
        }
        if (transform.position.z <= homelimit.transform.position.z + 0.5f & direction == "home") {

            transform.Translate(0, 0, speed * 1 * Time.deltaTime);

        }
        if (transform.position.x >= homelimit.transform.position.x + 0.5f & direction == "home")
        {

            transform.Translate(speed * -1 * Time.deltaTime, 0,0 );

        }
        if (transform.position.z >= homelimit.transform.position.z + 0.5f && transform.position.x <= homelimit.transform.position.x + 0.5f && direction == "home") {
            dropclaw();
            clawstatus = "open";
            direction = "left";
        }


        //transform.position = new Vector3(0, 0, 0);

    }
    IEnumerator liftclaw()
    {

        yield return new WaitForSeconds(1);
        direction = "up";

    }
    IEnumerator dropclaw() {
        print("waiting");
        yield return new WaitForSeconds(2);

        clawstatus = "open";
        


    }
}
