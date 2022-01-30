using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuTile : MonoBehaviour
{
    public int chanceNumber;
    private TileLogicController tileLogicController;
    private Tiles3DSpawner spawner;
    private void Start() {
        tileLogicController = GetComponent<TileLogicController>();
        spawner = GetComponent<Tiles3DSpawner>();
        Debug.Log("Trying to spawn");
        spawner.SpawnModel(tileLogicController.isLeft);
    }

    private void Update() {
        if (Time.frameCount % (int)Random.Range(1, chanceNumber) == 0)
        {
            tileLogicController.Rotate();
        }
    }
}
