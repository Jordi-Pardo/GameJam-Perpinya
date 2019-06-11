using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPosition : MonoBehaviour
{
    public Vector2 mousePosition;
    public Transform player;

    void Update()
    {

        mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        this.transform.position = player.position + new Vector3(ray.direction.x * 10,player.position.y, ray.direction.z * 10f);
        Debug.DrawRay(ray.origin, ray.direction * 1, Color.yellow);
    }

    
}
