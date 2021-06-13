using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
 {
     public AudioSource audioSource;
     Queue<AudioClip> clipQueue;
     void Update()
     {
         if (audioSource.isPlaying == false && clipQueue.Count > 0) {
             audioSource.clip = clipQueue.Dequeue();
             audioSource.Play();
         }
     }
     public void PlaySound(AudioClip clip)
     {
         clipQueue.Enqueue(clip);
     }
 }