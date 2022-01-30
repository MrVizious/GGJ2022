using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenInMouseManager : MonoBehaviour
{
    public GameObject NaturePool;
    public GameObject RobotPool;

    public GameData data;
    private GameObject TokenForDisplayPrefab;
    private GameObject TokenForDisplay;

    void Start()
    {
        Invoke("TurnChanged",0.15f);
    }

    public void TurnChanged()
    {
        if(data.isLeftTurn)
        {
            TokenForDisplayPrefab = NaturePool.GetComponent<PoolController>().pulledPieces[0];
        } else {
            TokenForDisplayPrefab = RobotPool.GetComponent<PoolController>().pulledPieces[0];
        }

        foreach (Transform child in this.gameObject.transform){GameObject.Destroy(child.gameObject);}

        TokenForDisplay = Instantiate(TokenForDisplayPrefab) as GameObject;
        TokenForDisplay.transform.position = this.gameObject.transform.position;
        TokenForDisplay.transform.rotation = this.gameObject.transform.rotation;
        TokenForDisplay.transform.parent = this.gameObject.transform;
        
    }
}
