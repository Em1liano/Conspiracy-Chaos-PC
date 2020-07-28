using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sporeController : MonoBehaviour
{
    public float sporeSpeedHigh;
    public float sporeSpeedLow; //wartosci predkosci od wystrzelenia
    public float sporeAngle;
    //public float sporeTorqueAngle;

    Rigidbody2D sporeRB;

    // Start is called before the first frame update
    void Start()
    {
        sporeRB = GetComponent<Rigidbody2D>();
        sporeRB.AddForce(new Vector2(Random.Range(-sporeAngle, sporeAngle), Random.Range(sporeSpeedLow, sporeSpeedHigh)), ForceMode2D.Impulse);//miedzy pozycja x i x
        //sporeRB.AddTorque((Random.Range(-sporeTorqueAngle, sporeTorqueAngle)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
