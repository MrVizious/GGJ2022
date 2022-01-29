using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuiController : MonoBehaviour
{

    public  TextMeshProUGUI leftTextScore;
    public TextMeshProUGUI  rightTextScore;
    // Start is called before the first frame update
    void Start()
    {
        leftTextScore.text = "" + 0;
        rightTextScore.text = "" + 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
