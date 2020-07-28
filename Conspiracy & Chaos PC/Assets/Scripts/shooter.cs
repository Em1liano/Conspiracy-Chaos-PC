using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour
{
    [SerializeField] 
    GameObject projectile;
    [SerializeField] 
    GameObject gunPos;

    public float shootTime; //jak czesto strzela
    public int chanceShoot;
   // public Transform shootFrom; //z moba
    //public GameObject theProjectile; //pocisk

    float nextShootTime; //kiedy nastepny raz strzela
    Animator enemyAnimator;

    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        nextShootTime = 0f;

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && nextShootTime < Time.time)
        {
                enemyAnimator.SetTrigger("Attack");
        }
    }

    public void Fire()
    {
        GameObject newProjectile =
            Instantiate(projectile, gunPos.transform.position, Quaternion.identity) as GameObject;
    }

    public void Fireball()
    {
        GameObject newProjectile =
           Instantiate(projectile, gunPos.transform.position, Quaternion.identity) as GameObject;
        newProjectile.transform.Rotate(new Vector3(0, 0, 180));
    }
}
