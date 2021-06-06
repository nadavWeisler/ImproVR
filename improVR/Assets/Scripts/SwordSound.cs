using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSound : MonoBehaviour
{
    AudioSource sword;
    int currentPitch;
    // Start is called before the first frame update
    void Start()
    {
        this.currentPitch = 0;
        sword = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        this.currentPitch += 1;
        sword.pitch = this.currentPitch; 
        sword.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
