using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootSpore : MonoBehaviour
{

    public GameObject theProjectile; //pocisk
    public float shootTime; //jak czesto strzela
    public int chanceShoot; 
    public Transform shootFrom; //z moba


    float nextShootTime; //kiedy nastepny raz strzela
    Animator cannonAnim;
    // Start is called before the first frame update
    void Start()
    {
        cannonAnim = GetComponentInChildren<Animator>(); //pierwsza czesc prefaba do animacji
        nextShootTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player" && nextShootTime<Time.time)
        {
            nextShootTime = Time.time + shootTime;
            if(Random.Range(20,40)>=chanceShoot)
            {
                Instantiate(theProjectile, shootFrom.position, Quaternion.identity);//qt oznacza brak rotacji
                cannonAnim.SetTrigger("Attack");
            }
        }
    }
}
