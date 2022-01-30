using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TokenLogicManager : MonoBehaviour
{
    private GameObject HitObject;
    private RaycastHit hit;

    // Update is called once per frame
    public void Click(bool isLeftTurn)
    {
        //UnityEngine.Debug.Log("updating");
        if (Physics.Raycast(new Ray(transform.position-Vector3.up*5,Vector3.up), out hit, 10.0f))
        {
            HitObject = hit.transform.gameObject;
            if(hit.transform.tag == "EmptyTile"){
                HitObject.GetComponent<EmptyTileLogicController>().Disappear(isLeftTurn);
            }else if(hit.transform.tag == "Tile"){
                HitObject.GetComponent<TileLogicController>().SetIsLeft(isLeftTurn);
            }
        } 
    }

    public bool isOverEmptyTile()
    {
        if (Physics.Raycast(new Ray(transform.position-Vector3.up*5,Vector3.up), out hit, 10.0f))
        {
            if (hit.transform.tag == "EmptyTile")
            {
                return true;
            }
        }
        return false;
    }

}

