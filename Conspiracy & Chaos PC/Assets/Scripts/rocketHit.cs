using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketHit : MonoBehaviour
{

    public float weaponDamage;
    projectileController myPC; //odwolanie do skryptu projectileController
    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Awake()
    {
        myPC = GetComponentInParent<projectileController>();

    }

    void OnTriggerEnter2D(Collider2D other) //zderzenie sie 2 obiektow
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myPC.removeForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if (other.tag == "Enemy") //layer
            {
                enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>();
                hurtEnemy.addDamage(weaponDamage);//systemowe

                
            }
            else if (other.tag == "Boss")
            {
                BossHealth hurtBoss = other.gameObject.GetComponent<BossHealth>();
                hurtBoss.addDamage(weaponDamage);
            }
        }
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable") && other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            myPC.removeForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if (other.tag == "Enemy") //layer
           {
                enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>();
                hurtEnemy.addDamage(weaponDamage);//systemowe
            }
        }
    }
}
