using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsBehavior : MonoBehaviour
{
    public bool affectGravity;
    public bool disappearwall;
    [SerializeField] private GameObject daWall;

    void Start()
    {
        if (disappearwall)
        {
            StartCoroutine(Wall());
        }
        else
        {
            StartCoroutine(Thingy());
        }
        
    }

    IEnumerator Thingy()
    {
        #region(gestion du trap à son pop)
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, .2f);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        #endregion

        #region(blink)
        yield return new WaitForSeconds(.5f);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0f);
        yield return new WaitForSeconds(.4f);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, .2f);
        yield return new WaitForSeconds(.3f);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0f);
        yield return new WaitForSeconds(.2f);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, .2f);
        yield return new WaitForSeconds(.1f);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0f);
        yield return new WaitForSeconds(.1f);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, .2f);
        yield return new WaitForSeconds(.1f);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0f);
        yield return new WaitForSeconds(.1f);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, .2f);
        yield return new WaitForSeconds(.1f);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0f);
        yield return new WaitForSeconds(.1f);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, .2f);
        #endregion

        #region(postblink)
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }

        if (affectGravity)
        {
            GetComponent<Rigidbody2D>().gravityScale = 5;
        }

        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        yield return new WaitForSeconds(.7f);

        Destroy(gameObject);
        #endregion
    }

    IEnumerator Wall()
    {
        GameObject childEffect = transform.GetChild(0).gameObject;

        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0f);

        #region(blink)
        yield return new WaitForSeconds(.5f);
        childEffect.SetActive(false);
        yield return new WaitForSeconds(.4f);
        childEffect.SetActive(true);
        yield return new WaitForSeconds(.3f);
        childEffect.SetActive(false);
        yield return new WaitForSeconds(.2f);
        childEffect.SetActive(true);
        yield return new WaitForSeconds(.1f);
        childEffect.SetActive(false);
        yield return new WaitForSeconds(.1f);
        childEffect.SetActive(true);
        yield return new WaitForSeconds(.1f);
        childEffect.SetActive(false);
        yield return new WaitForSeconds(.1f);
        childEffect.SetActive(true);
        yield return new WaitForSeconds(.1f);
        childEffect.SetActive(false);
        yield return new WaitForSeconds(.1f);
        #endregion

        #region(postblink)
        daWall.GetComponent<Collider2D>().enabled = false;
        daWall.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0f);
        Debug.Log("disparition");
        yield return new WaitForSeconds(.5f);

        daWall.GetComponent<Collider2D>().enabled = true;
        daWall.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1f);
        Debug.Log("appartion");
        yield return new WaitForSeconds(.2f);

        Debug.Log("Destruction");
        Destroy(gameObject);
        #endregion
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            daWall = collision.gameObject;
        }
    }
}
