using UnityEngine;

public class SaveSkin : MonoBehaviour
{
    public Sprite[] SkinBought;
    private static SaveSkin instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            Debug.LogError("Found more than one input system in the scene manager.");
        }
        instance = this;
        DontDestroyOnLoad(instance);
    }

    public static SaveSkin GetInstance()
    {
        return instance;
    }
    private void Update()
    {
        DontDestroyOnLoad(gameObject);

        if (Input.GetKey(KeyCode.Backspace))
        {
            Points.AddPoint(1);
        }
    }
}
