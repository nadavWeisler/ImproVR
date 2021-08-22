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

    [SerializeField]
    private AudioClip bush;

    [SerializeField]
    private AudioClip fire;

    [SerializeField]
    private AudioClip firefly;

    [SerializeField]
    private AudioClip flower;

    [SerializeField]
    private AudioClip foxGreg;

    [SerializeField]
    private AudioClip otterLarry;

    [SerializeField]
    private AudioClip owl;

    [SerializeField]
    private AudioClip frog;

    [SerializeField]
    private AudioClip snake;

    [SerializeField]
    private AudioClip stone1;

    [SerializeField]
    private AudioClip stone2;

    [SerializeField]
    private AudioClip stone3;

    [SerializeField]
    private AudioClip tree1;

    [SerializeField]
    private AudioClip tree2;

    [SerializeField]
    private AudioClip tree3;
    private List<AudioSource> loop;
    private List<GameObject> boxes;
    private Dictionary<string, AudioClip> dict;
    private float speed;
    private bool isPlaying;
    private bool isLooping;
    private bool isStoped;
    [SerializeField]
    private GameObject needle;
    [SerializeField]
    private GameObject box;

    // Start is called before the first frame update
    void Start()
    {
        this.createBoxList();
        this.loop = new List<AudioSource>();
        this.createDic();
        for (int i = 0; i < 12; i++)
        {
            //this.loop[i] = this.gameObject.AddComponent<AudioSource>();
        }
        this.speed = 1f;
        
    }
    // Update is called once per frame
    void Update()
    {
        if (this.isPlaying)
        {
            this.needle.transform.RotateAround(this.transform.position, new Vector3(0f, 1f, 0f), 30f * Time.deltaTime * this.speed);
            this.muteEnvironment(true);
        }
        if (this.isStoped)
        {
            this.muteEnvironment(false);
        }
        if (this.isLooping)
        {
            this.muteEnvironment(true);
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
    private void createDic()
    {
        this.dict = new Dictionary<string, AudioClip>();
        dict.Add("bush", this.bush);
        dict.Add("fire", this.fire);
        dict.Add("firefly", this.firefly);
        dict.Add("flower", this.flower);
        dict.Add("foxGreg", this.foxGreg);
        dict.Add("otterLarry", this.otterLarry);
        dict.Add("owl", this.owl);
        dict.Add("frog", this.frog);
        dict.Add("Snake", this.snake);
        dict.Add("stone1", this.stone1);
        dict.Add("stone2", this.stone2);
        dict.Add("stone3", this.stone3);
        dict.Add("tree1", this.tree1);
        dict.Add("tree2", this.tree2);
        dict.Add("tree3", this.tree3);
    }
    public AudioClip getAudioClip(string name)
    {
        return dict[name];
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
    public void play() {
        this.box.SetActive(!this.box.activeSelf);
        this.isStoped = false;
        this.isPlaying = true;
    }
    public void stop() {
        this.isPlaying = false;
        this.isStoped = true;
    }
}