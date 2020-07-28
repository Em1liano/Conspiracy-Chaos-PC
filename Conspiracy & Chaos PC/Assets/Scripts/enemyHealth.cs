using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    Material material;
    public float enemyMaxHealth;
    [SerializeField] bool isDissolving = false;
    //public GameObject enemyDeathFX;
    float fade = 1f;
    // public bool drops;
    // public GameObject theDrop;

    // public AudioClip deathKnell;

    private bool isDead = false;
    public bool isAlive = true;

    public float currentHealth;


    public Image healthBar;
    public Canvas enemyCanvas;

    [Header("Sounds")]
    [SerializeField] AudioSource audio;
    public AudioClip death;


    [Header("Score")]
    public int currScore = 0;

    void Start()
    {
        currentHealth = enemyMaxHealth;
        //material = GetComponent<SpriteRenderer>().material;
        isAlive = true;
        audio = GetComponentInParent<AudioSource>();
    }


    void Update()
    {
       if (isDead == true)
        {
            
            Fading();
        }


    }

    public void addDamage(float damage)
    {
        enemyCanvas.gameObject.SetActive(true);
        currentHealth -= damage;

        healthBar.fillAmount = currentHealth / enemyMaxHealth;

        if (currentHealth <= 0)
        {
            makeDead();
        }
        Debug.Log("luk dmg");

    }

    public void meleeDamage(int damage)
    {
        enemyCanvas.gameObject.SetActive(true);
        currentHealth -= damage;

        healthBar.fillAmount = currentHealth / enemyMaxHealth;
        if (currentHealth <= 0)
        {
            makeDead();
        }
        Debug.Log("meleedmg");
    }

    public void makeDead()
    {
        isAlive = false;
        audio.PlayOneShot(death);
        isDead = true;
        enemyCanvas.gameObject.SetActive(false);
        Destroy(gameObject, 1f); //destroy systemowa
        
        /// sound death
        //AudioSource.PlayClipAtPoint(deathKnell, transform.position);

    }

    private void Fading()
    {
        fade -= Time.deltaTime;
        isDissolving = true;
        
        if (fade <= 0f)
        {
            fade = 0f;
            isDissolving = false;
        }
        Debug.Log(fade);
    }

    private void OnDestroy()
    {
        FindObjectOfType<GameController>().AddToScore(1);     
        
    }
}
