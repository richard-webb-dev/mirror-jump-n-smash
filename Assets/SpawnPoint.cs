using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{

    public bool occupied;

    public bool active = true;

    public Transform leftBorder;
    public Transform rightBorder;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > rightBorder.position.x - rightBorder.GetComponent<Collider2D>().bounds.extents.x)
        {
            active = false;
        }

        else if (transform.position.x < leftBorder.position.x + rightBorder.GetComponent<Collider2D>().bounds.extents.x)
        {
            active = false;
        }
        else
        {
            active = true;
        }
    }
}
