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
            float randomDirection = Random.Range(-50, 50);
            ball = Instantiate(preFabBall, SpawnPoint.transform.position, preFabBall.transform.rotation);
            ball.GetComponent<Rigidbody>().AddForce(ball.transform.forward*randomDirection, ForceMode.Impulse);
        }
    }
}
