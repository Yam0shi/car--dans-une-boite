using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Component : ")]
    [SerializeField] Rigidbody2D myRb2d;

    [Header("Objet � r�cup�rer : ")]
    [SerializeField] GameObject theBox;
    [SerializeField] GameObject[] playerWalk;

    [Header("Stats : ")]
    [Range(0f, 20f)]
    public float speed;

    public int life = 3;
    public bool lifetransition;

    [Header("autre : ")]
    [SerializeField] bool CanMove;
    public GameObject dedSFX;
    private static Player instance;

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

    public static Player GetInstance()
    {
        return instance;
    }

    void Start()
    {
        lifetransition = false;
        CanMove = true;
        myRb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
      
        if(theBox == null)
        {
            Debug.Log(SceneManager.sceneCountInBuildSettings);
            theBox = GameObject.Find("theBox");
        }
        if(theBox != null)
        {

        }

        if (CanMove)
        {
            PlayerMove();
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
        if (collision.gameObject.CompareTag("MenuGround"))
        {
            CanMove = false;
        }

        if (collision.gameObject.CompareTag("it's a trap"))
        {
            StartCoroutine(Dead());
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
        if (life == 0)
        {
            CanMove = false;
            lifetransition = true;
            Instantiate(dedSFX, transform.position, transform.rotation);
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
            transform.GetChild(0).gameObject.SetActive(false);

            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene(2);
        }
        else
        {
            life--;
            lifetransition = true;
            transform.position = Vector3.zero;

            if (LevelBehavior.GetInstance().transform.childCount == 5)
            {
                Destroy(LevelBehavior.GetInstance().transform.GetChild(4).gameObject);
                LevelBehavior.GetInstance().Reset();
            }
            else
            {
                LevelBehavior.GetInstance().WallAppear();
            }

            yield return new WaitForSeconds(2f);
            lifetransition = false;
        }
    }
}
