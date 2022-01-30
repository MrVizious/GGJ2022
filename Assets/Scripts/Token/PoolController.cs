using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour
{
    public GameObject Piece1;
    public GameObject Piece2;
    public GameObject Piece3;
    public GameObject Piece4;
    public GameObject Piece5;
    public GameObject Piece6;
    public GameObject Piece7;
    public GameObject Piece8;
    public GameObject Piece9;

    public GameObject[] allPieces;
    public GameObject[] pulledPieces;

    public GameData data;
    public bool isLeftController;

    private int rgn;
    void Start()
    {
        allPieces = new GameObject[9];
        allPieces[0] = Piece1;
        allPieces[1] = Piece2;
        allPieces[2] = Piece3;
        allPieces[3] = Piece4;
        allPieces[4] = Piece5;
        allPieces[5] = Piece6;
        allPieces[6] = Piece7;
        allPieces[7] = Piece8;
        allPieces[8] = Piece9;

        pulledPieces = new GameObject[3];
        for(int i = 0; i < pulledPieces.Length; i++)
        {
            rgn = (int)Mathf.Round(Random.Range(1,allPieces.Length-1));
            if(data.isLeftTurn == isLeftController){Debug.Log(rgn);}
            pulledPieces[i] = allPieces[rgn];

        }
        if(data.isLeftTurn == isLeftController){pulledPieces[0] = allPieces[0];}
    }

    public void TurnChanged()
    {
        bool isMyTurn = data.isLeftTurn == isLeftController;
        if(isMyTurn){
            for(int i = 0; i < pulledPieces.Length; i++)
            {
                rgn = (int)Mathf.Round(Random.Range(1,allPieces.Length-1));
                if(data.isLeftTurn == isLeftController){Debug.Log(rgn);}
                if(i == pulledPieces.Length -1)
                {
                    pulledPieces[i] = allPieces[rgn];
                } else {
                    pulledPieces[i] = pulledPieces [i+1];
                }
            }
        }
    }
}
