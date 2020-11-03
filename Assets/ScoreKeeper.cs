using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScoreKeeper : MonoBehaviour
{

    public GameObject Score;
    Text ScoreText;
    int p1score;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText = Score.GetComponent<Text>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        p1Score = GameManager.instance.GetPlayerScore();
        ScoreText.text = "Player 1: " + p1Score.ToString();
    }


}
