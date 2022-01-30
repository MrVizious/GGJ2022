using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Tiles3DSpawner : MonoBehaviour
{
    public TileLogicController logic;
    public Pool3DModels poolTech, poolNature;
    private GameObject model;

    private void Start() {
        logic = GetComponent<TileLogicController>();
    }

    public void SpawnModel(bool isLeft) {
        if(model != null){
            Destroy(model);
        }
        
        Pool3DModels pool = isLeft ? poolTech : poolNature;
        model = Instantiate(pool.GetRandomModel(), transform.position, transform.rotation, transform);
        model.AddComponent<AppearingAnimation>();
        if(!isLeft){
            model.transform.RotateAround(transform.position, Vector3.right - Vector3.forward, 180f);
        }
    }

}

#if UNITY_EDITOR
[CustomEditor(typeof(Tiles3DSpawner))]
public class Tiles3DSpawnerEditor : Editor
{
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        Tiles3DSpawner tiles3DSpawner = (Tiles3DSpawner)target;

        if (GUILayout.Button("Spawn Tile"))
        {
            tiles3DSpawner.SpawnModel(tiles3DSpawner.logic.isLeft);
        }
    }
}
#endif
