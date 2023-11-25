using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private SpriteRenderer spriteRenderer;

    // Update is called once per frame
    void Update()
    {

    }

    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void UpdateHealth(int healthChange)
    {
        currentHealth += healthChange;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateColor();
    }

    void UpdateColor()
    {
        float healthPercent = (float)currentHealth / maxHealth;
        spriteRenderer.color = Color.Lerp(Color.red, Color.white, healthPercent);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Bullet hit!");
            UpdateHealth(-10); // Update the health bar
        }
        else
        {
            Debug.Log("Something else hit!");
        }
    }
}
