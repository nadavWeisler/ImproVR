using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private float speed;
    private bool isPlaying;
    private Vector3 needlePos;

    [SerializeField]
    private GameObject needle;
    [SerializeField]
    private GameObject needleStart;
    [SerializeField]
    private GameObject playerStartPostion;

    // Start is called before the first frame update
    void Start()
    {
        this.speed = 1.25f;
        this.needlePos = this.needleStart.transform.position;
        this.isPlaying = false;
        this.needle.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (this.isPlaying)
        {
            this.needle.transform.RotateAround(
                this.needlePos,
                new Vector3(0f, 1f, 0f),
                30f * Time.deltaTime * this.speed
            );
        }
    }

    private void muteEnvironment(bool isMute)
    {
        GameObject[] musicObjects = GameObject.FindGameObjectsWithTag("music");
        foreach (GameObject musicObject in musicObjects)
        {
            musicObject.transform.GetComponent<AudioSource>().mute = isMute;
        }
        musicObjects = GameObject.FindGameObjectsWithTag("hologram");
        foreach (GameObject musicObject in musicObjects)
        {
            musicObject.transform.GetComponent<AudioSource>().mute = !isMute;
        }
    }

    public void play()
    {
        this.isPlaying = true;
        this.muteEnvironment(true);
        this.needle.SetActive(true);
    }

    public void stop()
    {
        this.isPlaying = false;
        this.muteEnvironment(false);
        this.needle.SetActive(false);
    }

    public void returnPlayerToStumps()
    {
        this.transform.position = this.playerStartPostion.transform.position;
    }

    public void upSpeed() {
        if(this.speed < 3f)
        {
            this.speed += 0.25f;
        }
    }

    public void downSpeed() {
        if(this.speed > 0.25f) 
        {
            this.speed -= 0.25f;
        }
    }

}