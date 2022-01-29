using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Transform cameraPivot;
    public float duration = 3.0f;

    private Vector3 target, previousTarget;
    private float elapsed = 0.0f;
    private bool lookingAt = false;
    private bool zoomed = false;
    private float targetSize = 5f;
    [SerializeField]
    private float minSize = 1f;
    [SerializeField]
    private float maxSize = 5f;

    Ray ray;
    RaycastHit hitData;
    Vector3 worldPosition;
    void Start() {
        target = previousTarget = Vector3.zero;
    }


    void Update() {
        elapsed += Time.deltaTime;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitData, 1000))
        {
            if(hitData.transform.tag == "Tile") {
                worldPosition = hitData.point;
            }
        }

        if (zoomed)
        {

            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                target = Vector3.zero;
                targetSize = maxSize;
                elapsed = 0;
                zoomed = false;
            }
            if (Input.GetAxis("Fire2") > 0)
            {
                target = worldPosition;
            }

        }
        else
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                target = worldPosition;
                targetSize = minSize;
                elapsed = 0;
                zoomed = true;
            }
        }
        if (previousTarget != target && !lookingAt)
        {
            StartCoroutine(lookAtLerp(previousTarget, target));
            StartCoroutine(MovePivot(previousTarget, target));
            previousTarget = target;
        }
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, targetSize, elapsed / duration);
    }

    IEnumerator lookAtLerp(Vector3 prev, Vector3 targ) {
        lookingAt = true;
        float elapsedTime = 0f;
        float durationLerp = 0.5f;
        while (elapsedTime < durationLerp)
        {
            Camera.main.transform.LookAt(Vector3.Lerp(prev, targ, elapsedTime / durationLerp));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        lookingAt = false;
    }
    IEnumerator MovePivot(Vector3 prev, Vector3 targ) {
        float elapsedTime = 0f;
        float durationLerp = 0.5f;
        while (elapsedTime < durationLerp)
        {
            cameraPivot.transform.position = Vector3.Lerp(prev, targ, elapsedTime / durationLerp);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        lookingAt = false;
    }
}
