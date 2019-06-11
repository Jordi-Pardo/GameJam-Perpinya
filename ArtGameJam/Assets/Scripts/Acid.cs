using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour {


	float acidToPlayer = 15;
	float acidToEnemy = 40;

	// Use this for initialization
	void Awake () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnTriggerStay2D(Collider2D other) //Mientras estén en contacto...
	{
		PlayerHealth playerController = other.GetComponent<PlayerHealth>();
		EnemyHealth enemyController = other.GetComponent<EnemyHealth>();
		if(other.gameObject.tag == "Enemy")
		{
			enemyController.ApplyDamage("acid", acidToEnemy);
		}
		if(other.gameObject.tag == "Player")
		{
			playerController.ApplyDamage("acid", acidToPlayer);
		}
	}
}
