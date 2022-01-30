using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameData data;
    public GameObject tilePrefab;
    private List<GameObject> tiles = new List<GameObject>();

    private void Update() {
        CalculateScores();
        IsGameOver();
    }
    private bool IsGameOver(){
        if(tiles.Count == 49){
            Debug.Log("Game ended!");
            return true;
        }
        return false;
    }
    public void AddValueToLeftScore(int newScore) {
        data.AddValueToLeftScore(newScore);
    }
    public void AddValueToRightScore(int newScore) {
        data.AddValueToRightScore(newScore);
    }
    public void ResetScores() {
        data.ResetScores();
    }
    public void SetLeftScore(int newScore) {
        data.SetLeftScore(newScore);
    }
    public void SetRightScore(int newScore) {
        data.SetRightScore(newScore);
    }

    public void ChangeTurn() {
        data.ChangeTurn();
        CalculateScores();
    }

    public bool GetIsLeftTurn() {
        return data.isLeftTurn;
    }
    public void CalculateScores() {
        ResetScores();
        foreach (GameObject tile in tiles)
        {
            TileLogicController controller = tile.GetComponent<TileLogicController>();
            if (controller != null)
            {
                if (controller.isLeft)
                {
                    AddValueToLeftScore(controller.value);
                }
                else
                {
                    AddValueToRightScore(controller.value);
                }
            }
        }
    }

    public void EmptyTileDestroyed(Transform t, bool didLeftPlayerDestroyIt, int value) {
        Quaternion rotation = didLeftPlayerDestroyIt ? Quaternion.Euler(0, 0, 0) : Quaternion.Euler(0, -90, 180);
        GameObject newTile = Instantiate(tilePrefab, new Vector3(t.position.x, 0f, t.position.z), rotation);
        newTile.transform.localScale = new Vector3(0f, 0f, 0f);
        newTile.GetComponent<TileLogicController>().isLeft = didLeftPlayerDestroyIt;
        newTile.GetComponent<TileLogicController>().SetValue(value);
        newTile.GetComponent<Tiles3DSpawner>().SpawnModel(didLeftPlayerDestroyIt);
        tiles.Add(newTile);
    }
}
