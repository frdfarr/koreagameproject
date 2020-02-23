using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class word_bubble : MonoBehaviour
{
    public TextMeshProUGUI text_bubble;
    public int itemIndex;
  public string word
    {
        get => text_bubble.text;
        set
        {
            Word = value;
            text_bubble.text = Word;
        }
    }

    [SerializeField]
    private string Word;

    public async void button_event()
    {
        if(itemIndex == vocab_script.instance.currentWord)
        {
            Destroy(this.gameObject);
            await vocab_script.instance.correct_wordAsync();
            
        }
    }
}
