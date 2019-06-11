using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public static PlayerHealth Instance;
    public GameObject particleEffect;
    public float playerHealth = 100;
    float acidDamage = 75;
    float enemyDamage = 25;
    public Image blod;
    public AudioSource cancionFondo;


    void Awake ()
    {
        Instance = this;

    }
    private void Start()
    {
        Cursor.visible =false;
        blod.gameObject.SetActive(false);
        cancionFondo.Play();
       // blod.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        CheckHealthStatus();
        MusicSpeed();
        if (playerHealth == 100)
        {
            blod.gameObject.SetActive(false);
        }
        if(PlayerBehav.Instance.isDead == true){
            SceneManager.LoadScene(2);
            Cursor.visible=true;
        }
    }
	public void ApplyDamage(string who, float Damage)
	{
        if(who=="acid")
        {
            playerHealth -= Damage * Time.deltaTime;  //Le quita "Damage" vida por segundo. El valor de "Damage" lo pone el script Acid.cs o EnemyController.cs 
        }
        if(who=="enemy")
        {
            playerHealth -= Damage;
            Debug.Log(playerHealth);
        }

        GameObject instance = Instantiate(particleEffect, this.transform.position, Quaternion.identity);
        Destroy(instance, 1f);
        CheckHealthStatus();
	}
    void CheckHealthStatus()
    {
        if(playerHealth <=0)
        {
            PlayerBehav.Instance.isDead = true;
            Cursor.visible = true;
        }
        else
        {
            PlayerBehav.Instance.isDead = false;
        }
    }
    void MusicSpeed()
    {
        if (playerHealth < 100)
        {
            blod.gameObject.SetActive(true);
            cancionFondo.pitch = 3; //cuando el personaje recibe daño, aumenta x3 el ritmo de la musica
        }
        else
        {
            cancionFondo.pitch = 1; //cuando tiene toda la vida vuelve a la normalidad;
        }
    }


}
