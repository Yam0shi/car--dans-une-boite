using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skin : MonoBehaviour
{
    [SerializeField] GameObject saveSkinbuy;
    public bool buyBool;

    void Start()
    {
        
    }

    void Update()
    {

    }

    public void BuySkin(int needValue)
    {

        if (!buyBool)
        {
            if (Points.GoldOfKinzo >= needValue)
            {
                Points.GoldOfKinzo -= needValue;
                print(Points.GoldOfKinzo);
                PlayerPrefs.SetInt("GoldOfKinzoHidden", Points.GoldOfKinzo);
                buyBool = true;
            }
        }
    }

    public void SetIndex(int buttonIndex)
    {
        if(buyBool == true)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            saveSkinbuy.GetComponent<SaveSkin>().SkinBought[buttonIndex] = gameObject.GetComponent<Image>().sprite;
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void UseSkin()
    {
      gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }
}
