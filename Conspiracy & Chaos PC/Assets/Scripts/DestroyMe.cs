using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    [SerializeField] GameObject player = null;
    public GameObject explosionEffect;

    public float aliveTime=2;
    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, aliveTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<characterController>();

        if (player)
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }
    }
}