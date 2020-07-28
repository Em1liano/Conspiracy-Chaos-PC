using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydraShoot : MonoBehaviour
{
    [SerializeField]
    GameObject projectile;
    [SerializeField]
    GameObject gunPos;
    [SerializeField] GameObject gunPosSecond;

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


    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && nextShootTime < Time.time)
        {
            enemyAnimator.SetTrigger("AttackRange");
        }
    }

    public void Fire()
    {
        GameObject newProjectile =
            Instantiate(projectile, gunPos.transform.position, Quaternion.identity) as GameObject;
        newProjectile.transform.Rotate(new Vector3(0, 0, 180));
    }
    public void FireSecond()
    {
        GameObject newProjectile =
            Instantiate(projectile, gunPosSecond.transform.position, Quaternion.identity) as GameObject;
        newProjectile.transform.Rotate(new Vector3(0, 0, 180));
    }
}
