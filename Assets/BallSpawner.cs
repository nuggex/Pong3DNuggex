using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{

    public GameObject SpawnPoint;
    public GameObject preFabBall;
    public GameObject ball;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!ball)
        {
            float RandomForce = Random.Range(25,50);
            int RandomRange = Random.Range(-1, 1);
            if (RandomRange == 0) RandomForce *= -1.0f;
            ball = Instantiate(preFabBall, SpawnPoint.transform.position, Quaternion.Euler(0,Random.Range(0,55),0));
            ball.GetComponent<Rigidbody>().AddForce(ball.transform.forward*RandomForce, ForceMode.Impulse);
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
