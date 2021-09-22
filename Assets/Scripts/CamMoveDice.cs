using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMoveDice : MonoBehaviour
{
    public GameObject dice; 
    private Vector3 positionRelative; 
    // Start is called before the first frame update
    void Start()
    {
        positionRelative = transform.position - dice.transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (dice.transform.position.x + positionRelative.x, 85, dice.transform.position.z + positionRelative.z);
        
    }
}
