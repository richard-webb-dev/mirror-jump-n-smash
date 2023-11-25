using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public GameObject OriginalPrefab;

    private GameObject copy;

    public GameObject spawnerR;

    public enum MirrorType
    {
        platform,
        spawner
    }
    public MirrorType type;

    private void Awake()
    {
        if(OriginalPrefab != null)
        {
            copy = Instantiate(OriginalPrefab, new Vector3(transform.position.x * -1, transform.position.y, 0), Quaternion.identity);
            if (type == MirrorType.spawner)
            {
                copy.transform.SetParent(spawnerR.transform);
            }
        }
        

    }
    private void Update()
    {
        if(copy != null)
        {
            copy.transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }
        
    }
}
