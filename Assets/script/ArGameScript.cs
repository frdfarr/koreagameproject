using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ar_item
{
    public Sprite item_notActive;
    public Sprite item_Active;
    public GameObject ar_object;
}


public class ArGameScript : MonoBehaviour
{
    [Header("Game Setting")]
    public List<ar_item> _arItem;
    public ArboxWord _boxWord;
    public Transform boxParent;
    // Start is called before the first frame update
    void Start()
    {
        create_word();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   void create_word()
    {
        foreach (ar_item item in _arItem)
        {
            ArboxWord clone_box = Instantiate(_boxWord, boxParent, false);
            clone_box.word_img.sprite = item.item_notActive;
            clone_box.imageActive = item.item_Active;
            item.ar_object.GetComponent<ArGameClick>().imageBox = clone_box;
        }
    }
}
