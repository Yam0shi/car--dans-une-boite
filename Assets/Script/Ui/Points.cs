using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
     public static int  GoldOfKinzo;
    [SerializeField] TextMeshProUGUI epitaph;
    void Start()
    {
        GoldOfKinzo = PlayerPrefs.GetInt("GoldOfKinzoHidden");
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
