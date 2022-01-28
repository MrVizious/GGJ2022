using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverToken : MonoBehaviour
{
    public GameObject go;

    Ray ray;
    RaycastHit hitData;
    Vector3 worldPosition;
    // Update is called once per frame
    void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hitData, 1000))
        {
            go.SetActive(true);
            worldPosition = hitData.point;
            Vector3 newPosition = new Vector3(hitData.transform.position.x,
                                                transform.position.y,
                                                hitData.transform.position.z);
            go.transform.position = newPosition;
        }
        else
        {
            go.SetActive(false);
        }


    }
}
