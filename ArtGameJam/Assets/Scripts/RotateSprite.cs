using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSprite : MonoBehaviour {

    [SerializeField]
    private int angle;
	void Update ()
    {
        this.transform.Rotate(0f, 0f, angle);
	}
}
