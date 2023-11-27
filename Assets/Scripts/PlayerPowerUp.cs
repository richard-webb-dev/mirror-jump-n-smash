using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUp : MonoBehaviour
{
    public float shrinkTimer = 0f;
    public Vector3 shrinkToSize = new Vector3(0.4f, 0.25f, 1f);
    public Vector3 defaultSize = new Vector3(0.6f, 0.4f, 1f); /** should probably be 1, but left for backwards compatibility */
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (shrinkTimer != 0f)
        {
            transform.localScale = shrinkToSize;
        }
        else
        {
            transform.localScale = defaultSize;
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
