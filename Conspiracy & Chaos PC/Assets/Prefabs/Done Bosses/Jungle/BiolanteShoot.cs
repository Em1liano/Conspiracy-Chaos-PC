using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiolanteShoot : MonoBehaviour
{
    [SerializeField] GameObject projectile;

    [SerializeField] GameObject projectile2;
    [SerializeField]
    GameObject gunPos;
    [SerializeField] GameObject gunPosSecond;

    // public float shootTime; //jak czesto strzela
    //public int chanceShoot;
    // public Transform shootFrom; //z moba
    //public GameObject theProjectile; //pocisk

    //float nextShootTime; //kiedy nastepny raz strzela
    //Animator enemyAnimator;

    void Start()
    {
        //enemyAnimator = GetComponent<Animator>();
        //nextShootTime = 0f;
    }
    public void FireMain()
    {
        GameObject newProjectile =
            Instantiate(projectile, gunPos.transform.position, Quaternion.identity) as GameObject;
    }
    public void FireSecond()
    {
        GameObject newProjectile =
            Instantiate(projectile2, gunPosSecond.transform.position, Quaternion.identity) as GameObject;
    }
}
