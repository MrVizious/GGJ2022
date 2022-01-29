using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTurns : MonoBehaviour
{
    public float minYRotation = 35f, maxYRotation = 55f;
    public bool leftTurn = true;
    public float changeDuration = 0.5f;
    public AnimationCurve curve;

    public Color leftColor, rightColor;

    private IEnumerator coroutine = null;
    public Transform pivot;
    public Camera cam;

    private void Start() {
        CheckTurn();
    }

    public void CheckTurn() {
        if (leftTurn && transform.eulerAngles.y < maxYRotation)
        {
            if (coroutine != null)
                StopCoroutine(coroutine);
            coroutine = ChangeTurnCoroutine(maxYRotation, leftColor);
            StartCoroutine(coroutine);

        }
        else if (!leftTurn && transform.eulerAngles.y > minYRotation)
        {
            if (coroutine != null)
                StopCoroutine(coroutine);
            coroutine = ChangeTurnCoroutine(minYRotation, rightColor);
            StartCoroutine(coroutine);
        }
    }

    private IEnumerator ChangeTurnCoroutine(float targetRotation, Color targetColor) {
        float currentRotation = pivot.rotation.eulerAngles.y;
        Color currentColor = cam.backgroundColor;
        float rate = 1 / changeDuration;
        for (float i = 0; i < 1; i += rate * Time.deltaTime)
        {
            currentRotation = Mathf.LerpAngle(currentRotation, targetRotation, curve.Evaluate(i));
            currentColor = Color.Lerp(currentColor, targetColor, curve.Evaluate(i));
            pivot.rotation = Quaternion.Euler(pivot.rotation.eulerAngles.x, currentRotation, pivot.rotation.eulerAngles.z);
            cam.backgroundColor = currentColor;
            yield return null;
        }
    }

    private void ChangeToLeft() {
        leftTurn = true;
    }

    private void ChangeToRight() {
        leftTurn = false;
    }

    public void ChangeTurn() {
        if (leftTurn) ChangeToRight();
        else ChangeToLeft();
        CheckTurn();
    }
}
