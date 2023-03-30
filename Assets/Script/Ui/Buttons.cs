using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] GameObject SkinScreen;
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
    }
    public  void SkinShopExit()
    {
        SkinScreen.SetActive(false);
    }
}
