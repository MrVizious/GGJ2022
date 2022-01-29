using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileLogicController : MonoBehaviour
{
    public bool isLeft = false;
    public float value = 1f;
    public List<Text> numberTexts;

    public void MultiplyValueBy(float factor) {
        SetValue(value * factor);
    }

    public void SetValue(float value) {
        this.value = value;

    }

    private void UpdateValueTexts() {
        foreach (Text text in numberTexts) {
            text.text = value.ToString();
        }
    }
}
