using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TrapGeneration : MonoBehaviour
{
    [SerializeField] GameObject[] prefabTrap;

    [SerializeField] int randomPatern, chooseRotation;
    [SerializeField] int[] randomRoation;
    void Start()
    {
        StartCoroutine(RandomizerSpawnTrap());
    }

    void Update()
    {

    }

    IEnumerator RandomizerSpawnTrap()
    {
        randomPatern = (int)Random.Range(0, 19);
        chooseRotation = (int)Random.Range(0,7);
        yield return new WaitForSeconds(3);
        Quaternion rotation = new Quaternion(0, 0, randomRoation[chooseRotation], 1);
        GameObject instanciateTrap = Instantiate(prefabTrap[randomPatern], new Vector2(transform.position.x, transform.position.y),gameObject.transform.rotation);
        #region(gestion du trap à son pop)
        instanciateTrap.GetComponent<PolygonCollider2D>().enabled = false;
        instanciateTrap.transform.SetParent(gameObject.transform);
        instanciateTrap.transform.position = new Vector3(transform.position.x + 0.22f, transform.position.y, transform.position.z);
        instanciateTrap.transform.rotation = rotation;
        instanciateTrap.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, .2f);
        #endregion
        #region(blink)
        yield return new WaitForSeconds(.7f);
        instanciateTrap.SetActive(false);
        yield return new WaitForSeconds(.7f);
        instanciateTrap.SetActive(true);
        yield return new WaitForSeconds(.7f);
        instanciateTrap.SetActive(false);
        yield return new WaitForSeconds(.7f);
        instanciateTrap.SetActive(true);
        #endregion
        #region(postblink)
        instanciateTrap.GetComponent<PolygonCollider2D>().enabled = true;
        instanciateTrap.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        yield return new WaitForSeconds(2);
        Destroy(instanciateTrap);
        #endregion
        StartCoroutine(RandomizerSpawnTrap());
    }
}
