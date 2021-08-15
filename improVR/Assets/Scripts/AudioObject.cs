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

    public GameObject box;

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

    // private void OnTriggerEnter(Collider other) {
    //     box.SetActive(!box.activeSelf);
    //     if (other.gameObject.transform.tag == "hand")
    //     {
    //         GameObject small_clone = Instantiate(this.gameObject);
    //         Vector3 scale = small_clone.transform.localScale;
    //         this.transform.localScale = new Vector3(scale.x / 10f, scale.y / 10f, scale.z / 10f);
    //         small_clone.name = this.gameObject.name;
    //         small_clone.tag = this.gameObject.tag;
            
    //         rand_x = Random.Range(-180f, 20f);
    //         rand_z = Random.Range(-180f, 20f);
    //         rand_rotation = Random.Range(0f, 360f);

    //         center = new Vector3(rand_x, this.transform.position.y, rand_z);
    //         this.transform.position = center;
    //         this.transform.Rotate(0, rand_rotation, 0, Space.Self);
    //         //check if new position is empty
    //         // Collider[] hitColliders = Physics.OverlapSphere(center, 1f);
    //         // while (hitColliders != null && hitColliders.Length > 1)
    //         // {
    //         //     rand_x = Random.Range(-180f, 450f);
    //         //     rand_z = Random.Range(-180f, 450f);
    //         //     rand_rotation = Random.Range(0f, 360f);
    //         //     center = new Vector3(rand_x, this.transform.position.y, rand_z);
    //         //     this.transform.position = center;
    //         //     this.transform.Rotate(0, rand_rotation, 0, Space.Self);
    //         //     hitColliders = Physics.OverlapSphere(center, 1f);
    //         // }
    //     }
    // }
    public void muteObject(bool mute)
    {
        this.mute = mute;
    }
}
