using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

[Serializable]
public class vocab_item
{
    public string vocab_name;
    public Texture2D imageItem;
    public List<vocab_item_character> char_item;
}

[Serializable]
public class vocab_item_character
{
    public string character;
    public Texture2D imageCharacter;
}
public class vocab_script : MonoBehaviour
{
    public static vocab_script instance;
    [Header("WORD")]
    [SerializeField]
    List<vocab_item> items;
    [SerializeField]
    int length_word;
    public vocab_item currentVocab;
    public int currentWord;
    public List<word_character> _wordChar;

    [Header("WORD SETTING")]
    [SerializeField]
    RawImage mainImage;
    [SerializeField]
    GameObject bubbleArea;
    [SerializeField]
    GameObject wordArea;
    [SerializeField]
    GameObject bubble;
    [SerializeField]
    GameObject char_prefab;
    [SerializeField]
    int indexItem;
 

    private void Awake()
    {
        instance = this;
    }


    async void Start()
    {
        await create_vocab(indexItem);
    }


    async Task create_vocab(int index)
    {
        if (index < items.Count)
        {
            reset_item();
            _wordChar.Clear();
            currentWord = 0;
            currentVocab = items[index];
            length_word = currentVocab.char_item.Count;
            mainImage.texture = currentVocab.imageItem;
            mainImage.GetComponent<AspectRatioFitter>().aspectRatio = (float)currentVocab.imageItem.width / currentVocab.imageItem.height;
            int start = 0;
            foreach (vocab_item_character item in currentVocab.char_item)
            {
                Spawn_character_item(item.imageCharacter, item.character, start);
                Spawn_bubble(item.character, start);
                await Task.Delay(TimeSpan.FromSeconds(.35f));
                start++;
            }
        }
    }

    void reset_item()
    {
        foreach (Transform item in bubbleArea.transform)
        {
            Destroy(item.gameObject);
        }


        foreach (Transform item_char in wordArea.transform)
        {
            Destroy(item_char.gameObject);
        }
    }
    void Spawn_bubble(string character_item,int index)
    {
        GameObject bubbleSpawn = Instantiate(bubble, bubbleArea.transform,false);
        bubbleSpawn.transform.position = new Vector3(bubbleSpawn.transform.position.x + Random.Range(0, 5), bubbleSpawn.transform.position.y, bubbleSpawn.transform.position.z);
        bubbleSpawn.GetComponent<word_bubble>().word = character_item;
        bubbleSpawn.GetComponent<word_bubble>().itemIndex = index;
    }

    void Spawn_character_item(Texture2D texture_char = null, string character_item="", int index=-1)
    {
        GameObject char_item = Instantiate(char_prefab, wordArea.transform, false);
        char_item.GetComponent<word_character>().setValue(texture_char, character_item, index);
        _wordChar.Add(char_item.GetComponent<word_character>());
    }


    public async Task correct_wordAsync()
    {
        _wordChar[currentWord].correct_word();
        currentWord++;
        if(currentWord == length_word)
        {
            indexItem++;
            await Task.Delay(TimeSpan.FromSeconds(1f));
            await create_vocab(indexItem);
        }
    }
}
