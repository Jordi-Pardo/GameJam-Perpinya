using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehav : MonoBehaviour
{
    public static PlayerBehav Instance;
    
    public Rigidbody2D rb;
    public float speed = 30f;
    public float delayAction;
    public float delayActionTime;
    public GameObject lightObject;
    public Light spotLight;
    public float t;
    public bool enable = false;
    public bool isDead = false;
    bool greenLightActivated = false;
    public Color greenColor;
    private bool firstRadar = true;

    public List<EnemyBehav> enemyList = new List<EnemyBehav>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {

        delayAction = delayActionTime;
        greenColor = new Color32(85, 207, 85, 25);
        rb = GetComponent<Rigidbody2D>();
        spotLight = lightObject.GetComponent<Light>();
        spotLight.color = Color.white;

    }
    private void Update()
    {     
        ShowEnemies();
        if(!isDead){
            ActivateGreenLantern();
            Mirar_raton();
            MovePlayer();
        }
    }
    private void MovePlayer()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector3(x, z, 0f).normalized * speed;

    }

    void Mirar_raton()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direccion =  new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direccion;
    }
    
    public void ShowEnemies()
    {
        if (delayAction < delayActionTime)
        {
            delayAction += Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space) && delayAction >= delayActionTime || Input.GetKeyDown(KeyCode.Space) && firstRadar)
        {
            delayAction = 0f;
            float delay = 0f;
            firstRadar = false;
           
            foreach (EnemyBehav enem in enemyList)
            {
                
                enem.anim.SetTrigger("isEnabled");
                delay += 0.3f;
            }
        }

    }

    public void ActivateGreenLantern()
    {        

        if (Input.GetMouseButtonDown(0))
        {
            greenLightActivated = true; //se necesita para la función OnTriggerEnter
            t = 0f;
            enable = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            greenLightActivated = false;
            t = 0f;
            enable = false;
            
        }
        if (enable)
        {
            spotLight.color = Color.Lerp(Color.white, greenColor, t);
        }
        else if (!enable)
        {
            spotLight.color = Color.Lerp(greenColor, Color.white, t);
        }
        
        if (t < 1)
        { // while t below the end limit...
          // increment it at the desired rate every update:
            t += Time.deltaTime;
        }       
       
        }
 
    void OnTriggerStay2D(Collider2D other)
        {
        EnemyHealth enemyHealth;
        if(other.tag == "Enemy")
        {
            enemyHealth = other.GetComponent<EnemyHealth>();

            if (greenLightActivated && enemyHealth.contador < 4)
            {

                if (other.gameObject.tag == "Enemy")
                {
                    StartCoroutine(enemyHealth.TakeDamage(other));
                }
            }
        }

            
        }
}