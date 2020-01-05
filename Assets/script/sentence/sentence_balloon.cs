using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sentence_balloon : MonoBehaviour
{
    public int indexWord;
    public RawImage imageBalloon;
    public string word_balloon;
    

    public void set_balloon(int index,Texture2D texture_image,string word)
    {
        this.indexWord = index;
        if(texture_image != null)
        {
            imageBalloon.texture = texture_image;
            //imageBalloon.GetComponent<AspectRatioFitter>().aspectRatio = (float)texture_image.width / texture_image.height;
        }

        this.word_balloon = word;
    }


    public async void button_event()
    {
        if (indexWord == sentence_script.instance.current_index)
        {
            Destroy(this.gameObject);
            await sentence_script.instance.correct_wordAsync();
            
        }
    }

}
