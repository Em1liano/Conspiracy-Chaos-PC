using Assets.Equipment;
using Assets.Equipment.Items;
using Assets.Equipment.Ui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class characterController : MonoBehaviour
{
    [Header("Main Character")]
    public float maxSpeed; //szybkość ruchu bohatera
    Rigidbody2D RB; //komponent postaci
    Animator Animacja; //manipulacja animatorem
    bool facingRight;
    public bool isAlive;

    /*private Inventory inventory; //ekwipunek 2020 
    [SerializeField] public UI_Invnentory uiInventory;

    private void Awake()
   {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
    }*/

    [Header("Attack Melee")]
    //walka wrecz
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;

    //hp
    //public int maxHealth = 100;
    //public int currentHealth;
    //public HealthBar healthBar;

    //skakanie
    [Header("Jumpy")]
    [SerializeField] bool isRunning = false;
    [SerializeField] bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer; //czyli utworzony groundlayer do sprawdzenia
    public Transform groundCheck;
    public float jumpHeight;
    float inputVertical;//dr
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    [Header("EQ")]
    private EquipmentNodeSelectorHandler selectorHandler;
    private GameObject selectedItem;
    private int weaponDamage;



    [Header("Shooter")]
    //strzelanie
    public Transform gunTip; //lokalizacja rakiety
    public GameObject bullet; //odwołanie do projectile
    float fireRate = 0.5f; //rite of fire, jedna rakieta (strzała z łuku) co pol sekundy
    float nextFire = 0f; // strzelanie od razu

    //magia
    //public Transform magicTip; //lokalizacja fireballa
    //public GameObject ball; //odwołanie do projectile
    //float ballRate = 0.5f; //rite of ball
    //float nextBall = 0f; // strzelanie od razu

    [Header("Guns")]
    public GameObject weapon01;
    public GameObject weapon02;
    public bool isUsingSword = false;
    public bool isUsingBow = false;

    //public Sprite swordSprite;
    //public Sprite bowSprite;







    // DRABINKA by Emiliano
    [Header("Ladder")]
    public bool onLadder;
    public float climbSpeed;
    private float climbVelocity;
    private float gravityStore;

    [Header("Light")]
    public GameObject pointLight;


    [Header("Canvas")]
    public GameObject canvas;
    public GameObject canvasEQ;

    private static characterController _instance;
    public static characterController Instance { get { return _instance; } }



    // Emilian Skoczylas
    private void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().name == "Boss Castle")
        {
            transform.position = new Vector2(16.41f, 3.91f);
        }
        if (SceneManager.GetActiveScene().name == "Cave")
        {
            canvas.SetActive(true);
            canvasEQ.SetActive(true);
            transform.position = new Vector2(24.75f, -0.38f);
        }
        if (SceneManager.GetActiveScene().name == "Boss Cave")
        {
            canvas.SetActive(true);
            canvasEQ.SetActive(true);
            transform.position = new Vector2(16.34f, 10.53f);
        }
        if (SceneManager.GetActiveScene().name == "Jungle")
        {
            canvas.SetActive(true);
            canvasEQ.SetActive(true);
            pointLight.SetActive(false);
            transform.position = new Vector2(-13.79f, -0.5f);
        }


        // Cutscenes
        if (SceneManager.GetActiveScene().name == "MapCastleToCave")
        {
            canvasEQ.SetActive(false);
            canvas.SetActive(false);
        }
        if (SceneManager.GetActiveScene().name == "Cavecutscene")
        {
            canvasEQ.SetActive(false);
            canvas.SetActive(false);
        }
        if (SceneManager.GetActiveScene().name == "DesertCutscene")
        {
            canvasEQ.SetActive(false);
            canvas.SetActive(false);
        }
        if (SceneManager.GetActiveScene().name == "IceCutscene")
        {
            canvasEQ.SetActive(false);
            canvas.SetActive(false);
        }
        if (SceneManager.GetActiveScene().name == "JungleCutscene")
        {
            canvasEQ.SetActive(false);
            canvas.SetActive(false);
        }
        if (SceneManager.GetActiveScene().name == "MapCastleToCave")
        {
            canvasEQ.SetActive(false);
            canvas.SetActive(false);
        }
        if (SceneManager.GetActiveScene().name == "MapCaveToJungle")
        {
            canvasEQ.SetActive(false);
            canvas.SetActive(false);
        }
        if (SceneManager.GetActiveScene().name == "MapDesertToIce")
        {
            canvasEQ.SetActive(false);
            canvas.SetActive(false);
        }
        if (SceneManager.GetActiveScene().name == "MapIceToVolcano")
        {
            canvasEQ.SetActive(false);
            canvas.SetActive(false);
        }
        if (SceneManager.GetActiveScene().name == "Volcanocutscene")
        {
            canvasEQ.SetActive(false);
            canvas.SetActive(false);
        }
        if (SceneManager.GetActiveScene().name == "MapJungleToDesert")
        {
            canvasEQ.SetActive(false);
            canvas.SetActive(false);
        }




        if (SceneManager.GetActiveScene().name == "Boss Jungle")
        {
            canvas.SetActive(true);
            pointLight.SetActive(false);
            transform.position = new Vector2(-14.5f, 4.53f);
        }
        if (SceneManager.GetActiveScene().name == "Desert")
        {
            canvas.SetActive(true);
            canvasEQ.SetActive(true);
            pointLight.SetActive(false);
            transform.position = new Vector2(23.86f, 0.05f);
        }
        if (SceneManager.GetActiveScene().name == "Boss Desert")
        {
            canvasEQ.SetActive(true);
            canvas.SetActive(true);
            pointLight.SetActive(false);
            transform.position = new Vector2(17.67f, 4.18f);
        }
        if (SceneManager.GetActiveScene().name == "Ice")
        {
            canvasEQ.SetActive(true);
            canvas.SetActive(true);
            pointLight.SetActive(false);
            transform.position = new Vector2(-12.05f, -0.94f);
        }
        if (SceneManager.GetActiveScene().name == "Boss Ice")
        {
            canvasEQ.SetActive(true);
            canvas.SetActive(true);
            pointLight.SetActive(false);
            transform.position = new Vector2(40.49f, -3.65f);
        }
        if (SceneManager.GetActiveScene().name == "Volcano")
        {
            canvasEQ.SetActive(true);
            canvas.SetActive(true);
            pointLight.SetActive(false);
            transform.position = new Vector2(17.52f, 4.2f);
        }
        if (SceneManager.GetActiveScene().name == "Boss Volcano")
        {
            canvasEQ.SetActive(true);
            canvas.SetActive(true);
            pointLight.SetActive(false);
            transform.position = new Vector2(-14.51f, 3.1f);
        }
    }
    void Awake()
    {
        
        isUsingSword = true;
        weapon01.SetActive(true); //slot miecza
        bullet.SetActive(false); //strzala
        weapon02.SetActive(false); //slot luku

        //Singleton
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }


    }

    void Start()
    {
       // jumpHeight = RemoteSettings.GetFloat("JumpHeight");
        isAlive = true;
        RB = GetComponent<Rigidbody2D>(); //szuka assetów
        Animacja = GetComponent<Animator>();//-||-
        facingRight = true;
        selectorHandler = GetComponentInChildren<EquipmentController>().SelectorHandler;


        selectorHandler.OnSelectingItem += SelectorHandler_OnSelectingItem;

        // new
        gravityStore = 1f;
        gravityStore = RB.gravityScale;
    }

    /// <summary>
    /// This is logic for selecting item. Whenever one of equipment node is selected this will listen to it
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SelectorHandler_OnSelectingItem(object sender, EquipmentPanelNode e)
    {
        selectedItem = e.StoredItem ?? new GameObject();
    }

    //Update jest do skoku i strzelania
    void Update()
    {
        if (grounded && Input.GetAxis("Jump") > 0) //czy wcisniety button
        {
            isRunning = false;
            grounded = false;
            Animacja.SetBool("isGrounded", grounded);
            RB.AddForce(new Vector2(0, jumpHeight)); //mozliwosc ruchu w powietrzu
        }

        if (RB.velocity.y < 0)
        {
            RB.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (RB.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            RB.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        if (!(selectedItem is null || selectedItem.GetComponent<IEquipable>() is null) && selectedItem.GetComponent<IEquipable>() is Sword)
        {
            //żeby ustawić dmg broni to po prostu przypisz go z selected item:
            weaponDamage = (selectedItem.GetComponent<IEquipable>() as Sword).Multiplier;
            //ps. zmieniany jest sprite broni, trzymanej w ręcę i na prawdę nie wiem, jak to ogarnąć aby on się łądnie ustawiał (Nie jestem programistą unity XD)
            isUsingSword = true;
            isUsingBow = false;
            weapon01.GetComponent<SpriteRenderer>().sprite = selectedItem.GetComponent<SpriteRenderer>().sprite;
            //weapon01 = selectedItem;
            weapon01.SetActive(true);
            bullet.SetActive(false);
            weapon02.SetActive(false);

            //Debug.Log("Uzywasz miecza");
        }

        if (bullet && !(selectedItem is null || selectedItem.GetComponent<IEquipable>() is null) && selectedItem.GetComponent<IEquipable>() is Bow)
        {
            weaponDamage = (selectedItem.GetComponent<IEquipable>() as Bow).Multiplier;
            isUsingSword = false;
            isUsingBow = true;
            weapon01.SetActive(false);
            bullet.SetActive(true);
            weapon02.SetActive(true);
            //weapon02 = selectedItem;
            weapon02.GetComponent<SpriteRenderer>().sprite = selectedItem.GetComponent<SpriteRenderer>().sprite;

            //Debug.Log("Uzywasz luku");
        }


    }

    // Update is called once per frame
    void FixedUpdate() //fizyka zawsze przez FIXED
    {
        //start skoku, if grounded(zaznaczyc warstwy i collider), jak nie = fall
        if (grounded == false)
        {
            isRunning = false;
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
            Animacja.SetBool("isGrounded", grounded);
        }
        if (onLadder)
        {
            RB.gravityScale = 1f;
            climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");
            RB.velocity = new Vector2(RB.velocity.x, climbVelocity);
        }
        if (!onLadder)
        {
            RB.gravityScale = 1f;
        }
        //Animacja.SetFloat("verticalSpeed", RB.velocity.y); //klatka po klatce

        //koniec skoku

        float move = Input.GetAxis("Horizontal"); // edit->project settings->input
                                                  //czyli WSAD;
        float move2 = Input.GetAxis("Vertical");


        Animacja.SetFloat("speed", Mathf.Abs(move));//absolut value

        
        

        RB.velocity = new Vector2(move * maxSpeed, RB.velocity.y); //jak nie naciskasz to 0;

        if (Animacja.GetFloat("speed") > 0 && grounded == true)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        if (move > 0 && !facingRight)
        {
            flip();
        }
        else if (move < 0 && facingRight)
        {
            flip();
        }

        void flip()
        {
            if (isAlive == true)
            {
                facingRight = !facingRight;
                Vector3 theScale = transform.localScale;
                theScale.x *= -1; //x pomnoz razy -1, czyli odwroc;
                transform.localScale = theScale;
            }
            else
            {
                return;
            }
        }

        void Attack()
        {
            if (isUsingSword == true && isUsingBow == false)

            {
                Animacja.SetTrigger("Attack");



                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);



                foreach (Collider2D enemy in hitEnemies)
                {
                    if (enemy.tag == "Enemy")
                    {
                        enemy.GetComponent<enemyHealth>().meleeDamage(attackDamage);
                    }
                    else if (enemy.tag == "Boss")
                    {
                        enemy.GetComponent<BossHealth>().meleeDamage(attackDamage);
                    }
                }
            }
        }


        /*void fireBall()
        {
            if (Time.time > nextBall)
            {
                nextBall = Time.time + ballRate;
                if (facingRight)
                {
                    Instantiate(ball, magicTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                }
                else if (!facingRight)
                {
                    Instantiate(ball, magicTip.position, Quaternion.Euler(new Vector3(150, 0, 180f)));//ZAxis 180 stopni

        }*/

        if (Input.GetKeyDown(KeyCode.Mouse0) && fireRate > 0 && isUsingBow == true && grounded == true)
        {
            Animacja.SetTrigger("Fire");
        }
        //if (Input.GetAxisRaw("Fire1") > 0) fireRocket();


        if (Input.GetKeyDown(KeyCode.Mouse0) && isUsingBow == false && grounded == true)
        {
            Attack();
        }

        //if (Input.GetAxisRaw("Fire2") > 0) Attack();

        /*if (Input.GetAxisRaw("Fire1") > 0) fireBall();*/

    }
    public void fireRocket()
    {
        if (isUsingBow == true && isUsingSword == false)
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                if (facingRight)
                {
                    Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                }
                else if (!facingRight)
                {
                    Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(150, 0, 180f)));//ZAxis 180 stopni

                }
            }
        }
    }
    /// <summary>
    /// When weapon is dropped
    /// </summary>
    /// <param name="sprite"></param>
    private void WeaponDestroy(Sprite sprite)
    {
        weaponDamage = 0;
        Sprite.Destroy(sprite);
        selectedItem = null;

    }
}
