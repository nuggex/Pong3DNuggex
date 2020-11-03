using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;
    public int playerScore = 0;
    public int computerScore = 0;
    public GameObject currentBall;
    public PaddleController pc;

    // Player and Computer Game Objects
    public GameObject Player;
    public GameObject Computer;
    
    // Computer Spawn point
    public Transform ComputerSpawn;

    private void Awake()
    {
        instance = this;
    }

    public void ResetGame()
    {
        playerScore = 0;
        computerScore = 0;
        Computer.transform.position = ComputerSpawn.position;
        pc.Reset();
    }

    public void ReturnAwardPC(float x)
    {
        pc.AddReward(x);
    }
}


public enum Score
{
    hitball = 1,
    goal = 5
}