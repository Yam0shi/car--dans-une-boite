using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] GameObject SkinScreen, player;
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
        player.SetActive(true);
    }
}
