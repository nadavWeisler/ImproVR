using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    private float x;
    private float y;
    private float z;

    // Start is called before the first frame update
    void Start()
    {
        this.x = this.transform.position.x;
        this.y = this.transform.position.y;
        this.z = this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void createNewObject(Transform parent, Vector3 position, Quaternion rotation)
    {
        var newObj = Instantiate(parent, position, rotation);
        Rigidbody newRig = newObj.transform.GetComponent<Rigidbody>();
        newRig.useGravity = true;
        newRig.mass = 1;
        newRig.inertiaTensor = new Vector3(1, 1, 1);
        //newRig.isKinematic = false;
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.gameObject.tag == "plane")
        {
            print("plane");
            this.createNewObject(other.transform, new Vector3(x, y, z), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
