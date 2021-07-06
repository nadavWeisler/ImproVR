using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioObject : MonoBehaviour
{
    public AudioSource audioSource;
    public bool mute;
 
    // Start is called before the first frame update
    void Start()
    {
        this.audioSource = this.GetComponent<AudioSource>();
        this.audioSource.loop = true;
        this.mute = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mute)
        {
            this.audioSource.mute = true;
            this.audioSource.loop = false;
        }
        else
        {
            this.audioSource.mute = false;
            this.audioSource.loop = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {     
        if (collision.transform.tag == "hand")
        {
            GameObject small_clone = Instantiate(gameObject, collision.transform.position, gameObject.transform.rotation);
            Vector3 scale = small_clone.transform.localScale;
            small_clone.transform.localScale = new Vector3(scale.x / 10f, scale.y / 10f, scale.z / 10f);
            small_clone.name = gameObject.name;
            small_clone.tag = gameObject.tag;
        }
    }

    public void muteObject(bool mute)
    {
        this.mute = mute;
    }
}
