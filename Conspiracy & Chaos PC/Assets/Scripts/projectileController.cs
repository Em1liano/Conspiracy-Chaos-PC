using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour
{
    public float rocketSpeed=1; //obiekt walki/bron
    Rigidbody2D RB;
    // Start is called before the first frame update
    void Awake()
    {
        RB = GetComponent<Rigidbody2D>();//szukam RB w obiekcie
        if(transform.localRotation.z>0)
        RB.AddForce(new Vector2(-1, 0) * rocketSpeed, ForceMode2D.Impulse);

        else RB.AddForce(new Vector2(1, 0) * rocketSpeed, ForceMode2D.Impulse);

        //1. kierunek sily, w prostej linii 2. rodzaj sily - tu: explosive
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void removeForce()
    {
        RB.velocity = new Vector2(0, 0);
    }
}