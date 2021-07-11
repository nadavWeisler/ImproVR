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
    private Dictionary<string, AudioClip> dict;
    private float speed;
    private bool isPlaying;
    [SerializeField]
    private GameObject needle;
    // Start is called before the first frame update
    void Start()
    {
        this.loop = new List<AudioSource>();
        this.createDic();
        for (int i = 0; i < 12; i++)
        {
            //this.loop[i] = this.gameObject.AddComponent<AudioSource>();
        }
        this.speed = 1f;
        this.isPlaying = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (this.isPlaying)
        {
            this.needle.transform.RotateAround(this.transform.position, new Vector3(0f, 1f, 0f), 30f * Time.deltaTime * this.speed);
        }
    }
    private void playLoop()
    {
        for (int i = 0; i < 12; i++)
        {
            loop[i].Play();
            while (loop[i].isPlaying)
            {
                continue;
            }
            i++;
        }
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
}