using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class LevelBehavior : MonoBehaviour
{
    public static LevelBehavior instance;

    [SerializeField] GameObject[] prefabTrap;

    [SerializeField] int randomPatern, chooseRotation;
    [SerializeField] int[] randomRotation;

    public int roomNumber;

    void Start()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance TrapGeneration script.");
        }

        instance = this;

        roomNumber = 0;
        StartCoroutine(RandomizerSpawnTrap());
    }

    public static LevelBehavior GetInstance()
    {
        return instance;
    }

    public IEnumerator RandomizerSpawnTrap()
    {
        roomNumber++;

        randomPatern = (int)Random.Range(0, 19);
        chooseRotation = (int)Random.Range(0, randomRotation.Length);

        yield return new WaitForSeconds(1);

        GameObject instanciateTrap = Instantiate(prefabTrap[randomPatern], transform.position, new Quaternion(0, 0, 0, 1));

        #region(spawntrap)
        instanciateTrap.transform.SetParent(gameObject.transform);
        //instanciateTrap.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        instanciateTrap.transform.localRotation = new Quaternion(0, 0, randomRotation[chooseRotation], 1);
        #endregion

        yield return new WaitForSeconds(2.5f);

        Destroy(instanciateTrap);
        StartCoroutine(RandomizerSpawnTrap());
    }
}
