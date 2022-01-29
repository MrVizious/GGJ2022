using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public int leftScore;
    public int rightScore;
    void Start()
    {
        leftScore = 0;
        rightScore = 0;
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
