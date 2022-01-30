using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingAnimation : MonoBehaviour
{
    public AnimationCurve curve = new AnimationCurve();

    public float rotationSpeed = 12f;

    public void Disappear(){
        StartCoroutine(DisappearAnimation());
    }

    private IEnumerator DisappearAnimation(){
        float time = 0;
        while(time < 1){
            time += Time.deltaTime;
            transform.localScale = Vector3.one * curve.Evaluate(time);
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            yield return null;
        }
        Destroy(gameObject);
    }
}
