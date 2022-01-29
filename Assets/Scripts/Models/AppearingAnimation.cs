using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearingAnimation : MonoBehaviour
{
    public AnimationCurve curve;

    private void Start() {
        StartCoroutine(Appear());
    }

    private IEnumerator Appear() {
        float time = 0f;
        while (time < 1f)
        {
            time += Time.deltaTime;
            float value = curve.Evaluate(time);
            transform.localScale = new Vector3(value, value, value);
            yield return null;
        }
        Destroy(this);
    }
}
