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
        this.audioSource = new AudioSource();
        // this.position = this.gameObject.transform.position;
        // this.pitch = this.position.y;
        // this.audioSource.volume = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "music")
        {
            //this.clip = this.audio_manager.getAudioClip(other.gameObject.name);
            this.audioSource.clip = other.GetComponent<AudioSource>().clip;
            other.GetComponent<AudioSource>().loop = false;
            // Rigidbody rigidbody =  other.transform.GetComponent<Rigidbody>();
            // rigidbody.useGravity = false;
            // rigidbody.isKinematic = true;
            // other.isTrigger = true;
            other.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.5f, this.transform.position.z);
        }
        else if (other.gameObject.tag == "needle")
        {
            this.audioSource.Play();
        }
        // else if (other.gameObject.tag == "hand")
        // {
        //      this.checkProperties();
        // }
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
