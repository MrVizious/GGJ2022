using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Physics.Raycast;

public class TokenLogicManager : MonoBehaviour
{
    private Vector3 RayOrigin;
    private Vector3 RayDirection;
    private float RayLength;

    void Start()
    {
        RayDirection = new Vector3(0.0f,-1.0f,0.0f);
        RayLength = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        RayOrigin = transform.position;
    }
}
