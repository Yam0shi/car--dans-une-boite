using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Component : ")]
    [SerializeField] Rigidbody2D myRb2d;

    [Header("Objet à récupérer : ")]
    [SerializeField] GameObject theBox;

    [Header("Stats : ")]
    [Range(0f, 20f)]
    public float speed;

    [Header("autre : ")]
    [SerializeField] bool CanMove, deadOfTheGrave;

    void Start()
    {
        deadOfTheGrave = false;
        myRb2d = GetComponent<Rigidbody2D>();
        theBox = GameObject.Find("theBox");
    }

    void Update()
    {
        if(CanMove)
        {
            PlayerMove();
        }
        if(deadOfTheGrave)
        {
            SceneManager.LoadScene(2);
        }
    }

    void PlayerMove()
    {
        float AxisX = Input.GetAxis("Horizontal") * speed;
        myRb2d.velocity = AxisX * Vector3.right;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == theBox)
        {
            CanMove = true;
        }

        if(collision.gameObject.CompareTag("it's a trap"))
        {
            Destroy(gameObject);
            deadOfTheGrave = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == theBox)
        {
            CanMove = false;
        }
    }
}
