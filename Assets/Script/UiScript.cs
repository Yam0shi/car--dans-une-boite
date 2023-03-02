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

        bestHeure = PlayerPrefs.GetInt("BestHeureSave");
        bestMinutes = PlayerPrefs.GetInt("BestMinuteSave");
        bestSecondes = PlayerPrefs.GetInt("BestSecondesSave");
        Debug.Log(bestSurvivingTimeTxt.text);

        secondes = 0;
        minutes = 0;
        heures = 0;
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime * speedTime;
        TimeOfYourSurvive();
    }

    void TimeOfYourSurvive()
    {
        #region(updateScore)
        if (timer <= 0)
            timer = 0;

        heures = (int)timer / 3600;
        minutes = (int)timer / 60;
        secondes = (int)timer - minutes * 60;
        milis = timer.ToString("f2").Split(',')[1];
        #endregion

        #region(updateHighScore)
        if (bestHeure == heures)
        {
            if (bestMinutes == minutes)
            {
                
                if (secondes >= bestSecondes)
                {
                    bestSecondes = secondes;
                }
            } 
            else if (minutes > bestMinutes)
            {
                bestMinutes= minutes;
                bestSecondes = 0;
            }
        } 
        else if (heures > bestHeure)
        {
            bestHeure= heures;
            bestMinutes= 0;
            bestSecondes= 0;
        }
        #endregion

        survivingTimeTxt.text = heures.ToString("00") + ":" + minutes.ToString("00") + ":" + secondes.ToString("00");
        bestSurvivingTimeTxt.text = bestHeure.ToString("00") + ":" + bestMinutes.ToString("00") + ":" + bestSecondes.ToString("00");

        Debug.Log("setSave");
        PlayerPrefs.SetInt("BestHeureSave", bestHeure);
        PlayerPrefs.SetInt("BestMinuteSave", bestMinutes);
        PlayerPrefs.SetInt("BestSecondesSave", bestSecondes);

    }
}
