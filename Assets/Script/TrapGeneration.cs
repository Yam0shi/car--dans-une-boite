using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.PackageManager.UI;
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

    IEnumerator RandomizerSpawnTrap()
    {
        randomPatern = (int)Random.Range(0, 19);
        chooseRotation = (int)Random.Range(0,7);

        yield return new WaitForSeconds(1);

        GameObject instanciateTrap = Instantiate(prefabTrap[randomPatern], transform.position, new Quaternion(0, 0, 0, 1));

        #region(spawntrap)
        instanciateTrap.transform.SetParent(gameObject.transform);
        //instanciateTrap.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        instanciateTrap.transform.localRotation = new Quaternion(0, 0, randomRoation[chooseRotation], 1);
        #endregion

/*        #region(gestion du trap à son pop)
        instanciateTrap.GetComponent<PolygonCollider2D>().enabled = false;
        instanciateTrap.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, .2f);
        #endregion

        #region(blink)
        yield return new WaitForSeconds(.5f);
        instanciateTrap.SetActive(false);
        yield return new WaitForSeconds(.4f);
        instanciateTrap.SetActive(true);
        yield return new WaitForSeconds(.3f);
        instanciateTrap.SetActive(false);
        yield return new WaitForSeconds(.2f);
        instanciateTrap.SetActive(true);
        yield return new WaitForSeconds(.1f);
        instanciateTrap.SetActive(false);
        yield return new WaitForSeconds(.1f);
        instanciateTrap.SetActive(true);
        yield return new WaitForSeconds(.1f);
        instanciateTrap.SetActive(false); 
        yield return new WaitForSeconds(.1f);
        instanciateTrap.SetActive(true);
        yield return new WaitForSeconds(.1f);
        instanciateTrap.SetActive(false);
        yield return new WaitForSeconds(.1f);
        instanciateTrap.SetActive(true);
        #endregion
        
        #region(postblink)
        for (int i = 0; i < instanciateTrap.transform.childCount; i++)
        {
            instanciateTrap.transform.GetChild(i).gameObject.SetActive(true);
        }
        instanciateTrap.GetComponent<PolygonCollider2D>().enabled = true;
        instanciateTrap.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        yield return new WaitForSeconds(.7f);
        Destroy(instanciateTrap);
        #endregion*/
        
        StartCoroutine(RandomizerSpawnTrap());
    }
}
