using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpTester : MonoBehaviour
{
    public float characterY;
    public Transform character;

    void Start()
    {
        characterY = character.position.y;
    }
}
