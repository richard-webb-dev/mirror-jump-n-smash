using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : MonoBehaviour
{
    public float speed = 5f;

    public float jumpStrenght = 5f;

    private Rigidbody2D rb;

    public bool grounded = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("right"))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);

        }
        if (Input.GetKey("left"))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);

        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
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
}
