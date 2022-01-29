using System.Collections;
using System.Collections.Generic;
using RoboRyanTron.Unite2017.Events;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif



[CreateAssetMenu(fileName = "GameData", menuName = "GameData", order = 1)]
public class GameData : ScriptableObject
{
    public int leftScore = 0;
    public int rightScore = 0;
    public GameEvent onScoreChangedEvent;

    public void AddValueToLeftScore(int newScore) {
        SetLeftScore(leftScore + newScore);
    }

    public void AddValueToRightScore(int newScore) {
        SetRightScore(rightScore + newScore);
    }

    public void ResetScores() {
        SetLeftScore(0);
        SetRightScore(0);
    }

    public void SetLeftScore(int newScore) {
        leftScore = newScore;
        onScoreChangedEvent?.Raise();
    }

    public void SetRightScore(int newScore) {
        rightScore = newScore;
        onScoreChangedEvent?.Raise();
    }

}

#if UNITY_EDITOR
// Create an inspector with a button for each public function
[CustomEditor(typeof(GameData))]
public class GameDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GameData data = (GameData)target;

        if (GUILayout.Button("Add Value To Left Score"))
        {
            data.AddValueToLeftScore(1);
        }

        if (GUILayout.Button("Add Value To Right Score"))
        {
            data.AddValueToRightScore(1);
        }

        if (GUILayout.Button("Reset Scores"))
        {
            data.ResetScores();
        }

        if (GUILayout.Button("Set Left Score"))
        {
            data.SetLeftScore(10);
        }

        if (GUILayout.Button("Set Right Score"))
        {
            data.SetRightScore(10);
        }
    }
}
#endif