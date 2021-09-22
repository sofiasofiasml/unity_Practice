using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour
{
    static Rigidbody rb;
    public static Vector3 diceVelocity;
    float tim; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        diceVelocity = rb.velocity*500;
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            DiceNumberTextScript.diceNumber = 0;
            float dirX = Random.RandomRange(0, 500); 
            float dirY = Random.RandomRange(0, 500); 
            float dirZ = Random.RandomRange(0, 500);
            transform.position = new Vector3(Random.RandomRange(-80, -67), Random.RandomRange(30, 50), Random.RandomRange(-200, -178));
            transform.rotation = Random.rotation;
            rb.AddForce(transform.up * 500);
            rb.AddTorque(dirX, dirY, dirZ); 
        }
    }

}
