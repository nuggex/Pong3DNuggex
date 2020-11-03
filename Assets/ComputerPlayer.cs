using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPlayer : MonoBehaviour
{
    GameObject ball;
    Transform ballposition;
    float PaddleSpeed = 0.3f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        ball = GameManager.instance.currentBall;
        // get Ball position on every update // 
        if (ball)
        {
            ballposition = ball.transform;

            // Limit paddle movement // 
            if (transform.position.x < -50) transform.position = new Vector3(-49.9999f, transform.position.y, transform.position.z);
            if (transform.position.x > 50) transform.position = new Vector3(49.9999f, transform.position.y, transform.position.z);
            if (transform.position.y < 0) transform.position = new Vector3(transform.position.x, 0.0001f, transform.position.z);
            if (transform.position.y > 50) transform.position = new Vector3(transform.position.x, 49.9999f, transform.position.z);

            // Move paddele towards ball position and limit movement speed

            Vector3 targetBall = new Vector3(ballposition.position.x, ballposition.position.y, gameObject.transform.position.z);
            float DistanceToBall = Vector3.Distance(gameObject.transform.position, ballposition.position);
            if (DistanceToBall < 60) gameObject.transform.position = Vector3.MoveTowards(transform.position, targetBall, PaddleSpeed);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "ball")
        {
            GameManager.instance.computerScore += (int)Score.hitball;
        }
    }
}
