using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumps : MonoBehaviour
{
    [SerializeField] private float jumpH = 100f;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SmallStump")
        {
            rb.AddForce(Vector2.up * jumpH); 
        }
    }
    
}
