using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceAnimationController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)){
            rotatePiece();
        }
    }

    public void rotatePiece(){
        transform.Rotate(0,90,0,Space.Self);
    }
}
