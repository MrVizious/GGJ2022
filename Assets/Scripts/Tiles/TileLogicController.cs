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
    public int value = 1;
    public List<TextMeshPro> numberTexts;

    private TileAnimationController animator;

    private void Start() {
        animator = GetComponent<TileAnimationController>();
    }

    public void MultiplyValueBy(int factor) {
        SetValue(value * factor);
    }

    public void SetValue(int newValue) {
        value = newValue;
        UpdateValueTexts();
    }

    public void UpdateValueTexts() {
        foreach (TextMeshPro text in numberTexts)
        {
            text.text = value.ToString();
        }
    }

    public void SetIsLeft(bool newValue) {
        if (newValue != isLeft)
        {
            Rotate();
        }
    }

    public void Rotate() {
        isLeft = !isLeft;
        MultiplyValueBy(2);
        animator.Rotate(isLeft);
    }
}

// Custom inspector with a button to multiply the value by 2
#if UNITY_EDITOR
[CustomEditor(typeof(TileLogicController))]
public class TileLogicControllerEditor : Editor
{
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        TileLogicController tileLogicController = (TileLogicController)target;

        if (GUILayout.Button("Update Value"))
        {
            tileLogicController.UpdateValueTexts();
        }
        if (GUILayout.Button("Multiply by 2"))
        {
            tileLogicController.MultiplyValueBy(2);
        }
        if (GUILayout.Button("Rotate"))
        {
            tileLogicController.Rotate();
        }
    }
}
#endif