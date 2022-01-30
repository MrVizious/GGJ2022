using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Pool3DModels", menuName = "Pool3DModels", order = 1)]
public class Pool3DModels : ScriptableObject
{
    public List<GameObject> models;

    public GameObject GetRandomModel() {
        return models[Random.Range(0, models.Count)];
    }

    public List<GameObject> GetRandomModelList(int count) {
        List<GameObject> list = new List<GameObject>();
        for(int i = 0; i < count; i++) {
            list.Add(GetRandomModel());
        }
        return list;
    }
}