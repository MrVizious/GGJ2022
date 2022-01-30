using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class EmptyTileLogicController : MonoBehaviour
{
    private bool isLeftTurn;
    public int value;
    public void Disappear() {
        Disappear(GameObject.Find("GameController").GetComponent<GameController>().GetIsLeftTurn());
    }
    public void Disappear(bool currentIsLeftTurn) {
        isLeftTurn = currentIsLeftTurn;
        GetComponent<DisappearingAnimation>().Disappear();
    }

    private void OnDestroy() {
        GameObject.Find("GameController").GetComponent<GameController>().EmptyTileDestroyed(transform, isLeftTurn);
    }
}


#if UNITY_EDITOR
[CustomEditor(typeof(EmptyTileLogicController))]
public class EmptyTileLogicControllerEditor : Editor
{
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        EmptyTileLogicController emptyTileLogicController = (EmptyTileLogicController)target;

        if (GUILayout.Button("Disappear"))
        {
            emptyTileLogicController.Disappear();
        }
    }
}
#endif
