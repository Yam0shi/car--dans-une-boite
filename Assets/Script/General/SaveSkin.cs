using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSkin : MonoBehaviour
{
    public Sprite[] SkinBought;
    void Update()
    {
        DontDestroyOnLoad(gameObject);

        if (Input.GetKey(KeyCode.Backspace))
        {
            Points.AddPoint(1);
        }
    }
}
