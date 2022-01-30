using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TileAnimationController : MonoBehaviour
{
    public float amplitude = 0.15f;
    public float wobblingSpeed = 0.5f, wobblingOffset = 0f;
    private float initialY;
    private Quaternion initialRotation;
    public float rotationSpeed = 0.5f;

    private IEnumerator flipCoroutine = null;

    private Tiles3DSpawner spawner;

    private void Start() {
        initialY = transform.position.y;
        spawner = GetComponent<Tiles3DSpawner>();
    }


    // Update is called once per frame
    void Update() {
        WobbleUpAndDown();
    }

    public void Rotate(bool isLeft) {
        if (flipCoroutine != null) { StopCoroutine(flipCoroutine); }
        flipCoroutine = DoTheRotate(isLeft);
        StartCoroutine(flipCoroutine);
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
        return Mathf.Sin((x + y + Time.time) * wobblingSpeed) * amplitude;
    }

    public IEnumerator DoTheRotate(bool isLeft) {
        Quaternion qEnd;
        if (isLeft) { qEnd = Quaternion.identity; }
        else
        {
            qEnd = Quaternion.AngleAxis(180f, -Vector3.Normalize(Vector3.right + -Vector3.forward));
        }
        float quaternionDelta = Mathf.Infinity;
        while (quaternionDelta > 0.01f)
        {
            Vector3 axisToRotateAround = Vector3.Normalize(Vector3.right + -Vector3.forward);
            if(!isLeft) axisToRotateAround = -axisToRotateAround;

            transform.RotateAround(transform.position, axisToRotateAround, rotationSpeed);
            quaternionDelta = Quaternion.Angle(qEnd, transform.rotation);
            yield return null;
        }
        transform.rotation = qEnd;
        spawner.SpawnModel(isLeft);
    }
}