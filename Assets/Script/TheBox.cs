using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBox : MonoBehaviour
{
    [SerializeField] bool hastriggered;
    [SerializeField] float timer, totalTurn, turnRate;

    void Update()
    {
        TheBoxMove();
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    void TheBoxMove()
    {
        if (Input.GetAxis("Left Trigger") < 0.1 && Input.GetAxis("Right Trigger") < 0.1)
        {
            hastriggered = false;
        }

        if (Input.GetAxis("Left Trigger") >= 0.1)
        {
            Debug.Log("gauche");
            if (!hastriggered && timer <= 0)
            {
                hastriggered = true;
                totalTurn += 90;
                timer = 90 / turnRate + 0.08f;
            }
        }
        else if (Input.GetAxis("Right Trigger") >= 0.1)
        {
            Debug.Log("droite");
            if (!hastriggered && timer <= 0)
            {
                hastriggered = true;
                totalTurn -= 90;
                timer = 90 / turnRate + 0.08f;
            }
        }

        if (totalTurn < 0 && transform.rotation.eulerAngles.z > 350)
        {
            totalTurn = 360 + totalTurn;
        }
        else if (totalTurn >= 360 && transform.rotation.eulerAngles.z < 10)
        {
            totalTurn -= 360;
        }

        if (totalTurn > transform.rotation.eulerAngles.z)
        {
            if (transform.rotation.eulerAngles.z > totalTurn - 1 && transform.rotation.eulerAngles.z <= totalTurn)
            {
                transform.rotation = Quaternion.Euler(0, 0, totalTurn);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + turnRate * Time.deltaTime);
            }
        }
        else if (totalTurn < transform.rotation.eulerAngles.z)
        {
            if (transform.rotation.eulerAngles.z < totalTurn + 1 && transform.rotation.eulerAngles.z >= totalTurn)
            {
                transform.rotation = Quaternion.Euler(0, 0, totalTurn);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z - turnRate * Time.deltaTime);
            }
        }
    }
}
