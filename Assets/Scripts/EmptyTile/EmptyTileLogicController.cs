using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyTileLogicController : MonoBehaviour
{
    public void Disappear(){
        GetComponent<DisappearingAnimation>().Disappear();
    }

    private void OnDestroy() {
        GameObject.Find("GameController").GetComponent<GameController>().EmptyTileDestroyed(transform);
    }
}
