using UnityEngine;
using UnityEngine.UI;

public class Skin : MonoBehaviour
{
    [SerializeField] GameObject saveSkinbuy;
    public bool buyBool;
    public float etatDachat;
    public int buttonIndex;

    public void Start()
    {
        etatDachat = PlayerPrefs.GetInt("étatDuBooléen"+buttonIndex);

        if(etatDachat == 1)
        {
            buyBool = true;
        }
    }
    public void Update()
    {
        if (buyBool)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
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

    public void SetIndex()
    {
        if(buyBool == true)
        {
            PlayerPrefs.SetInt("étatDuBooléen" + buttonIndex, 1);
            Debug.Log(PlayerPrefs.GetInt("étatDuBooléen" + buttonIndex));
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
