using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Stump : MonoBehaviour
{
    [SerializeField]
    private Material vol1;
    [SerializeField]
    private Material vol2;
    [SerializeField]
    private Material vol3;
    [SerializeField]
    private Material vol4;
    [SerializeField]
    private Material vol5;
    private List<Material> volList;
    private List<AudioSource> audioSourcesList;
    private List<GameObject> musicObjectList;
    private float currentPitch;
    private int currentVolume;
    private bool notEmpty;

    // Start is called before the first frame update
    void Start()
    {
        this.audioSourcesList = new List<AudioSource>();
        this.musicObjectList = new List<GameObject>();
        this.volList = new List<Material>();
        this.notEmpty = false;
        this.currentVolume = 2;
        this.createVolList();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.notEmpty)
        {
            float rotation = 30f * Time.deltaTime * 1f;
            foreach (GameObject musicObject in this.musicObjectList)
            {
                musicObject.transform.RotateAround(this.transform.position, new Vector3(0f, 1f, 0f), rotation);
            }
        }
    }

    //On trigger stump
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.tag == "music")
        {
            other.transform.gameObject.tag = "hologram";
            this.musicObjectList.Add(other.transform.gameObject);
            this.notEmpty = true;
            this.audioSourcesList.Add(other.transform.GetComponent<AudioSource>());
            var newObj = Instantiate(other.transform, new Vector3(Random.Range(-200f, 20f), 20, Random.Range(-200f, 20f)), Quaternion.identity);
            Rigidbody newRig = newObj.transform.GetComponent<Rigidbody>();
            newRig.useGravity = true;
            newRig.isKinematic = false;
            other.transform.GetComponent<AudioSource>().loop = false;
            other.transform.GetComponent<AudioSource>().spatialBlend = 0f;
            Rigidbody rigidbody = other.transform.GetComponent<Rigidbody>();
            rigidbody.useGravity = false;
            rigidbody.isKinematic = true;
            other.isTrigger = true;
            other.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 3f * this.audioSourcesList.Count, this.transform.position.z);
            other.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            other.transform.GetComponent<Renderer>().material = vol3;
        }
        else if (other.transform.gameObject.tag == "needle")
        {
            foreach (AudioSource audioSource in this.audioSourcesList)
            {
                audioSource.mute = false;
                audioSource.Play();
            }
        }
        else if (other.transform.gameObject.tag == "delete")
        {
            if(this.notEmpty)
            {
                this.audioSourcesList = new List<AudioSource>();
                foreach (GameObject musicObject in this.musicObjectList)
                {
                    Destroy(musicObject);
                }
                this.musicObjectList = new List<GameObject>();
                this.notEmpty = false;
            }
            var newObj = Instantiate(other.transform, new Vector3(10.4f, 2.1f, -49f), Quaternion.identity);
            Rigidbody newRig = newObj.transform.GetComponent<Rigidbody>();
            newRig.useGravity = true;
            newRig.isKinematic = false;
            Destroy(other.transform.gameObject);
        }
        else if (other.transform.gameObject.tag == "pitchUp")
        {
            if(this.currentPitch < 5f && this.notEmpty)
            {
                foreach (AudioSource audioSource in this.audioSourcesList)
                {
                    audioSource.pitch *= 2f;
                }
                if (this.audioSourcesList.Count > 0)
                {
                    this.currentPitch = this.audioSourcesList[0].pitch;
                }
                this.transform.localScale = new Vector3(
                    this.transform.localScale.x,
                    this.transform.localScale.y,
                    this.transform.localScale.z + 70f
                );
            }
            var newObj = Instantiate(other.transform, new Vector3(13f, 1.5f, -50f), Quaternion.identity);
            Rigidbody newRig = newObj.transform.GetComponent<Rigidbody>();
            newRig.useGravity = true;
            newRig.isKinematic = false;
            Destroy(other.transform.gameObject);
        }
        else if (other.transform.gameObject.tag == "pitchDown")
        {
            if(this.currentPitch > 0.1f && this.notEmpty)
            {
                foreach (AudioSource audioSource in this.audioSourcesList)
                {
                    audioSource.pitch /= 2f;
                }
                if (this.audioSourcesList.Count > 0)
                {
                    this.currentPitch = this.audioSourcesList[0].pitch;
                }
                this.transform.localScale = new Vector3(
                    this.transform.localScale.x,
                    this.transform.localScale.y,
                    this.transform.localScale.z - 70f
                );
            }
            var newObj = Instantiate(other.transform, new Vector3(15f, 1.75f, -49f), Quaternion.identity);
            Rigidbody newRig = newObj.transform.GetComponent<Rigidbody>();
            newRig.useGravity = true;
            newRig.isKinematic = false;
            Destroy(other.transform.gameObject);
        }
        else if (other.transform.gameObject.tag == "volUp")
        {
            if (this.currentVolume < 4 && this.audioSourcesList.Count > 0)
            {
                foreach (AudioSource audioSource in this.audioSourcesList)
                {
                    audioSource.volume += 0.5f;
                }
                foreach (GameObject musicObject in this.musicObjectList)
                {
                    musicObject.transform.GetComponent<Renderer>().material = this.volList[this.currentVolume + 1];
                }
                
            }
            var newObj = Instantiate(other.transform, new Vector3(7.3f, 1.5f, -50f), Quaternion.identity);
            Rigidbody newRig = newObj.transform.GetComponent<Rigidbody>();
            newRig.useGravity = true;
            newRig.isKinematic = false;
            Destroy(other.transform.gameObject);
        }
        else if (other.transform.gameObject.tag == "volDown")
        {
            if (this.currentVolume > 0 && this.audioSourcesList.Count > 0)
            {
                foreach (AudioSource audioSource in this.audioSourcesList)
                {
                    audioSource.volume -= 0.5f;
                }
                foreach (GameObject musicObject in this.musicObjectList)
                {
                    musicObject.transform.GetComponent<Renderer>().material = this.volList[this.currentVolume - 1];
                }
            }
            var newObj = Instantiate(other.transform, new Vector3(4f, 1.5f, -49f), Quaternion.identity);
            Rigidbody newRig = newObj.transform.GetComponent<Rigidbody>();
            newRig.useGravity = true;
            newRig.isKinematic = false;
            Destroy(other.transform.gameObject);
        }
    }

    //Create holograms list
    private void createVolList()
    {
        this.volList.Add(this.vol1);
        this.volList.Add(this.vol2);
        this.volList.Add(this.vol3);
        this.volList.Add(this.vol4);
        this.volList.Add(this.vol5);
    }
}
