using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class word_character : MonoBehaviour
{
    public int index;
    public string textChar;
    public RawImage imageChar;
    public bool isSet;
    public void setValue(Texture2D texture,string textChar, int index)
    {
        if(texture != null)
        {
            imageChar.texture = texture;
            imageChar.GetComponent<AspectRatioFitter>().aspectRatio = (float)texture.width / texture.height;
        }

        this.textChar = textChar;
        this.index = index;
        this.gameObject.name = textChar;
    }

    public void correct_word()
    {
        imageChar.gameObject.SetActive(true);
    }
}
