using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] GameObject SkinScreen, player, skinButon;
    [SerializeField] EventSystem myEventSystem;
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
