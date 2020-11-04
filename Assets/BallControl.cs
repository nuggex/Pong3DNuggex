using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    Rigidbody ballRB;
    int bouncesPlayer;
    int bouncesComputer;
    private void Start()
    {
        GameManager.instance.currentBall = gameObject;
        ballRB = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        /*Debug.Log("BallRB Transform" + ballRB.transform.position);
        Debug.Log("BallRB Velocity" + ballRB.velocity);
        Debug.Log("BallRB Velocity" + ballRB.velocity.magnitude);
        */
        if (bouncesComputer > 2)
        {
            GameManager.instance.playerScore += 1;
            GameManager.instance.ReturnAwardPC(1.0f);
            Destroy(gameObject);
        }
        if (bouncesPlayer > 2)
        {
            GameManager.instance.computerScore += +1;
            GameManager.instance.ReturnAwardPC(-1.0f);
            Destroy(gameObject);
        }

        if (transform.position.y > 51 || transform.position.y < -1 || transform.position.x > 51 || transform.position.x < -51 || transform.position.z > 55 || transform.position.z < -55)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "paddle")
        {
            bouncesPlayer = 0;
            bouncesComputer = 0;
        }
        if (collision.collider.tag == "westwall")
        {
            //ballRB.velocity = ballRB.velocity * 1.5f;
            // ballRB.AddForce(ballRB.velocity, ForceMode.Impulse);
        }
        if (collision.collider.tag == "eastwall")
        {
            //ballRB.velocity = ballRB.velocity * 1.5f;
            //ballRB.AddForce(ballRB.transform.position, ForceMode.Impulse);
            //ballRB.AddForce(ballRB.velocity, ForceMode.Impulse);
        }
        if (collision.collider.tag == "floor")
        {
            if (ballRB.transform.position.z < 0)
            {
                bouncesComputer += 1;
            }
            else if (ballRB.transform.position.z >= 0)
            {
                bouncesPlayer += 1;
            }
            //ballRB.velocity = ballRB.velocity * 1.5f;
            //ballRB.AddForce(ballRB.transform.position, ForceMode.Impulse);
            //ballRB.AddForce(ballRB.velocity, ForceMode.Impulse);

        }
        if (collision.collider.name == "GoalP1")
        {
            GameManager.instance.ReturnAwardPC(-1.0f);
            GameManager.instance.computerScore += (int)Score.goal;
        }
        if (collision.collider.name == "GoalP2")
        {
            GameManager.instance.ReturnAwardPC(1.0f);
            GameManager.instance.playerScore += (int)Score.goal;
        }

        if (collision.collider.tag == "goal")
        {
            Destroy(gameObject);
        }


    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "paddle")
        {
            ballRB.AddForce(ballRB.velocity, ForceMode.Impulse);
        }
    }
}
