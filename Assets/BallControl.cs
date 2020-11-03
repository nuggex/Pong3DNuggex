using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    Rigidbody ballRB;

    private void Start()
    {
        GameManager.instance.currentBall = gameObject;
        ballRB = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(transform.position.y > 51 || transform.position.y < -1 || transform.position.x > 51 ||transform.position.x < -51 ||transform.position.z > 55 ||transform.position.z < -55)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "paddle")
        {
            ballRB.AddForce(-ballRB.velocity* 3f, ForceMode.Impulse);
        }
        if(collision.collider.tag == "wall")
        {
            ballRB.AddForce(ballRB.velocity * 0.5f, ForceMode.Impulse);
        }
        if(collision.collider.tag == "floor")
        {
            ballRB.AddForce(ballRB.velocity * 0.5f, ForceMode.Impulse);

        }
        if (collision.collider.name == "GoalP1")
        {
            GameManager.instance.ReturnAwardPC(-5.0f);
            GameManager.instance.computerScore += (int)Score.goal;
        }
        if (collision.collider.name == "GoalP2")
        {
            GameManager.instance.ReturnAwardPC(2.0f); 
            GameManager.instance.playerScore += (int)Score.goal;
        }

        if (collision.collider.tag == "goal")
        {
            Destroy(gameObject);
        }
        

    }
}
