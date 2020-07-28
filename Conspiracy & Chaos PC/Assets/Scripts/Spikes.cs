using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    public float slowFactor = 10f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Waiting());
        }
    }
    IEnumerator Waiting()
    {
        Time.timeScale = 1f / slowFactor;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowFactor;
        yield return new WaitForSeconds(.7f);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowFactor;
        
    }
}
