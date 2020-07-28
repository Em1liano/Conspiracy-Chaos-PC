using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Events;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    [Header("Health")]
    public float enemyMaxHealth;
    public float currentHealth;
    public bool isAlive = true;
    public Image healthBar;
    public Canvas enemyCanvas;

    [Header("Teleport")]
    public GameObject teleport;

    //public GameObject enemyDeathFX;
    // public AudioClip deathKnell;

    [Header("Sounds")]
    [SerializeField] AudioSource audio;
    public AudioClip deathSound;

    float startTime = 0;
    float time = 0;

    [SerializeField] private float enragedHealthActive = 500f;
    void Start()
    {
        // enemyMaxHealth = RemoteSettings.GetFloat("BossHealth");
        startTime = Time.time;
        currentHealth = enemyMaxHealth;
        isAlive = true;
        audio = GetComponent<AudioSource>();
    }

    public void addDamage(float damage)
    {
        enemyCanvas.gameObject.SetActive(true);
        currentHealth -= damage;

        healthBar.fillAmount = currentHealth / enemyMaxHealth;

        if (currentHealth <= 0) makeDead();
        ///
        Debug.Log("luk dmg");

        if (currentHealth <= enragedHealthActive)
        {
            GetComponent<Animator>().SetBool("isEnraged", true);
        }
    }

    public void meleeDamage(int damage)
    {
        enemyCanvas.gameObject.SetActive(true);
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / enemyMaxHealth;

        if (currentHealth <= 0) makeDead();
        ///
        Debug.Log("meleedmg");

        if (currentHealth <= enragedHealthActive)
        {
            GetComponent<Animator>().SetBool("isEnraged", true);
        }
    }

    void makeDead()
    {
        isAlive = false;

        enemyCanvas.gameObject.SetActive(false);

        string timeInSec = time.ToString("mm\\:ss");
        AnalyticsResult result = AnalyticsEvent.Custom("Boss zginął po : ", new Dictionary<string, object>
        {
            {    "Event_ID", 2 },
            {    "Czas", timeInSec }
        });

        Destroy(gameObject, 1f);

        teleport.SetActive(true);
        audio.PlayOneShot(deathSound);
    }
}
