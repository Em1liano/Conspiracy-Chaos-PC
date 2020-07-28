using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderZone : MonoBehaviour
{
    [SerializeField] private characterController thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<characterController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Ladder");
        if (collision.tag == "Player")
        {
            thePlayer.onLadder = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            thePlayer.onLadder = false;
        }
    }
}
