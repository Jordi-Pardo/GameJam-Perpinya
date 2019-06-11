using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoodCell : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerHealth.Instance.playerHealth = 100f;
            Debug.Log(PlayerHealth.Instance.playerHealth);
            Destroy(this.gameObject);
        }
    }

}
