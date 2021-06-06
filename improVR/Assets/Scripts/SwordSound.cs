using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSound : MonoBehaviour
{
    AudioSource sword;
    // Start is called before the first frame update
    void Start()
    {
        sword = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) {
        sword.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
