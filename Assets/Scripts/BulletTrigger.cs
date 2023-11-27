using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/** */
public class BulletTrigger : MonoBehaviour
{
    public UnityEvent bulletHit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            bulletHit.Invoke();
        }
    }
}
