using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileAnimationController : MonoBehaviour
{
    public float amplitude = 0.15f;
    public float speed = 0.5f, offset = 0f;
    private float initialY;

    private void Start() {
        initialY = transform.position.y;
    }


    // Update is called once per frame
    void Update() {
        WobbleUpAndDown();
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
