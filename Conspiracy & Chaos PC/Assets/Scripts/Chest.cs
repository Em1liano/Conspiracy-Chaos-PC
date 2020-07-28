using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    Animator anim;
    public GameObject item;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Chest opening..");
        anim.SetTrigger("Open");
        item.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Destroy(item);
    }
}
