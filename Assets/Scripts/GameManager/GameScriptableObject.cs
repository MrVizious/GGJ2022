using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameScriptableObject : ScriptableObject {
    public int leftScore = 0;
    public int rightScore = 0;

    public void event_AddScoreToLeft(int newScore){
        leftScore = leftScore + newScore;
    }

    public void event_AddScoreToRight(int newScore){
        rightScore = rightScore + newScore;
    }
}
