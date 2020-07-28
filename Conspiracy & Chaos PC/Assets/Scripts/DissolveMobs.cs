using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveMobs : MonoBehaviour
{
    bool isDissolving = false;
    float fade = 1f;

    enemyHealth health;

    void Start()
    {
        health = GetComponent<enemyHealth>();
    }
    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //   isDissolving = true;
        //}
        if (health.isAlive == false)
        {
            isDissolving = true;
        }
        if (isDissolving)
        {
            fade -= Time.deltaTime;
            if (fade <= 0f)
            {
                fade = 0f;
                isDissolving = false;
            }
            //_Fade to odwołanie do grafu konkretnie do opcji
            SpriteRenderer[] allChildren = GetComponentsInChildren<SpriteRenderer>();

            foreach (SpriteRenderer child in allChildren)
            {
                child.gameObject.GetComponent<SpriteRenderer>().material.SetFloat("_Fade", fade);
            }

        }
    }
}
