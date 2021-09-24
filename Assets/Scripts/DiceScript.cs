using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour
{
    static Rigidbody rb;
    public static Vector3 diceVelocity;
    float tim=0;
    private bool trig = false; 
    private bool pressKey = false;
    public bool changePlayer = true; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        diceVelocity = rb.velocity*500;
        if (Input.GetKeyDown(KeyCode.Space) && !trig) // stop rotation and active gravity 
        {
            GetComponent<Rigidbody>().useGravity = true;
            pressKey = true; 
            DiceNumberTextScript.diceNumber = 0;
            float dirX = Random.RandomRange(250, 500); 
            float dirY = Random.RandomRange(250, 500); 
            float dirZ = Random.RandomRange(250, 500);
            //transform.position = new Vector3(Random.RandomRange(-80, -67), Random.RandomRange(30, 50), Random.RandomRange(-200, -178));
            //transform.rotation = Random.rotation;
            rb.AddForce(transform.up * 700);
            rb.AddTorque(dirX, dirY, dirZ); 
        }
        if (!pressKey) // rotation dice hight
        {
            transform.Rotate(new Vector3(500 * Time.deltaTime, 500 * Time.deltaTime, 500 * Time.deltaTime));
            transform.position = new Vector3(0,33,-184);
            DiceNumberTextScript.diceNumber = 0;
            trig = false;
            GetComponent<Rigidbody>().useGravity = false;
        }
    }
	
	private void OnTriggerStay(Collider other) //when dice toach floor
	{
        trig = true; 
        tim += Time.deltaTime;
        if (tim > 5 && changePlayer )
        {
            tim = 0;
            pressKey = false;
            transform.position = new Vector3(0, 33, -184);
        }
    }
}
