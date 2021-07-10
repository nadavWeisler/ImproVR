using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if(this.gameObject.transform.localPosition[1] > 1) {
        //     Destroy(this);
        // }
    } 

    private void OnCollisionEnter(Collision other) {
        var audio = this.gameObject.GetComponent<AudioSource>();
        audio.mute = false;
    }
}
