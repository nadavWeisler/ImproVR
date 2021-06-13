using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    string UserName;
    List<AudioClip> audios;

    SoundManager manager;
    int index = 0;

    bool play;

    void Start()
    {
        this.audios = new List<AudioClip>();
        play = false;
    }

    private void Update() 
    {
        if(this.play) {
            manager.PlaySound(this.audios[index]);
            index = index + 1 == this.audios.Count ? 0 : index + 1;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "button")
        {
            this.play = true;  
        }
        else
        {
            var col = other.gameObject.GetComponent<AudioSource>();
            this.audios.Add(col.clip);
            Debug.Log(this.audios);
        }
    }
}
