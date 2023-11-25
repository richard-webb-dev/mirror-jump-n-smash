using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    // how much to move the object to the side
    public float startX = 0f;
    public float maxMoveX = 2f;
    public float currentSpeedX = 0.1f;

    // how much to move the object up and down
    public float startY = 0f;
    public float maxMoveY = 2f;
    public float currentSpeedY = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        startX = transform.position.x;
        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if ((currentSpeedX > 0 && transform.position.x >= startX + maxMoveX) ||
            (currentSpeedX < 0 && transform.position.x <= startX - maxMoveX))
        {
            currentSpeedX = -currentSpeedX;
        }

        if ((currentSpeedY > 0 && transform.position.y >= startY + maxMoveY) ||
            (currentSpeedY < 0 && transform.position.y <= startY - maxMoveY))
        {
            currentSpeedY = -currentSpeedY;
        }

        // move the object
        transform.position += new Vector3(currentSpeedX, currentSpeedY, 0) * Time.deltaTime;

    }
}
