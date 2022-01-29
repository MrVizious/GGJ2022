using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTurns : MonoBehaviour
{
    public float minYRotation = 35f, maxYRotation = 55f;
    public bool isTargetLeft = true;
    public float rotationDuration = 0.5f;
    public AnimationCurve rotationCurve;

    private IEnumerator coroutine = null;
    public Transform pivot;
    public Camera cam;

    private void Start() {
        CheckTurn();
    }

    public void CheckTurn(){
        CheckRotation();
    }
    private void CheckRotation() {
        if (isTargetLeft && transform.eulerAngles.y > minYRotation)
        {
            if (coroutine != null)
                StopCoroutine(coroutine);
            coroutine = RotateTowardsTarget(minYRotation);
            StartCoroutine(coroutine);
        }
        else if (!isTargetLeft && transform.eulerAngles.y < maxYRotation)
        {
            if (coroutine != null)
                StopCoroutine(coroutine);
            coroutine = RotateTowardsTarget(maxYRotation);
            StartCoroutine(coroutine);
        }
    }

    private IEnumerator RotateTowardsTarget(float targetRotation) {
        float currentRotation = pivot.rotation.eulerAngles.y;
        float i = 0;
        float rate = 1 / rotationDuration;
        while (i < 1) {
            i += rate * Time.deltaTime;
            currentRotation = Mathf.LerpAngle(currentRotation, targetRotation, rotationCurve.Evaluate (i));
            pivot.rotation = Quaternion.Euler(pivot.rotation.eulerAngles.x, currentRotation, pivot.rotation.eulerAngles.z);
            yield return null;
        }
    }

    public void ChangeIsTargetLeft() {
        ChangeIsTargetLeft(!isTargetLeft);
    }
    public void ChangeIsTargetLeft(bool newValue) {
        isTargetLeft = newValue;
        CheckRotation();
    }
}
