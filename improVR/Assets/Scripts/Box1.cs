using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Box1 : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip clip;
    private AudioManager audio_manager;
    private float pitch;
    private Vector3 position;
    private float base_vol;

    // Start is called before the first frame update
    void Start()
    {
        this.audioSource = this.GetComponent<AudioSource>();
        this.position = this.gameObject.transform.position;
        this.pitch = this.position.y;
        this.audioSource.volume = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setParant(AudioManager parant)
    {
        this.audio_manager = parant;
        this.base_vol = this.distance(this.position.x, this.audio_manager.transform.position.x,
            this.position.z, this.audio_manager.transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "music")
        {
            this.clip = this.audio_manager.getAudioClip(collision.gameObject.name);
            this.audioSource.clip = clip;
        }
        else if (collision.gameObject.tag == "needle")
        {
            this.audioSource.Play();
        }
        else
        {
            this.checkProperties();
        }
    }

    private void checkProperties()
    {
        float new_y = this.transform.position.y;
        float new_pitch = new_y - this.pitch;
        if (new_pitch != 0f)
        {
            this.pitch = new_y;
            this.audioSource.pitch = new_pitch;
        }

        float distance = this.distance(this.transform.position.x, this.audio_manager.transform.position.x,
            this.transform.position.z, this.audio_manager.transform.position.z);
        if (distance > this.base_vol)
        {
            float new_vol = (distance - this.base_vol) / (2f * this.base_vol);
            if (new_vol >= (2f * this.base_vol))
            {
                this.audioSource.volume = 0f;
            }
            else
            {
                this.audioSource.volume = new_vol;
            }
        }
        else
        {
            this.audioSource.volume = (distance + this.base_vol) / (2f * this.base_vol);
        }
    }

    private AudioSource GetAudioSource()
    {
        if (this.clip != null)
        {
            return this.audioSource;
        }
        else
        {
            return null;
        }
    }

    private float distance(float x_1, float y_1, float x_2, float y_2)
    {
        return (Mathf.Sqrt(Mathf.Pow((x_2 - x_1), 2) + Mathf.Pow((y_2 - y_1), 2)));
    }
}
