using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Box1 : MonoBehaviour
{
    [SerializeField]
    private Material hologram;
    private AudioSource audioSource;
    private List<AudioSource> audioSourcesList;
    private AudioClip clip;
    private AudioManager audio_manager;
    private Vector3 position;
    private float base_vol;
    private GameObject music_object;
    private List<GameObject> musicObjectList;
    private float pitch;
    private float volume;
    private bool not_empty;

    // Start is called before the first frame update
    void Start()
    {
        this.audioSourcesList = new List<AudioSource>();
        this.not_empty = false;
        this.musicObjectList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.not_empty)
        {
            float rotation = 30f * Time.deltaTime * 1f;
            foreach (GameObject musicObject in this.musicObjectList)
            {
                musicObject.transform.RotateAround(this.transform.position, new Vector3(0f, 1f, 0f), rotation);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.tag == "music")
        {
            this.musicObjectList.Add(other.transform.gameObject);
            this.not_empty = true;
            this.audioSourcesList.Add(other.transform.GetComponent<AudioSource>());
            print(other.transform.GetComponent<AudioSource>().pitch);
            Instantiate(other.transform, new Vector3(Random.Range(-200f, 20f), 20, Random.Range(-200f, 20f)), Quaternion.identity);
            other.transform.GetComponent<AudioSource>().loop = false;
            Rigidbody rigidbody = other.transform.GetComponent<Rigidbody>();
            rigidbody.useGravity = false;
            rigidbody.isKinematic = true;
            other.isTrigger = true;
            other.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 2.5f * this.audioSourcesList.Count, this.transform.position.z);
            other.transform.GetComponent<Renderer>().material = hologram;
        }
        else if (other.transform.gameObject.tag == "needle")
        {
            foreach (AudioSource audioSource in this.audioSourcesList)
            {
                audioSource.Play();
            }
        }
        else if (other.transform.gameObject.tag == "delete" && this.not_empty)
        {
            this.audioSourcesList = new List<AudioSource>();
            foreach (GameObject musicObject in this.musicObjectList)
            {
                Destroy(musicObject);
            }
            this.musicObjectList = new List<GameObject>();
            this.not_empty = false;
            Instantiate(other.transform, new Vector3(25, 30, -37), Quaternion.identity);
            Destroy(other.transform.gameObject);
        }
        else if (other.transform.gameObject.tag == "pitchUp" && this.pitch < 5f && this.not_empty)
        {
            foreach (AudioSource audioSource in this.audioSourcesList)
            {
                audioSource.pitch *= 2f;
            }
            if (this.audioSourcesList.Count > 0)
            {
                this.pitch = this.audioSourcesList[0].pitch;
            }
            this.transform.localScale = new Vector3(
                this.transform.localScale.x,
                 this.transform.localScale.y,
                 this.transform.localScale.z + 70f
            );
            Instantiate(other.transform, new Vector3(25, 30, -37), Quaternion.identity);
            Destroy(other.transform.gameObject);
        }
        else if (other.transform.gameObject.tag == "pitchDown" && this.pitch > 0.1f && this.not_empty)
        {
            foreach (AudioSource audioSource in this.audioSourcesList)
            {
                audioSource.pitch /= 2f;
            }
            if (this.audioSourcesList.Count > 0)
            {
                this.pitch = this.audioSourcesList[0].pitch;
            }
            this.transform.localScale = new Vector3(
                this.transform.localScale.x,
                 this.transform.localScale.y,
                 this.transform.localScale.z - 70f
            );
            Instantiate(other.transform, new Vector3(25, 30, -37), Quaternion.identity);
            Destroy(other.transform.gameObject);
        }
        else if (other.transform.gameObject.tag == "volUp")
        {
            foreach (AudioSource audioSource in this.audioSourcesList)
            {
                audioSource.volume += 0.5f;
            }
            if (this.audioSourcesList.Count > 0)
            {
                this.volume = this.audioSourcesList[0].volume;
            }
            this.hologram.color = new Vector4(
                this.hologram.color.r + 1f, 
                this.hologram.color.g, 
                this.hologram.color.b, 
                this.hologram.color.a
            );
            // this.transform.localScale.Set(
            //     this.transform.localScale.x,
            //      this.transform.localScale.y,
            //      this.transform.localScale.z - 50f
            // );
            Instantiate(other.transform, new Vector3(25, 30, -37), Quaternion.identity);
            Destroy(other.transform.gameObject);
        }
        else if (other.transform.gameObject.tag == "volDown")
        {
            Instantiate(other.transform, new Vector3(25, 30, -37), Quaternion.identity);
            Destroy(other.transform.gameObject);
        }
    }
}
