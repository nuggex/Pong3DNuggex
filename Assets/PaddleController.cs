using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
public class PaddleController : Agent
{
    float PaddleSpeed = 35.0f;
    public int score = 0;
    float timer = 0;
    GameObject playerSpawner;

    // Start is called before the first frame update

    public override void Initialize()
    {
        playerSpawner = GameObject.Find("PlayerSpawner");
        score = 0;
        GameManager.instance.Player = this.gameObject;
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        if (vectorAction[0] > 0 && (transform.position.x > -50f && transform.position.x < 50f))
        {
            transform.position += transform.right * Time.deltaTime * PaddleSpeed;
        }
        if (vectorAction[0] < 0 && (transform.position.x > -50f && transform.position.x < 50f))
        {
            transform.position -= transform.right * Time.deltaTime * PaddleSpeed;
        }
        if (vectorAction[1] > 0 && (transform.position.y > 0f && transform.position.x < 50f))
        {
            transform.position += transform.up * Time.deltaTime * PaddleSpeed;
        }
        if (vectorAction[1] < 0 && (transform.position.y > 0f && transform.position.x < 50f))
        {
            transform.position -= transform.up * Time.deltaTime * PaddleSpeed;
        }
    }

    public override void OnEpisodeBegin()
    {
        gameObject.transform.position = playerSpawner.transform.position;
        GameManager.instance.ResetGame();
    }

    public void Reset()
    {
        // Warp player to start pos, reset rotation and reset health, points and timer// '

        timer = Time.time;
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        if (transform.position.x < -50) transform.position = new Vector3(-49.9999f, transform.position.y, transform.position.z);
        if (transform.position.x > 50) transform.position = new Vector3(49.9999f, transform.position.y, transform.position.z);
        if (transform.position.y < 0) transform.position = new Vector3(transform.position.x, 0.0001f, transform.position.z);
        if (transform.position.y > 50) transform.position = new Vector3(transform.position.x, 49.9999f, transform.position.z);
        TimeKeeper();
        RequestDecision();
        
    }
    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = 0f;
        actionsOut[0] = 0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > -50f && transform.position.x < 50f)
            {
                transform.position += transform.right * Time.deltaTime * PaddleSpeed;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x > -50f && transform.position.x < 50f)
            {
                transform.position -= transform.right * Time.deltaTime * PaddleSpeed;
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (transform.position.y > 0f && transform.position.x < 50f)
            {
                transform.position += transform.up * Time.deltaTime * PaddleSpeed;
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (transform.position.y > 0f && transform.position.x < 50f)
            {
                transform.position -= transform.up * Time.deltaTime * PaddleSpeed;
            }
        }
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(GameManager.instance.currentBall.transform.position);
        sensor.AddObservation(GameManager.instance.playerScore);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "ball")
        {
            GameManager.instance.playerScore += (int)Score.hitball;
            AddReward(0.2f);
        }
    }

    public void TimeKeeper()
    {
        // IF Current Episode has been running for over 90 seconds // 
        if (Time.time - timer > 300)
        {
            // Add Time Penalty to rewards // 
            // End Episode // 
            EndEpisode();
        }


    }
}
