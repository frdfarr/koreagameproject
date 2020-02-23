using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wordScript : MonoBehaviour
{
    public AudioSource sound_setting;
    public Animator anim;
    bool isAnim;
    public void OnMouseDown()
    {
        sound_setting.Play();
        if (!isAnim)
        {
            anim.SetTrigger("in");
        }

    }

    private void Update()
    {
        if(GetComponent<SpriteRenderer>().enabled == false)
        {
            sound_setting.Stop();
        }
    }
    // Start is called before the first frame update

}
