using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceLogicController : MonoBehaviour
{
    public GameData data;
    public TokenLogicManager mainToken;

    private void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            if (mainToken.isOverEmptyTile())
            {
                foreach (TokenLogicManager token in FindObjectsOfType<TokenLogicManager>())
                {
                    token.Click(data.isLeftTurn);
                }
                GameObject.Find("GameController").GetComponent<GameController>().ChangeTurn();
            }

        }
    }
}
