using UnityEngine;
using UnityEngine.UI;

public class Skin : MonoBehaviour
{
    [SerializeField] GameObject saveSkinbuy, Player;
    [SerializeField] bool buyBool;
    [SerializeField] int etatDachat;
    [SerializeField] int buttonIndex;
    [SerializeField] AudioClip buyAC, useAC;
    private AudioSource aS;

    public void Start()
    {
        aS = GameObject.Find("Player").GetComponent<AudioSource>(); ;

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
            PlayerPrefs.SetInt("étatDuBooléen" + buttonIndex, 1);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            saveSkinbuy.GetComponent<SaveSkin>().SkinBought[buttonIndex] = gameObject.GetComponent<Image>().sprite;
            Debug.Log("skin n°"+buttonIndex +" : " + PlayerPrefs.GetInt("étatDuBooléen" + buttonIndex));
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

                aS.PlayOneShot(buyAC);
            }
        }
    }

    public void UseSkin()
    {
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        Player.GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<Image>().sprite;

        aS.PlayOneShot(useAC);
    }
}
