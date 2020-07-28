﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RobakAI : MonoBehaviour
{
    Animator anim;

    //facing
    [SerializeField] private GameObject enemyGraphic; //odwolanie, bo simpleAI = grafika;
    [SerializeField] private Transform whatIsEnemy;
    bool canFlip = true; //obracanie
    bool facingRight = false;
    float flipTime = 5f; //jak czesto w idlu sie obraca (co 5 sek);
    float nextFlipChance = 0f;

    //atak
    public float chargeTime; //czas do ataku po zauwazeniu
    float startChargeTime;
    bool attacking;
    Rigidbody2D enemyRB;

    float distVal = 1.5f; //dystans, od ktorego enemy wlacza animacje ataku i zabiera zycie

    [Header("Sounds")]
    AudioSource audio;
    public AudioClip attackSound;
    public AudioClip walkSound;


    void Start()
    {
        whatIsEnemy = GameObject.FindGameObjectWithTag("Player").transform;
        enemyGraphic = GameObject.FindGameObjectWithTag("Enemy");
        
        anim = GetComponentInChildren<Animator>();
        enemyRB = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }


    void OnTriggerEnter2D(Collider2D other) //widocznosc gracza
    {
        if (other.tag == "Player")
        {
            if (facingRight && other.transform.position.x < transform.position.x)
            {
                flipFacing();  //jak widzi gracza to sie odwraca
            }
            else if (!facingRight && other.transform.position.x > transform.position.x)
            {
                flipFacing();
            }
            canFlip = false;
            //charging = true;
            //if (other.gameObject.tag.Equals("Player"))

            startChargeTime = Time.time + chargeTime; //opoznienie
            if (Physics2D.OverlapCircleAll(whatIsEnemy.position, distVal).Any(c => c.GetComponent<characterController>() != null))
            {
                audio.PlayOneShot(walkSound);
                anim.SetTrigger("digOutside");
                StartCoroutine(WaitForSec());
                anim.SetBool("isIdling", true);
                StartCoroutine(WaitForSec());
                anim.SetTrigger("Attack");
                StartCoroutine(WaitForNextSoundAttack());
            }
        }
    }
    IEnumerator WaitForNextSoundAttack()
    {
        yield return new WaitForSeconds(1f);
        audio.PlayOneShot(attackSound);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canFlip = true;
            //charging = false;
            enemyRB.velocity = new Vector2(0f, 0f);
            
            //anim.SetBool("isCharging", charging);
            //anim.SetBool("isAttacking", attacking);

        }
    }

    void flipFacing() //funkcja na obrot
    {

        if (!canFlip) return;
        float facingX = enemyGraphic.transform.localScale.x;
        facingX *= -1f;
        //https://stackoverflow.com/questions/1747654/cannot-modify-the-return-value-error-c-sharp
        enemyGraphic.transform.localScale = new Vector3(facingX, enemyGraphic.transform.localScale.y, enemyGraphic.transform.localScale.z);
        facingRight = !facingRight;

    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(1f);
    }
}
