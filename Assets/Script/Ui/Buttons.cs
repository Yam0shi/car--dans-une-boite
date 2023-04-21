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

    private void Update()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }
        if (SkinScreen != null)
        {
            player.transform.position = new Vector3(3, -1, 0);
            playerScript = player.GetComponent<Player>();
            playerScript.life = 3;
            player.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
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
