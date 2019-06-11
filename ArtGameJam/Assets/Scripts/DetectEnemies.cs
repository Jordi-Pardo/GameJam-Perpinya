using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemies : MonoBehaviour {



    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBehav enemyBehav = collision.GetComponent<EnemyBehav>();
        if (collision.tag == "Enemy" && !PlayerBehav.Instance.enemyList.Contains(enemyBehav))

        {

            PlayerBehav.Instance.enemyList.Add(collision.GetComponent<EnemyBehav>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            EnemyBehav enemyBehav = collision.GetComponent<EnemyBehav>();
            if (PlayerBehav.Instance.enemyList.Contains(enemyBehav))
            {
                PlayerBehav.Instance.enemyList.Remove(enemyBehav);
            }
        }
    }
}
