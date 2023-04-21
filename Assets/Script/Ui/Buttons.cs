using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] GameObject SkinScreen, player, skinButon;
    [SerializeField] EventSystem myEventSystem;
    [SerializeField] Player playerScript;

    private void Start()
    {
        player = GameObject.Find("Player");

        if (SceneManager.GetActiveScene().buildIndex != 2)
        {
            playerScript = player.GetComponent<Player>();
            playerScript.life = 3;
            playerScript.currentmoney = 0;
            player.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            player.transform.GetChild(0).gameObject.SetActive(true);
            playerScript.lifetransition = false;
        }

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            playerScript.CanMove = false;
            player.transform.position = new Vector3(3, -2.5f, 0);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            playerScript.CanMove = true;
            player.transform.position = Vector3.zero;
        }

    }

    private void Update()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void SkinShopOpening()
    {
        SkinScreen.SetActive(true);
        player.SetActive(false);
    }
    public  void SkinShopExit()
    {
        SkinScreen.SetActive(false);
        myEventSystem.SetSelectedGameObject(skinButon);
        player.SetActive(true);
    }

}
