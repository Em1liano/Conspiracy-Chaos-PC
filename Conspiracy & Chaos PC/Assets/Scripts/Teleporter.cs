using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public int destination;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger entered!");
        StartCoroutine(TeleportToNextMap());
    }
    IEnumerator TeleportToNextMap()
    {
        yield return new WaitForSeconds(.7f);
        SceneManager.LoadSceneAsync(destination);
    }
}
