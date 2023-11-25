using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUp : MonoBehaviour
{
    public float shrinkTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (shrinkTimer != 0f)
        {
            transform.localScale = new Vector3(0.4f, 0.25f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(0.6f, 0.4f, 1f);
        }

        if (shrinkTimer > 0)
        {
            shrinkTimer -= Time.deltaTime;
        }
        else if (shrinkTimer < 0)
        {
            shrinkTimer = 0f;
        }
    }

}
