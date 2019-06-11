using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public float radarAmount;
    public float heartAmount;
    public Image heart;
    public Image radar;

    private void Awake()
    {
        Instance = this;
        heartAmount = 1f;
    }
    private void Update()
    {
        FillRadar();
        FillHeart();
    }

    public void FillRadar()
    {

            radarAmount = PlayerBehav.Instance.delayAction / PlayerBehav.Instance.delayActionTime;
            radar.fillAmount = radarAmount;
        
    }

    public void FillHeart()
    {
        
        heartAmount = Mathf.Lerp(heart.fillAmount,PlayerHealth.Instance.playerHealth/100,1f);

    }



}
