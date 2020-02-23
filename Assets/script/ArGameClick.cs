using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArGameClick : MonoBehaviour
{
    public ArboxWord imageBox;
    public int indexitem;


    private void OnMouseDown()
    {
        
        imageBox.imageActiveChange();
    }
}
