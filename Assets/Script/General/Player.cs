using System.Collections;
using TMPro;
using UnityEditor;
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

    public int life = 3;
    public bool lifetransition;

    [Header("Audio : ")]
    public AudioClip hurtAC;
    public AudioClip deathAC;
    public AudioClip moneyAC;
    private AudioSource aS;

    [Header("autre : ")]
    public bool CanMove;
    public GameObject dedSFX;
    public GameObject hurtSFX;
    public GameObject moneySFX;
    public int currentmoney;
    private static Player instance;
    public static int bestScore;
    [SerializeField] TextMeshProUGUI BestScoreTxt;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
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
        myRb2d = GetComponent<Rigidbody2D>();
        aS = GetComponent<AudioSource>();
        PlayerPrefs.GetInt("bestScoreSaving");
    }

    void Update()
    {
        if(BestScoreTxt == null)
        {
            BestScoreTxt = GameObject.Find("HighScoreTxt").GetComponent<TextMeshProUGUI>();
        }
        BestScoreTxt.text = bestScore.ToString("000");

        if (theBox == null)
        {
            theBox = GameObject.Find("theBox");
            myRb2d.gravityScale = 0;
        }
        if(theBox != null)
        {
            myRb2d.gravityScale = 100;
        }

        if (GetComponent<SpriteRenderer>().color == new Color(255, 255, 255, 0))
        {
            myRb2d.gravityScale = 0;
            myRb2d.velocity = Vector3.zero;
            CanMove = false;
        }

        if (CanMove)
        {
            PlayerMove();
        }
        else
        {
            playerWalk[0].SetActive(false);
            playerWalk[1].SetActive(false);
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
            StartCoroutine(InstantiateSFX(moneySFX));
            currentmoney++;
            aS.PlayOneShot(moneyAC);
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
        life--;
        lifetransition = true;

        if (LevelBehavior.GetInstance().transform.childCount == 5)
        {
            Destroy(LevelBehavior.GetInstance().transform.GetChild(4).gameObject);
            LevelBehavior.GetInstance().Reset();
        }
        else
        {
            LevelBehavior.GetInstance().WallAppear();
        }

        if (life <= 0)
        {
            aS.PlayOneShot(deathAC);
            CanMove = false;
            StartCoroutine(InstantiateSFX(dedSFX));
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
            transform.GetChild(0).gameObject.SetActive(false);

            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene(2);
        }
        else
        {
            aS.PlayOneShot(hurtAC);
            StartCoroutine(InstantiateSFX(hurtSFX));
            transform.position = Vector3.zero;

            yield return new WaitForSeconds(2f);
        }

        lifetransition = false;
    }

    private IEnumerator InstantiateSFX(GameObject sfx)
    {
        GameObject clonesfx = Instantiate(sfx, transform.position, transform.rotation);
        yield return new WaitForSeconds(1f);
        Destroy(clonesfx);
    }

}
