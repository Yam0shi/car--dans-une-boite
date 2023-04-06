using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skin : MonoBehaviour
{
    [SerializeField] Button[] skinButtonRef;
    void Start()
    {
        
    }

    void Update()
    {

    }

    public void ByuSkin(int needValue)
    {
        if (Points.GoldOfKinzo >= needValue)
        {
            Points.GoldOfKinzo -= needValue;
            print(Points.GoldOfKinzo);
        }
    }

    public void SetIndex(int buttonIndex)
    {
        gameObject.transform.GetChild(buttonIndex).gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

}
