using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public Transform player;
    public float speed = 5.0f;

    public float shootingForce = 50.0f;

    public GameObject projectilePrefab;
    public float shootingInterval = 2.0f;
    private float shootingTimer;

    void Update()
    {

        Vector2 direction = (player.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        shootingTimer += Time.deltaTime;
        if (shootingTimer >= shootingInterval)
        {
            Shoot();
            shootingTimer = 0;
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Vector2 shootingDirection = (player.position - transform.position).normalized;
        projectile.GetComponent<Rigidbody2D>().velocity = shootingDirection * shootingForce;
    }
}
