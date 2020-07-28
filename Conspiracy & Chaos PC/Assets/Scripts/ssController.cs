using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class ssController : MonoBehaviour
{

    Rigidbody2D ss;
    public float speed;

    public Transform player;
    private UnityEngine.Vector2 target;

   

    void Start()
    {
        ss=GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new UnityEngine.Vector2(player.position.x, player.position.y);

    }

    // Update is called once per frame
    void Update()
    {
        ss.AddForce(new UnityEngine.Vector2(-1, 0) * speed, ForceMode2D.Impulse);

        transform.position = UnityEngine.Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x==target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            DestroyProjectile();
            
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }


}
