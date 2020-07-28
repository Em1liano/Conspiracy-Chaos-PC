using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float minforce = 100f;
    [SerializeField] private float maxforce = 250f;
    [SerializeField] GameObject player = null;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Player pos: X = " + player.transform.position.x + " --- Y = " + player.transform.position.y);
        float step = speed * Time.deltaTime;

        //transform.Translate(new Vector2(player.transform.position.x, player.transform.position.y) * speed);
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);


        //transform.Translate(Vector2.left * Time.deltaTime * speed);

        //rb.AddForce(Vector2.left * Random.Range(minforce, maxforce));
    }

   private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<characterController>();

        if (player)
        {
            Destroy(gameObject);
        }

        else if (other.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
