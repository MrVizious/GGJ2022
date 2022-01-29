using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGrid : MonoBehaviour
{
    public int GridSize;
    public GameObject TilePrefab;
    public int PerlinRange;
    public float PerlinScale;
    float[,] P;
    void Start()
    {
        float GridOffset = (float)GridSize/2.0f;
        GeneratePerlinGrid(GridSize);
        for(int i = 0; i < GridSize; i++)
        {
            for(int j = 0; j < GridSize; j++)
            {
                SpawnTile(TilePrefab, i, j, GridOffset);
            }
        }
    }

    private void SpawnTile(GameObject tile_prefab, int pos_x, int pos_z, float grid_offset){
        Vector3 pos = new Vector3 (pos_x - grid_offset,0,pos_z - grid_offset);
        UnityEngine.Quaternion rot = new UnityEngine.Quaternion(0f,0f,0f,0f);
        GameObject newTile = Instantiate(tile_prefab, pos, rot);
        newTile.GetComponent<Renderer>().material.SetColor("_Color", new Color(P[pos_x,pos_z],0f,0f));
        //if(pos_x == GridSize -1 && pos_z == GridSize -1){newTile.GetComponent<Renderer>().material.SetColor("_Color", new Color(0f,0f,0f));}
    }

    private float[,] GeneratePerlinGrid(int size){
        int PerlinOffset = (int)Mathf.Floor(Random.Range(0f,(float)PerlinRange));
        P = new float[size,size];
        for(int i = 0; i < size; i++)
        {
            for(int j = 0; j < size; j++)
            {
                P[i,j] = Mathf.PerlinNoise(PerlinOffset + PerlinScale*i*0.99f,PerlinOffset + PerlinScale*j*0.99f);
            }
        }
        return P;
    }
}
