using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnController : MonoBehaviour
{
    public Sprite imgPPal;
    public Sprite imgHov;
    public Button btn;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onHover(){
       btn.GetComponent<Image>().sprite = imgHov;
    }

    public void onExit(){
       btn.GetComponent<Image>().sprite = imgPPal;
    }
}
