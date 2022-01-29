using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileAnimationController : MonoBehaviour
{
    public float amplitude = 0.15f;
    public float speed = 0.5f, offset = 0f;
    private float initialY;

    private IEnumerator flipCoroutine = null;
    private bool tile_reset = false;
    private bool flip_allowed = false;

    private void Start() {
        initialY = transform.position.y;
        flipCoroutine = DoTheRotate(1.0f,tile_reset);
        StartCoroutine(flipCoroutine);
    }


    // Update is called once per frame
    void Update() {
        WobbleUpAndDown();
        if(Input.GetKey(KeyCode.Space) || flip_allowed){
            //Debug.Log("space pressed");
            if (flipCoroutine != null) {StopCoroutine(flipCoroutine);}
            flipCoroutine = DoTheRotate(1.0f,tile_reset);
            StartCoroutine(flipCoroutine);
            }
    }

    private void WobbleUpAndDown() {
        transform.position = new Vector3(transform.position.x,
                initialY + GetYOffset(
                    transform.position.x,
                    transform.position.z),
                transform.position.z);
    }

    // Function that return a sine wave depending on the x and y position of the tile
    public float GetYOffset(float x, float y) {
        return Mathf.Sin((x + y + Time.time) * speed) * amplitude;
    }

    public IEnumerator DoTheRotate(float time, bool reset)
     {
        flip_allowed = false;
        Quaternion qStart = transform.rotation;
        if (reset) {transform.Rotate(0.0f, 90.0f, 180.0f);} else {transform.Rotate(0.0f, -90.0f, -180.0f);}
        Quaternion qEnd = transform.rotation;
        transform.rotation = qStart;
        float t = 0.0f;
        while (t <= 1.0f) {
            transform.rotation = Quaternion.Slerp(qStart, qEnd, t);
            t += Time.deltaTime / time;
            yield return null;
        }
        transform.rotation = qEnd;
        flip_allowed = false;
     }
}
