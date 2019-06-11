using UnityEngine;
using System.Collections;


public class TexturaMov : MonoBehaviour
{

    //declarando vbles que necesitamos
    public Material materialFloor;//material para trabajar con el suelo del juego
    public float scrollSpeed = 0.03f;//velocidad con la que moveremos el suelo
    public Renderer rend;
   

    void Start()
    {
        rend = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.mainTextureOffset = new Vector2(0, offset);


    }

}