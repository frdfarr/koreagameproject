using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

[Serializable]
public class sentence_item
{
    [SerializeField]
    string sentence_name;
    public Texture2D word_thai;
    public List<sentence_item_character> char_item;
}

[Serializable]
public class sentence_item_character
{
    public string character;
    public Texture2D imageCharacter;
}

public class sentence_script : MonoBehaviour
{
    [Header("SENTENCE")]
    [SerializeField]
    List<sentence_item> _sentence_item;
    [SerializeField]
    sentence_item currenct_sentence;
    public static sentence_script instance;
    public List<word_character> _wordChar;

    [Header("SENTENCE SETTIGN")]
    [SerializeField]
    GameObject balloon_area;
    [SerializeField]
    GameObject balloon_item;
    [SerializeField]
    GameObject character_area;
    [SerializeField]
    RawImage imageTextThai;
    [SerializeField]
    GameObject character_item;
    [SerializeField]
    public int current_index;
    [SerializeField]
    int index_sentence;
    [SerializeField]
    int length_word;

    private void Awake()
    {
        instance = this;
    }

    void reset_item()
    {
        foreach (Transform item in balloon_area.transform)
        {
            Destroy(item.gameObject);
        }


        foreach (Transform item_char in character_area.transform)
        {
            Destroy(item_char.gameObject);
        }
    }

    void create_sentence(int index)
    {
        if (index < _sentence_item.Count)
        {
            reset_item();
            _wordChar.Clear();
            currenct_sentence = _sentence_item[index];
            current_index = 0;
            length_word = currenct_sentence.char_item.Count;
            imageTextThai.texture = currenct_sentence.word_thai;
            imageTextThai.GetComponent<AspectRatioFitter>().aspectRatio = (float)currenct_sentence.word_thai.width / currenct_sentence.word_thai.height;
            int start = 0;
            foreach (sentence_item_character item in currenct_sentence.char_item)
            {

                create_balloon_sentence(item.imageCharacter, start, item.character);
                create_character_sentence(item.imageCharacter, start, item.character);
                start++;
            }

            random_balloon();
        }
    }


    void random_balloon()
    {
        foreach (Transform item in balloon_area.transform)
        {
            int random = Random.Range(0, currenct_sentence.char_item.Count);
            item.SetSiblingIndex(random);
        }
    }


    void create_balloon_sentence(Texture2D image,int index,string word)
    {
        GameObject balloon = Instantiate(balloon_item, balloon_area.transform, false);
        balloon.GetComponent<sentence_balloon>().set_balloon(index, image, word);
    }

    void create_character_sentence(Texture2D image, int index, string word)
    {
        GameObject character = Instantiate(character_item, character_area.transform, false);
        character.GetComponent<word_character>().setValue(image, word, index);
        _wordChar.Add(character.GetComponent<word_character>());
    }
    // Start is called before the first frame update
    void Start()
    {
        create_sentence(index_sentence);
    }

    public async Task correct_wordAsync()
    {
        _wordChar[current_index].correct_word();
        current_index++;
        if (current_index == length_word)
        {
            index_sentence++;
            await Task.Delay(TimeSpan.FromSeconds(1f));
            create_sentence(index_sentence);
        }
    }

}
