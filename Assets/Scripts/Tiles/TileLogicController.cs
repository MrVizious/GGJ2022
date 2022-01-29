using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TileLogicController : MonoBehaviour
{
    public bool isLeft = false;
    public float value = 1f;
    public List<TextMeshPro> numberTexts;


    public void MultiplyValueBy(float factor) {
        SetValue(value * factor);
    }

    public void SetValue(float value) {
        this.value = value;
        UpdateValueTexts();
    }

    public void UpdateValueTexts() {
        foreach (TextMeshPro text in numberTexts) {
            text.text = value.ToString();
        }
    }
}

// Custom inspector with a button to multiply the value by 2
#if UNITY_EDITOR
[CustomEditor(typeof(TileLogicController))]
public class TileLogicControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        TileLogicController tileLogicController = (TileLogicController)target;

        if (GUILayout.Button("Update Value"))
        {
            tileLogicController.UpdateValueTexts();
        }
        if (GUILayout.Button("Multiply by 2"))
        {
            tileLogicController.MultiplyValueBy(2f);
        }
    }
}
#endif