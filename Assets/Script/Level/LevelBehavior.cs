using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class LevelBehavior : MonoBehaviour
{
    public static LevelBehavior instance;

    public GameObject[] prefabTrap;
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
        if (roomNumber == (int)speed[currentSpeed].y)
        {
            currentSpeed++;
        }
    }

    public IEnumerator RandomizerSpawnTrap()
    {
        roomNumber++;
        float patternspeed = speed[currentSpeed].x;

        randomPatern = Random.Range(0, 19);

        yield return new WaitForSeconds(patternspeed);

        GameObject instanciateTrap = Instantiate(prefabTrap[randomPatern], transform.position, transform.rotation);

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
