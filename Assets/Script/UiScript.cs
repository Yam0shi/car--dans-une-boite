using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiScript : MonoBehaviour
{
    [Header("TimeToSurviving :")]
    [SerializeField] TMP_Text survivingTimeTxt, bestSurvivingTimeTxt;
    [SerializeField] int secondes, bestSecondes, minutes, bestMinutes, heures, bestHeure, speedTime;
    [SerializeField] float timer;
    [SerializeField] string milis, bestMilis;

    void Start()
    {
        survivingTimeTxt = GameObject.Find("survivingTime").GetComponent<TMP_Text>();
        bestSurvivingTimeTxt = GameObject.Find("BestSurvivingTime").GetComponent<TMP_Text>();
        
        secondes = 0;
        minutes = 0;
        heures = 0;
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime * speedTime;
        TimeOfYourSurvive();
    }

    void Update()
    {
            
    }

    void TimeOfYourSurvive()
    {
        if (timer <= 0)
            timer = 0;

        heures = (int)timer / 120;
        minutes = (int)timer / 60;
        secondes = (int)timer - minutes * 60;
        milis = timer.ToString("f2").Split(',')[1];

        if (bestSecondes < secondes)
        {
            bestSecondes = secondes;
        }
        if (bestMinutes < minutes)
        {
            bestMinutes = minutes;
        }
        if (bestHeure < heures)
        {
            bestHeure = heures;
        }

        survivingTimeTxt.text = heures.ToString("00") + ":" + minutes.ToString("00") + ":" + secondes.ToString("00") + ":" + milis;
        bestSurvivingTimeTxt.text = bestHeure.ToString("00") + ":" + bestMinutes.ToString("00") + ":" + secondes.ToString("00") + ":" + milis;
        PlayerPrefs.Save();
    }
}
