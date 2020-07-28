using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rigidbodyyy;
    [SerializeField]
    private float speed = 3f;

    void Start()
    {
        player = this.gameObject;
        rigidbodyyy = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
            GetComponent<Rigidbody>().AddForce(new Vector2(speed, 0));

        if (Input.GetKey(KeyCode.A))
            GetComponent<Rigidbody>().AddForce(new Vector2(-speed, 0));

        if(Input.GetKey(KeyCode.Space))
            GetComponent<Rigidbody>().AddForce(new Vector2(0, speed+50f));
    }
}
