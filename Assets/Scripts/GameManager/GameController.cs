using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameData data;

    public void AddValueToLeftScore(int newScore) {
        data.AddValueToLeftScore(newScore);
    }

    public void AddValueToRightScore(int newScore) {
        data.AddValueToRightScore(newScore);
    }

    public void ResetScores() {
        data.ResetScores();
    }
    
    public void SetLeftScore(int newScore) {
        data.SetLeftScore(newScore);
    }

    public void SetRightScore(int newScore) {
        data.SetRightScore(newScore);
    }
    
}
