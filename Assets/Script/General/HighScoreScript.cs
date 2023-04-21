using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreScript : MonoBehaviour
{
    public static int BestScore;
    [SerializeField] TextMeshProUGUI BestScoreTxt;
    void Start()
    {
        BestScore = PlayerPrefs.GetInt("bestScoreSaving");
        Debug.Log(BestScore);
    }

    void Update()
    {
        BestScoreTxt.text = BestScore.ToString("000");
    }
    public static int UpdateHighScore(int value)
    {
        if(value > BestScore)
        {
            BestScore = value;
        }
        PlayerPrefs.SetInt("bestScoreSaving", BestScore);

        return BestScore;
    }
}
