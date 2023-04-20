using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UI;

public class LevelBehavior : MonoBehaviour
{
    public static LevelBehavior instance;

    public LevelPattern[] prefabs;
    private bool gonnatuto;
    public int randomPatern;
    public int[] randomRotation;

    public int roomNumber;

    public Vector2[] speed;
    public int currentSpeed;

    public GameObject player;

    public Animator UIAnimator;
    public TextMeshProUGUI scoretext;


    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance TrapGeneration script.");
        }

        instance = this;
    }

    private void Start()
    {
        gonnatuto = true;
        roomNumber = 0;
        currentSpeed = 0;
        player = GameObject.Find("Player");

        StartCoroutine(RandomizerSpawnTrap());
    }

    public static LevelBehavior GetInstance()
    {
        return instance;
    }


    public void Update()
    {
        if (roomNumber != speed.Length &&  roomNumber == (int)speed[currentSpeed].y)
        {
            currentSpeed++;
            gonnatuto = true;
        }
    }
    
    public IEnumerator RandomizerSpawnTrap()
    {
        //Augmentation du nombre de Room
        roomNumber++;
        float patternspeed = speed[currentSpeed].x;
        GameObject instanciateTrap;

        //Animation brisage de coeur
        if (player.GetComponent<Player>().lifetransition)
        {
            GameObject.Find("Life").transform.GetChild(player.GetComponent<Player>().life).GetComponent<Animator>().Play("LifeDown_Anim");

            if (player.GetComponent<Player>().life == 0)
            {
                yield return new WaitForSeconds(10f);
            }
            else
            {
                yield return new WaitForSeconds(2f);
            }
        }

        //Sélection du patern
        if (gonnatuto)
        {
            if (currentSpeed != 0)
            {
                UIAnimator.Play("SpeedUp_Anim");
                yield return new WaitForSeconds(1f);
            }

            ScoreSet();
            yield return new WaitForSeconds(patternspeed + 1f);

            instanciateTrap = Instantiate(prefabs[currentSpeed].tutoPat, transform.position, transform.rotation);
            gonnatuto = false;
        }
        else
        {
            ScoreSet();
            yield return new WaitForSeconds(patternspeed + 1f);

            randomPatern = Random.Range(0, prefabs[currentSpeed].trapsPat.Length);
            instanciateTrap = Instantiate(prefabs[currentSpeed].trapsPat[randomPatern], transform.position, transform.rotation);
        }

        //Spawn du pattern
        instanciateTrap.transform.SetParent(gameObject.transform);
        instanciateTrap.transform.localRotation = Quaternion.Euler(0, 0, randomRotation[Random.Range(0, randomRotation.Length)]);
    }

    public void Reset()
    {
        WallAppear();
        StartCoroutine(RandomizerSpawnTrap());
    }

    public void WallAppear()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<Collider2D>().enabled = true;
            transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1f);
        }
    }

    private void ScoreSet()
    {
        if (roomNumber < 10)
        {
            scoretext.text = "00" + roomNumber;
        }
        else if (roomNumber < 100)
        {
            scoretext.text = "0" + roomNumber;
        }
        else
        {
            scoretext.text = "" + roomNumber;
        }

        UIAnimator.Play("ScoreUp_Anim");
    }
}

[System.Serializable]
public class LevelPattern
{
    public GameObject tutoPat;
    public GameObject[] trapsPat;
}
