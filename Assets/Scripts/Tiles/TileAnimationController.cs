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
    private bool flip_allowed = true;

    private void Start() {
        initialY = transform.position.y;
        flipCoroutine = DoTheRotate(1.0f,tile_reset);
        StartCoroutine(flipCoroutine);
    }


    // Update is called once per frame
    void Update() {
        WobbleUpAndDown();
        if(Input.GetKey(KeyCode.Space) && flip_allowed){
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

    public IEnumerator Rotate() {
        Quaternion target = transform.rotation * Quaternion.AngleAxis(180, new Vector3(0.5f, 0f, -0.5f));
        while (transform.rotation != target)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target, Time.deltaTime * speed);
            yield return null;
        }
    }
}
