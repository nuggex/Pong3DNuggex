using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScoreKeeper : MonoBehaviour
{

    public GameObject PlayerScore;
    public GameObject ComputerScore;
    Text ScoreText;
    Text ComputerText;
    int pscore = 0;
    int cscore = 0;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText = PlayerScore.GetComponent<Text>();
        ComputerText = ComputerScore.GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pscore = GameManager.instance.playerScore;
        ScoreText.text = "Player 1: " + pscore.ToString();
        cscore = GameManager.instance.computerScore;
        ComputerText.text = "Computer: " + cscore.ToString();
    }


}
