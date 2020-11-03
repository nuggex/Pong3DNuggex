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
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "paddle")
        {
            ballRB.AddForce(-ballRB.velocity + collision.rigidbody.velocity, ForceMode.Impulse);
        }
    }
}
