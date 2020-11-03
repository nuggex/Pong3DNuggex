using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;

    public GameObject currentBall;
    public PaddleController pc;
    private void Awake()
    {
        instance = this;
    }
    public int GetPlayerScore()
    {
        return pc.score;
    }
}


public enum Score
{
    hitball = 1,
    goal = 5
}