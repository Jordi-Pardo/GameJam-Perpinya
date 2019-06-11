using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 100;
    public int contador;
    public float time;
    public bool isDead = false;
    public RipplePostProcess ripple;
    public GameObject particle;

    EnemyBehav enemyBehav;
    void Awake()
    {
        time = 0f;
        contador = 0;
        enemyBehav = GetComponent<EnemyBehav>();
        ripple = Camera.main.GetComponent<RipplePostProcess>();
    }
    void Update()
    {
        CheckHealthStatus();
        //EnemyDie();
    }

    private void EnemyDie()
    {
        if (isDead == true)
        {
            if (PlayerBehav.Instance.enemyList.Contains(enemyBehav))
            {
                PlayerBehav.Instance.enemyList.Remove(enemyBehav);
            }

            GameObject particle = Instantiate(enemyBehav.bloodEffect, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(particle, 1f);
            ripple.RippleEffect();

        }
    }


    public void ApplyDamage(string who, float Damage) //Quien le quita vida y la cantidad que le quita
    {
        if(who=="acid")
        {
            enemyHealth -= Damage * Time.deltaTime;  //Le quita "Damage" vida por segundo. El valor de "Damage" lo pone el script Acid.cs o PlayerBehav.cs
            EmitParticle();
        }

            
    }
    void CheckHealthStatus()
    {
        if(enemyHealth <=0)
        {
            isDead = true;
            PlayerBehav.Instance.enemyList.Remove(enemyBehav);
        }
        else
        {
            isDead = false;
        }
    }

    public IEnumerator TakeDamage(Collider2D collider2D)
    {
        time += Time.deltaTime;
        
        while (time < 1f)
        {
            yield return null;
        }
        time = 0f;
        contador++;
        float enemyFromPlayerDamage = 25;
        this.enemyHealth -= enemyFromPlayerDamage;
        Debug.Log(enemyHealth);
        CheckHealthStatus();
        EmitParticle();
        ripple.RippleEffect();


        if (isDead)
        {
            EnemyDie();
        }

        
        

    }
    public void EmitParticle()
    {
        GameObject instance = Instantiate(particle, this.transform.position, Quaternion.identity);
        Destroy(instance, 1.5f);
    }
}
