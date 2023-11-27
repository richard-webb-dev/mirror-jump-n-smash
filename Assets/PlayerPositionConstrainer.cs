using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum player
{
    one, two
}

/** ensures player never leaves the box */
public class PlayerPositionConstrainer : MonoBehaviour
{
    public GameManager gm;
    public player p;
    public UnityEvent onDeath;
    public Transform leftBorder;
    public Transform rightBorder;
    public Transform divider;

    void Update()
    {
        //Bounding Controlls

        if (p == player.one)
        {
            if (transform.position.x < leftBorder.position.x + leftBorder.GetComponent<Collider2D>().bounds.extents.x)
            {
                Vector3 pos = transform.position;
                pos.x = leftBorder.position.x + leftBorder.GetComponent<Collider2D>().bounds.extents.x + GetComponent<Collider2D>().bounds.extents.x;
                transform.position = pos;
            }
            if (transform.position.x > divider.position.x + divider.GetComponent<Collider2D>().bounds.extents.x)
            {
                Vector3 pos = transform.position;
                pos.x = divider.position.x - divider.GetComponent<Collider2D>().bounds.extents.x - GetComponent<Collider2D>().bounds.extents.x;
                transform.position = pos;
            }
            if (leftBorder.position.x > 0)
            {
                onDeath.Invoke();
                gm.showGameOverScreen(false);
            }
        }
        if (p == player.two)
        {
            if (transform.position.x > rightBorder.position.x + rightBorder.GetComponent<Collider2D>().bounds.extents.x)
            {
                Vector3 pos = transform.position;
                pos.x = rightBorder.position.x - rightBorder.GetComponent<Collider2D>().bounds.extents.x - GetComponent<Collider2D>().bounds.extents.x;
                transform.position = pos;
            }
            if (transform.position.x < divider.position.x + divider.GetComponent<Collider2D>().bounds.extents.x)
            {
                Vector3 pos = transform.position;
                pos.x = divider.position.x + divider.GetComponent<Collider2D>().bounds.extents.x + GetComponent<Collider2D>().bounds.extents.x;
                transform.position = pos;
            }

            if (rightBorder.position.x < 0)
            {
                onDeath.Invoke();
                gm.showGameOverScreen(true);
            }
        }
    }
}
