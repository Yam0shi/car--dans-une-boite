using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapParentBehavior : MonoBehaviour
{
    private float thatspeed;

    void Start()
    {
        thatspeed = LevelBehavior.GetInstance().speed[LevelBehavior.GetInstance().currentSpeed].x;
        StartCoroutine(ResetLevel(thatspeed));
    }

    IEnumerator ResetLevel(float speed)
    {
        yield return new WaitForSeconds(speed * 3);
        LevelBehavior.GetInstance().Reset();
        Destroy(gameObject);
    }
}
