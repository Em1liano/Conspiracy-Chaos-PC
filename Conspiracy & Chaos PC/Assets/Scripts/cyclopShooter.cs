using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cyclopShooter : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float minforceDown = 100f;
    [SerializeField] private float maxforceDown = 250f;
    [SerializeField] private float minforceUp = 100f;
    [SerializeField] private float maxforceUp = 250f;
    Transform player;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(RandomRangeShoot()); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<characterController>();

        if (player)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator RandomRangeShoot()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);

        var myCodes = new int[2];
        myCodes[0] = 0;
        myCodes[1] = 1;
        
        var index = Random.Range(0, myCodes.Length);

        var randomNumber = myCodes[index];
        

        switch (randomNumber)
        {
            case 0:
                rb.AddForce(Vector2.down * Random.Range(minforceDown, maxforceDown));
                break;
            case 1:
                rb.AddForce(Vector2.up * Random.Range(minforceUp, maxforceUp));
                break;
        }
        yield return new WaitForSeconds(.5f);
    }
}
