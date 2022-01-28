using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileUpAndDown : MonoBehaviour
{
    public float amplitude = 0.15f;
    public float speed = 0.5f, offset = 0f;
    private float initialY;

    private void Start() {
        initialY = transform.position.y;
    }


    // Update is called once per frame
    void Update() {
        transform.position = new Vector3(transform.position.x,
                initialY + GetYOffset(transform.position.x, transform.position.z) + offset,
                transform.position.z);
    }

    // Function that return a sine wave depending on the x and y position of the tile
    public float GetYOffset(float x, float y) {
        return Mathf.Sin((x + y + Time.time) * speed) * amplitude;
    }
}
