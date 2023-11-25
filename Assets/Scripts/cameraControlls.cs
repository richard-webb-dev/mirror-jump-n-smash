using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControlls : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void shiftLeft()
    {
        transform.position = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
    }
    public void shiftRight()
    {
        transform.position = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
    }

}
