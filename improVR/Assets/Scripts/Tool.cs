using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    private float x;
    private float y;
    private float z;
    private Vector3 startPos

    // Start is called before the first frame update
    void Start()
    {
        this.startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y < 0.05) 
        {
            this.createNewObject(other.transform, new Vector3(x, y, z), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    void createNewObject(Transform parent, Vector3 position, Quaternion rotation)
    {
        var newObj = Instantiate(parent, position, rotation);
        Rigidbody newRig = newObj.transform.GetComponent<Rigidbody>();
        newRig.useGravity = true;
        newRig.isKinematic = false;
    }
}
