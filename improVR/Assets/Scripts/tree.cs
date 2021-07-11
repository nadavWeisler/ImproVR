using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour
{
    public EscapeRoomGame game;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bottle")
        {
            other.transform.localScale *= 3;
            this.game.pet = true;
        }
    }
}