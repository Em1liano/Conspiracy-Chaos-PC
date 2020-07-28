using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleShoot : MonoBehaviour
{
    public float speed;

    public Transform player;
    Animator shootAnim;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    public Transform shootFrom;





    // Start is called before the first frame update
    void Start()
    {
        shootAnim = GetComponent<Animator>();
        shootAnim.SetTrigger("Attack");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, shootFrom.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}

    
