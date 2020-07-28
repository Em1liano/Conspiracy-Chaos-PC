using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MagisterR : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Michał Kowal głosuje na Pis?!");
        //Invoke("Tep", .6f);
    }


    private void Tep()
    {
        SceneManager.LoadScene(0);
    }
}
