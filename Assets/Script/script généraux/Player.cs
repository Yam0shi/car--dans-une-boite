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
    [SerializeField] GameObject[] playerWalk;

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
        if(Input.GetAxis("Horizontal") > 0.1f)
        {
            playerWalk[0].SetActive(true);
            playerWalk[1].SetActive(false);
        }
        else if (Input.GetAxis("Horizontal") < -0.1f)
        {
            playerWalk[0].SetActive(false);
            playerWalk[1].SetActive(true);
        }
        else if (Input.GetAxis("Horizontal") >  -0.07f  && Input.GetAxis("Horizontal") < 0.07f)
        {
            playerWalk[0].SetActive(false);
            playerWalk[1].SetActive(false);
        }
    }

    #region(gestion des collision avec le joueur)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == theBox)
        {
            CanMove = true;
        }

        if(collision.gameObject.CompareTag("it's a trap"))
        {
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
    #endregion
}
