using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameData data;
    public GameObject tilePrefab;
    private List<GameObject> tiles = new List<GameObject>();

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

    public void EmptyTileDestroyed(Transform t) {
        Quaternion rotation = GetIsLeftTurn() ? Quaternion.Euler(0, 0, 0) : Quaternion.Euler(0, -90, 180);
        GameObject newTile = Instantiate(tilePrefab, new Vector3(t.position.x, 0f, t.position.z), Quaternion.identity);
        newTile.GetComponent<TileLogicController>().isLeft = GetIsLeftTurn();
        newTile.GetComponent<Tiles3DSpawner>().SpawnModel();
        tiles.Add(newTile);
    }
}
