using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public enum PowerType
    {
        shrink,
        moreSpawn,
    }
    public int count = 2;

    public PowerType power;

    private SpriteRenderer sr;

    bool enabled = true;

    public GameObject spawnerL;
    public GameObject spawnerR;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        spawnerL = GameObject.Find("SpawnerLeft");
        spawnerR = GameObject.Find("SpawnerRight");
        int r = Random.Range(0, count);
        switch (r)
        {
            case 0:
                power = PowerType.shrink;
                break;
            case 1:
                power = PowerType.moreSpawn;
                break;
            default:
                Debug.LogWarning("PowerSelection Case Error");

                break;
        }

        if(power == PowerType.shrink)
        {
            sr.color = Color.green;
        }
        if (power == PowerType.moreSpawn)
        {
            sr.color = Color.red;
        }

    }

    // Update is called once per frame
    void Update()
    {
       
    }


  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("POWERUP COLLECTED");
        if (collision.tag == "player")
        {
            switch (power)
            {
                case PowerType.shrink:
                    {
                        collision.GetComponent<PlayerPowerUp>().shrinkTimer = 5f;
                        Destroy(gameObject);
                        break;
                    }
                case PowerType.moreSpawn:
                    {
                        if(collision.GetComponent<PlayerOne>().p == PlayerOne.player.one){
                            spawnerR.GetComponent<EnemySpawner>().spawnInterval = 2f;
                        }
                        break;
                    }
                default:
                    break;
            }
        }
    }


}
