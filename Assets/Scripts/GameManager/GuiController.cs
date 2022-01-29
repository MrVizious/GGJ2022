using System.Collections;
using System.Collections.Generic;
using RoboRyanTron.Unite2017.Events;
using TMPro;
using UnityEngine;

public class GuiController : MonoBehaviour
{
    public GameData data;
    public TextMeshProUGUI leftTextScore;
    public TextMeshProUGUI rightTextScore;
    // Start is called before the first frame update
    private void Start() {
        leftTextScore.text = "" + 0;
        rightTextScore.text = "" + 0;
    }

    public void UpdateGUI(){
        leftTextScore.text = "" + data.leftScore;
        rightTextScore.text = "" + data.rightScore;
    }
}
