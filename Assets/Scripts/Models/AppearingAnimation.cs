using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearingAnimation : MonoBehaviour
{
    public AnimationCurve curve;
    float time = 0f;
    Renderer rendererReference;
    private void Start() {
        rendererReference = GetComponent<Renderer>();
        rendererReference.enabled = false;
        time = 0f;
    }
    private void Update() {
        if(curve != null){
            rendererReference.enabled = true;
            time += Time.deltaTime;
            float value = curve.Evaluate(time);
            transform.localScale = new Vector3(value, value, value);
        }
    }
}