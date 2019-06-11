using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mENU : MonoBehaviour {
    Button play;
    Button exit;
	// Use this for initialization
	void Start () {
        play = GetComponent<Button>();
        exit = GetComponent<Button>();
	}
	
	// Update is called once per frame
	public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Muerte()
    {
        SceneManager.LoadScene(1);
    }
}
