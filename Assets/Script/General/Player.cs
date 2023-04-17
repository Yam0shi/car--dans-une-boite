using System.Collections;
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
    [SerializeField] bool CanMove;
    [SerializeField] bool deadOfTheGrave;
    public GameObject dedSFX;
    private bool isded;

    void Start()
    {
        isded = false;
        CanMove = true;
        deadOfTheGrave = false;
        myRb2d = GetComponent<Rigidbody2D>();
        theBox = GameObject.Find("theBox");
    }

    void Update()
    {
        if (!isded)
        {
            if (deadOfTheGrave)
            {
                StartCoroutine(Dead());
            }
            else if(CanMove)
            {
                PlayerMove();
            }
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
        if(collision.gameObject.layer == 3)
        {
            CanMove = true;
        }

        if (collision.gameObject.CompareTag("it's a trap"))
        {
            Debug.LogWarning("gestion de la vie pas encore fait");
        }

        if (collision.gameObject.CompareTag("killzone"))
        {
            deadOfTheGrave = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Item"))
        {
            Points.AddPoint(1);
            Destroy(collision.gameObject);
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

    public IEnumerator Dead()
    {
        isded = true;
        Instantiate(dedSFX, transform.position, transform.rotation);
        GetComponent<SpriteRenderer>().color = new Color (255, 255, 255, 0);

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }
}
