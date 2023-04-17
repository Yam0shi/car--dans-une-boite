using UnityEngine;

public class SaveSkin : MonoBehaviour
{
    public Sprite[] SkinBought;

    private void Update()
    {
        DontDestroyOnLoad(gameObject);

        if (Input.GetKey(KeyCode.Backspace))
        {
            Points.AddPoint(1);
        }
    }
}
