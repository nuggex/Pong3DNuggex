using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaddleController : MonoBehaviour
{
    Text scoreText;
    float PaddleSpeed = 35.0f;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
            score += (int)Score.hitball;
        }
        if(collision.collider.tag == "goal")
        {
            score += (int)Score.goal;
        }
    }
}
