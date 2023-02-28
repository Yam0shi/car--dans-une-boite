using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [Header("Component : ")]
    [SerializeField] Rigidbody2D myRb2d;

    [Header("Objet à récupérer : ")]
    [SerializeField] GameObject theBox;

    [Header("Animation Bleh : ")]
    public Animator disney;
    [SerializeField] int dirIndex;

    [Header("Stats : ")]
    [Range(0f, 20f)]
    public float speed;
    private bool hastriggered;

    [SerializeField] bool CanMove;

    void Start()
    {
        myRb2d = GetComponent<Rigidbody2D>();
        theBox = GameObject.Find("theBox");
    }

    void Update()
    {
        TheBoxMove();
        if(CanMove)
        {
            PlayerMove();
        }
    }

    void PlayerMove()
    {
        float AxisX = Input.GetAxis("Horizontal") * speed;
        myRb2d.velocity = AxisX * Vector3.right;
    }

    void TheBoxMove()
    {
        if (Input.GetAxis("Left Trigger") < 0.1 && Input.GetAxis("Right Trigger") < 0.1)
        {
            hastriggered = false;
        }

        if (Input.GetAxis("Left Trigger") >= 0.1/* && !hastriggered*/)
        {
            Debug.Log("gauche");
            theBox.transform.Rotate(0, 0, 90 * Time.deltaTime);
            hastriggered = true;
        }

        if (Input.GetAxis("Right Trigger") >= 0.1/* && !hastriggered*/)
        {
            Debug.Log("droite");
            theBox.transform.Rotate(0, 0, -90 * Time.deltaTime);
            hastriggered = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == theBox)
        {
            CanMove = true;
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
