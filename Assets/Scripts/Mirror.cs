using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public bool copyParent = false;
    private void Awake()
    {
        // copy and mirror all children 
        if (transform.position.x > 0)
        {
            return;
        }
        GameObject parentCopy;

        if (copyParent)
        {
            parentCopy = Instantiate(gameObject, new Vector3(1, 0, 0), Quaternion.identity);

            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject child = transform.GetChild(i).gameObject;
                GameObject childCopy = parentCopy.transform.GetChild(i).gameObject;
                childCopy.transform.position = new Vector3(child.transform.position.x * -1, child.transform.position.y, 0);
            }

            // check spawn script and set player to other player
            EnemySpawner spawnScript = parentCopy.GetComponent<EnemySpawner>();
            if (spawnScript != null)
            {
                // find player name PlayerTwo
                GameObject playerTwo = GameObject.Find("PlayerTwo");
                spawnScript.player = playerTwo;
            }
        }
        else
        {
            parentCopy = new GameObject();
            parentCopy.transform.position = new Vector3(1, 0, 0);
            parentCopy.transform.rotation = Quaternion.identity;
            parentCopy.transform.localScale = Vector3.one;
            parentCopy.name = gameObject.name + " (Mirror)";
            parentCopy.transform.SetParent(transform.parent);

            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject child = transform.GetChild(i).gameObject;
                if (child.transform.position.x > 0) continue;
                GameObject childCopy = Instantiate(child, new Vector3(child.transform.position.x * -1, child.transform.position.y, 0), Quaternion.identity);
                childCopy.transform.SetParent(parentCopy.transform);
            }
        }
    }
    private void Update()
    {
    }
}
