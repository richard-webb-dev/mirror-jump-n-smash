using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerOne : MonoBehaviour
{
    public UnityEvent bulletHit;
    public UnityEvent onDeath;

    public float speed = 5f;
    public float jumpStrenght = 5f;
    public bool grounded = false;

    private Rigidbody2D rb;

    public Transform leftBorder;
    public Transform rightBorder;
    public Transform divider;

    public float health = 100f;

    public enum player
    {
        one, two
    }

    public GameManager gm;

    public player p;

    private KeyCode left;
    private KeyCode right;
    private KeyCode up;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (p == player.one)
        {
            left = KeyCode.A;
            right = KeyCode.D;
            up = KeyCode.W;
        }
        if (p == player.two)
        {
            left = KeyCode.LeftArrow;
            right = KeyCode.RightArrow;
            up = KeyCode.UpArrow;
        }
    }

    // Update is called once per frame
    void Update()
    {

        //Character Controlls
        if (Input.GetKey(right))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(left))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyDown(up) && grounded)
        {
            rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
        }

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


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            grounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            bulletHit.Invoke();
        }
    }


}
