using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Points : MonoBehaviour
{
     static int  GoldOfKinzo;
    [SerializeField] TextMeshProUGUI epitaph;
    void Start()
    {
        GoldOfKinzo = PlayerPrefs.GetInt("GoldOfKinoHidden");
    }

    void Update()
    {
        epitaph.text = GoldOfKinzo.ToString("00");
    }
   public static  int AddPoint(int value)
    {
        GoldOfKinzo += value;
        PlayerPrefs.SetInt("GoldOfKinzoHidden", GoldOfKinzo);

        return GoldOfKinzo;
    }
}
