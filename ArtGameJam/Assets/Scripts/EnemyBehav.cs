using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehav : MonoBehaviour
{
    public Transform target;
    public bool isDetected;
    public float speed = 5f;
    public Vector3 lastPosition;
    public float maxDistance;
    public Animator anim;
    public GameObject bloodEffect;
    EnemyHealth enemyHealth;
    private void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();
    }

    private void Start()
    {
        isDetected = false;
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        if (isDetected)
        {
            FollowPlayer();            
        }
        else
        {
            isDetected = false;
            
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Light")
        {
            isDetected = true;
        }
        if (other.tag == "Player")
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            playerHealth.ApplyDamage("enemy", 20f);
            GameObject particle = Instantiate(bloodEffect, this.transform.position,Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(particle, 1f);
        }
    }
   

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Light")
        {
            isDetected = false;
        }
    }
    public void FollowPlayer()
    {
        if (!enemyHealth.isDead)
        {
            if (Vector2.Distance(this.transform.position, target.position) >= maxDistance)
            {
                this.transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -0.2f);
            }
        }
        
    }
}
