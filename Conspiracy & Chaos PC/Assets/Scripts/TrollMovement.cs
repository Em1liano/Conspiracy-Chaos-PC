using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrollMovement : MonoBehaviour
{
    public float enemySpeed;

    Animator enemyAnimator;

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
    bool charging;
    bool attacking;
    Rigidbody2D enemyRB;

    [SerializeField] private float distVal = 1.5f; //dystans, od ktorego enemy wlacza animacje ataku i zabiera zycie


    [Header("Sounds")]
    AudioSource audio;
    public AudioClip attackSound;
    public AudioClip walkSound;


    void Start()
    {
        whatIsEnemy = GameObject.FindGameObjectWithTag("Player").transform;
        enemyAnimator = GetComponentInChildren<Animator>();
        enemyRB = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Time.time > nextFlipChance)
        {
            //if (Random.Range(0, 10) >= 3) flipFacing(); //co 3 sek szansa na flip
            //nextFlipChance = Time.time + flipTime; //% szansy
        }

    }
    IEnumerator WaitForNextSoundAttack()
    {
        yield return new WaitForSeconds(1f);
        audio.PlayOneShot(attackSound);
    }

    void OnTriggerEnter2D(Collider2D other) //widocznosc gracza
    {
        if (other.tag == "Player")
        {
            if (facingRight && other.transform.position.x < transform.position.x)
            {
                //flipFacing();  //jak widzi gracza to sie odwraca
            }
            else if (!facingRight && other.transform.position.x > transform.position.x)
            {
                //flipFacing();
            }
            canFlip = false;
            charging = true;
            //if (other.gameObject.tag.Equals("Player"))

            startChargeTime = Time.time + chargeTime; //opoznienie
            if (Physics2D.OverlapCircleAll(whatIsEnemy.position, distVal).Any(c => c.GetComponent<characterController>() != null))
            {
                audio.PlayOneShot(walkSound);
                attacking = true;
                StartCoroutine(WaitForNextSoundAttack());
            }
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (startChargeTime < Time.time)
            {
                if (!facingRight) enemyRB.AddForce(new Vector2(-1, 0) * enemySpeed);//przesuwanie gracza
                else enemyRB.AddForce(new Vector2(1, 0) * enemySpeed);
                enemyAnimator.SetBool("isCharging", charging);

                //if (Vector2.Distance(whatIsEnemy.position, whatIsPlayer.position) < distVal)
                if (Physics2D.OverlapCircleAll(whatIsEnemy.position, distVal).Any(c => c.GetComponent<characterController>() != null))
                {
                    enemyAnimator.SetBool("isAttacking", attacking);
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canFlip = true;
            charging = false;
            attacking = false;
            enemyRB.velocity = new Vector2(0f, 0f);
            enemyAnimator.SetBool("isCharging", charging);
            enemyAnimator.SetBool("isAttacking", attacking);

        }
    }

    //void flipFacing() //funkcja na obrot
    //{

    //    if (!canFlip) return;
    //    float facingX = enemyGraphic.transform.localScale.x;
    //    facingX *= -1f;
    //    //https://stackoverflow.com/questions/1747654/cannot-modify-the-return-value-error-c-sharp
    //    enemyGraphic.transform.localScale = new Vector3(facingX, enemyGraphic.transform.localScale.y, enemyGraphic.transform.localScale.z);
    //    facingRight = !facingRight;

    //}
}
