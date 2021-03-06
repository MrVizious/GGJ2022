using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;


public class GenerateGrid : MonoBehaviour
{
    public int GridSize;
    public GameObject TilePrefab;
    public int PerlinRange;
    public float PerlinScale;
    GameObject[,] TilesGrid;
    float[,] P;
    void Start() {
        TilesGrid = new GameObject[GridSize, GridSize];
        float GridOffset = (float)GridSize / 2.0f;
        GeneratePerlinGrid(GridSize);
        TilesGrid = new GameObject[GridSize, GridSize];
        for (int i = 0; i < GridSize; i++)
        {
            for (int j = 0; j < GridSize; j++)
            {
                SpawnTile(TilePrefab, i, j, GridOffset);
            }
        }
    }

    private void SpawnTile(GameObject tile_prefab, int pos_x, int pos_z, float grid_offset) {
        Vector3 pos = new Vector3(pos_x - grid_offset, 0, pos_z - grid_offset);
        Quaternion rot = new Quaternion(0f, 0f, 0f, 0f);
        TilesGrid[pos_x, pos_z] = Instantiate(tile_prefab, pos, rot);
        GameObject newTile = TilesGrid[pos_x, pos_z];
        TilesGrid[pos_x, pos_z].GetComponent<EmptyTileLogicController>().SetValue((int)Mathf.Ceil(P[pos_x, pos_z] * 10));
        newTile.GetComponentInChildren<TextMeshPro>().text = Mathf.Ceil(P[pos_x, pos_z] * 10).ToString();
        //TilesGrid[pos_x,pos_z] = newTile;
        newTile.GetComponent<Renderer>().material.SetColor("_Color", new Color(1 - P[pos_x, pos_z], 0f, 0f));
        //if(pos_x == GridSize -1 && pos_z == GridSize -1){newTile.GetComponent<Renderer>().material.SetColor("_Color", new Color(0f,0f,0f));}
    }

    private float[,] GeneratePerlinGrid(int size) {
        int PerlinOffset = (int)Mathf.Ceil(Random.Range(0f, (float)PerlinRange));
        P = new float[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                P[i, j] = Mathf.PerlinNoise(PerlinOffset + PerlinScale * i * 0.99f, PerlinOffset + PerlinScale * j * 0.99f);
            }
        }
        return P;
    }
}
