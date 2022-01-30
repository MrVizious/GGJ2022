using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public GameObject NatureOST;
    public GameObject TechOST;
    public GameData data;

    void Start()
    {
        changeSound();
    }

    public void changeSound(){
        if(data.isLeftTurn){
            NatureOST.GetComponent<AudioSource>().volume = 1;
            TechOST.GetComponent<AudioSource>().volume = 0;
        }else {
            TechOST.GetComponent<AudioSource>().volume = 1;
            NatureOST.GetComponent<AudioSource>().volume = 0;
        }
    }
}