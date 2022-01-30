using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TokenLogicManager : MonoBehaviour
{
    private GameObject HitObject;
    private RaycastHit hit;
    public GameData data;

    // Update is called once per frame
    void Update()
    {
        //UnityEngine.Debug.Log("updating");
        UnityEngine.Debug.DrawRay(transform.position,Vector3.up,Color.blue);
        if (Physics.Raycast(new Ray(transform.position-Vector3.up*5,Vector3.up), out hit, 10.0f))
        {
            if(Input.GetMouseButtonDown(0)){
                //UnityEngine.Debug.Log("Hit something");
                HitObject = hit.transform.gameObject;
                //UnityEngine.Debug.Log(HitObject);
                //UnityEngine.Debug.Log(HitObject.GetComponent<EmptyTileLogicController>());
                HitObject.GetComponent<EmptyTileLogicController>().Disappear(data.isLeftTurn);
                //UnityEngine.Debug.Log(HitObject.GetComponentInChildren<TextMeshPro>().text);
            }
        }
    }
}

