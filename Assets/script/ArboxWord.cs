using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArboxWord : MonoBehaviour
{

    public Sprite imageActive;
    public Image word_img;

    public void imageActiveChange()
    {
        word_img.sprite = imageActive;
    }
}
