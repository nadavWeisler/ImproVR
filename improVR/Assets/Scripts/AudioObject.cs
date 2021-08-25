using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class AudioObject : MonoBehaviour
{
    public AudioSource audioSource;
    public bool mute;
    private float rand_x;
    private float rand_z;
    private float rand_rotation;
    private Vector3 center;

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

    public void muteObject(bool mute)
    {
        this.mute = mute;
    }
}
