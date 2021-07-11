using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeRoomGame : MonoBehaviour
{
    public bool pet;
    public bool plant;
    // Start is called before the first frame update
    void Start()
    {
        this.pet = false;
        this.plant = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.pet && this.plant)
        {
            var walls = FindObjectsOfType<Wall>();
            for (int i = 0; i < walls.Length; i++)
            {
                Destroy(walls[i].gameObject);
            }
        }
    }
}
