using TMPro;
using UnityEngine;

public class SaveSkin : MonoBehaviour
{
    public Sprite[] SkinBought;
    private static SaveSkin instance;

    public static SaveSkin GetInstance()
    {
        return instance;
    }
}
