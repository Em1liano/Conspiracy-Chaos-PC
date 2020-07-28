using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class Yeep : MonoBehaviour
{
    public AudioClip yeep;

    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Yeeep!!!");
            AudioSource.PlayClipAtPoint(yeep, transform.position);
        }
    }
}
