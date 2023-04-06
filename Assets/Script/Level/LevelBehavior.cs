using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.PackageManager.UI;
using UnityEngine;

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


    void Start()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance TrapGeneration script.");
        }

        instance = this;

        gonnatuto = true;
        roomNumber = 0;
        currentSpeed = 0;
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
        roomNumber++;
        float patternspeed = speed[currentSpeed].x;
        GameObject instanciateTrap;

        randomPatern = Random.Range(0, prefabs[currentSpeed].trapsPat.Length);


        yield return new WaitForSeconds(patternspeed);

        if (gonnatuto)
        {
            instanciateTrap = Instantiate(prefabs[currentSpeed].tutoPat, transform.position, transform.rotation);
            gonnatuto = false;
        }
        else
        {
            instanciateTrap = Instantiate(prefabs[currentSpeed].trapsPat[randomPatern], transform.position, transform.rotation);
        }


        #region(spawntrap)
        instanciateTrap.transform.SetParent(gameObject.transform);
        instanciateTrap.transform.localRotation = Quaternion.Euler(0, 0, randomRotation[Random.Range(0, randomRotation.Length)]);
        #endregion

        yield return new WaitForSeconds(patternspeed * 3);

        Destroy(instanciateTrap);
        WallAppear();
        StartCoroutine(RandomizerSpawnTrap());
    }

    public void WallAppear()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}

[System.Serializable]
public class LevelPattern
{
    public GameObject tutoPat;
    public GameObject[] trapsPat;
}
