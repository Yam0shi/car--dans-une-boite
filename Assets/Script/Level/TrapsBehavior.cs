using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsBehavior : MonoBehaviour
{
    public bool affectGravity;
    public bool disappear;
    [SerializeField] private GameObject daWall;

    void Start()
    {
        float thatspeed = LevelBehavior.GetInstance().speed[LevelBehavior.GetInstance().currentSpeed].x;

        StartCoroutine(Thingy(thatspeed));        
    }

    IEnumerator Thingy(float speed)
    {
        #region(gestion du trap à son pop)
        GameObject childEffect = transform.GetChild(0).gameObject;

        if (disappear)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = true;
        }
        else
        {
            GetComponent<Collider2D>().enabled = false;
        }

        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, .2f);
        #endregion

        #region(blink)
        yield return new WaitForSeconds(speed / 5);
        childEffect.SetActive(false);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0f);
        yield return new WaitForSeconds(speed / 5);
        childEffect.SetActive(true);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, .2f);
        yield return new WaitForSeconds(speed / 5);
        childEffect.SetActive(false);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0f);
        yield return new WaitForSeconds(speed / 10);
        childEffect.SetActive(true);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, .2f);
        yield return new WaitForSeconds(speed / 10);
        childEffect.SetActive(false);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0f);
        yield return new WaitForSeconds(speed / 10);
        childEffect.SetActive(true);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, .2f);
        yield return new WaitForSeconds(speed / 10);
        childEffect.SetActive(false);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0f);
        yield return new WaitForSeconds(speed / 10);
        childEffect.SetActive(true);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, .2f);
        #endregion

        #region(postblink)
        if (affectGravity)
        {
            GetComponent<Rigidbody2D>().gravityScale = 5;
        }

        if (disappear)
        {
            childEffect.SetActive(false);
            daWall.GetComponent<Collider2D>().enabled = false;
            daWall.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0f);
        }
        else
        {
            GetComponent<Collider2D>().enabled = true;
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        }

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
