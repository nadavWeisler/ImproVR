using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private GameObject musicBox1;

    [SerializeField]
    private GameObject musicBox2;

    [SerializeField]
    private GameObject musicBox3;

    [SerializeField]
    private GameObject musicBox4;

    [SerializeField]
    private GameObject musicBox5;

    [SerializeField]
    private GameObject musicBox6;

    [SerializeField]
    private GameObject musicBox7;

    [SerializeField]
    private GameObject musicBox8;

    [SerializeField]
    private GameObject musicBox9;

    [SerializeField]
    private GameObject musicBox10;

    [SerializeField]
    private GameObject musicBox11;

    [SerializeField]
    private GameObject musicBox12;


    private List<AudioSource> loop;
    private List<GameObject> boxes;
    private Dictionary<string, AudioClip> dict;
    private float speed;
    private bool isPlaying;
    private bool isLooping;
    private bool isStoped;

    private Vector3 needlePos;

    [SerializeField]
    private GameObject needle;
    [SerializeField]
    private GameObject needleStart;
    [SerializeField]
    private GameObject box;
    [SerializeField]
    private GameObject playerStartPostion;



    // Start is called before the first frame update
    void Start()
    {
        ;
        this.createBoxList();
        this.loop = new List<AudioSource>();
        this.speed = 1.25f;
        this.isPlaying = true;
        this.needlePos = this.needleStart.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (this.isPlaying)
        {
            this.needle.transform.RotateAround(this.needlePos,
                new Vector3(0f, 1f, 0f),
                30f * Time.deltaTime * this.speed);
        }
        if (this.isStoped)
        {
            //nothing
        }
        if (this.isLooping)
        {
            this.recordLoop();
            this.playLoop();
        }
    }
    private void playLoop()
    {
        foreach (AudioSource audio in this.loop)
        {
            audio.Play();
            while (audio.isPlaying)
            {
                continue;
            }
        }
        this.muteEnvironment(false);
    }
    private void muteEnvironment(bool mute)
    {
        GameObject[] inv = GameObject.FindGameObjectsWithTag("music");
        for (int i = 0; i < inv.Length; i++)
        {
            inv[i].GetComponent<AudioObject>().muteObject(mute);
        }
    }
    private void createBoxList()
    {
        this.boxes = new List<GameObject>();
        this.boxes.Add(this.musicBox1);
        this.boxes.Add(this.musicBox2);
        this.boxes.Add(this.musicBox3);
        this.boxes.Add(this.musicBox4);
        this.boxes.Add(this.musicBox5);
        this.boxes.Add(this.musicBox6);
        this.boxes.Add(this.musicBox7);
        this.boxes.Add(this.musicBox8);
        this.boxes.Add(this.musicBox9);
        this.boxes.Add(this.musicBox10);
        this.boxes.Add(this.musicBox11);
        this.boxes.Add(this.musicBox12);
    }
    private void recordLoop()
    {
        //for now we record all the boxes and dont delate old loops - this needs to be change later on.
        foreach (GameObject box in this.boxes)
        {
            this.loop.Add(box.GetComponent<AudioSource>());
        }
    }
    public void play()
    {
        this.isStoped = false;
        this.isPlaying = true;
        this.muteEnvironment(true);
    }
    public void stop()
    {
        this.isPlaying = false;
        this.isStoped = true;
        this.muteEnvironment(false);
    }
    public void changeTempo()
    {
        this.speed = 1.25f;
    }

    public void returnPlayerToStumps()
    {
        this.transform.position = this.playerStartPostion.transform.position;
    }
    
}