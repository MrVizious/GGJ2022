using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public int leftScore;
    public int rightScore;
    public  TextMeshProUGUI leftTextScore;
    public TextMeshProUGUI  rightTextScore;
    void Start()
    {
        leftScore = 0;
        rightScore = 0;
        leftTextScore.text = "" + leftScore;
        rightTextScore.text = "" + rightScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void event_AddScoreToLeft(int newScore){
        leftScore = leftScore + newScore;
    }

    public void event_AddScoreToRight(int newScore){
        rightScore = rightScore + newScore;
    }
}
