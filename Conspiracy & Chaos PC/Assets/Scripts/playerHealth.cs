using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class playerHealth : MonoBehaviour
{
    public float fullHealth;
    //public GameObject deathFX;
    //public AudioClip playerHurt;
    Animator playerDie;
    Rigidbody2D RB;
    [SerializeField] float currentHealth;
    public float slowFactor = 10f;

    characterController controlMovement;

    //public AudioClip playerDeathSound;
    //AudioSource playerAS;

    //HUD
    //public Slider healthSlider;
    public Image healthBar;
    public Canvas enemyCanvas;
    //public Image damageScreen;

    bool damaged = false;
    //Color damagedColour = new Color(0f, 0f, 0f, 0.5f);
    //float smoothColour = 5f;

    float startTime = 0;
    float time = 0;

    void Start()
    {
        currentHealth = fullHealth;
        startTime = Time.time;
        controlMovement = GetComponent<characterController>();
        playerDie = GetComponent<Animator>();

        //HUD inicjalizacja
       // currentHealth = fullHealth;

        damaged = false;

        //playerAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    /*void Update()
    {
        if (damaged)
        {
            damageScreen.color = damagedColour;
        }
        else
        {
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColour * Time.deltaTime);
        }

        damaged = false;

    }*/

    public void addDamage(float damage)
    {
        if (damage <= 0) return;

        currentHealth -= damage;

        /*playerAS.clip = playerHurt;
        playerAS.Play();*/

        //playerAS.PlayOneShot(playerHurt);

        healthBar.fillAmount = currentHealth / fullHealth;

        damaged = true;

        if (currentHealth <= 0)
        {
            makeDead();
        }
    }

  /*  public void addHealth(float healthAmount)
    {
        currentHealth += healthAmount;
        if (currentHealth > fullHealth) currentHealth = fullHealth;
        healthSlider.value = currentHealth;
    }*/

    public void makeDead()
    {
        //Instantiate(deathFX, transform.position, transform.rotation);
        controlMovement.isAlive = false;
        playerDie.SetTrigger("Die");

        string timeInSec = time.ToString("mm\\:ss");
        AnalyticsResult result = AnalyticsEvent.Custom("Gracz umarł: ", new Dictionary<string, object>
        {
            {    "Event_ID", 1 },
            {    "Czas", timeInSec }
        });
        //Destroy(gameObject, 1f);
        
        StartCoroutine(Waiting());
        //controlMovement.isAlive = true;

        //AudioSource.PlayClipAtPoint(playerDeathSound, transform.position);
    }
    IEnumerator Waiting()
    {
        Time.timeScale = 1f / slowFactor;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowFactor;
        yield return new WaitForSeconds(.5f);

        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowFactor;
        //Destroy(gameObject);

        controlMovement.isAlive = true;
        currentHealth = fullHealth;
        healthBar.fillAmount = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Get active scene?!");
    }
}
