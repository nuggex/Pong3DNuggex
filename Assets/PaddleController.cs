﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
public class PaddleController : Agent
{
    GameObject ball;
    Text scoreText;
    float PaddleSpeed = 35.0f;
    public int score = 0;
    // Start is called before the first frame update

    public override void Initialize()
    {

        score = 0;
        GameManager.instance.pc = this;
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        if(vectorAction[0] > 0 && (transform.position.x > -50f && transform.position.x < 50f))
        {
            transform.position += transform.right * Time.deltaTime * PaddleSpeed;
        }
        if(vectorAction[0] < 0 && (transform.position.x > -50f && transform.position.x < 50f))
        {
            transform.position -= transform.right * Time.deltaTime * PaddleSpeed;
        }
        if(vectorAction[1] > 0 && (transform.position.y > 0f && transform.position.x < 50f))
        {
            transform.position += transform.up * Time.deltaTime * PaddleSpeed;
        }
        if (vectorAction[1] < 0 && ( transform.position.y > 0f && transform.position.x < 50f))
        {
            transform.position -= transform.up * Time.deltaTime * PaddleSpeed;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Debug.Log("PlayerScore" + GameManager.instance.playerScore);
        Debug.Log("ComputerScore" + GameManager.instance.computerScore);
        if (transform.position.x < -50) transform.position = new Vector3(-49.9999f, transform.position.y, transform.position.z);
        if (transform.position.x > 50) transform.position = new Vector3(49.9999f, transform.position.y, transform.position.z);
        if (transform.position.y < 0) transform.position = new Vector3(transform.position.x, 0.0001f, transform.position.z);
        if (transform.position.y > 50) transform.position = new Vector3(transform.position.x, 49.9999f, transform.position.z);
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "ball")
        {
            GameManager.instance.playerScore += (int)Score.hitball;
        }
    }
}
