using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

/** a silly hack to convert from direct keyboard input to the New Input System, because seemingly WebGL can't handle multiple players */
public class RemappedInput : MonoBehaviour
{
    public UnityEvent<float, float> move;
    public UnityEvent<bool, bool> jump;
    public UnityEvent restart;

    public player p;
    public int speedModifier = 40;
    private bool isJumping = false;
    private KeyCode left;
    private KeyCode right;
    private KeyCode up;

    void Start()
    {

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

    private void Update()
    {
        bool isJumpingThisFrame = Input.GetKey(up);
        bool isNewJumpingThisFrame = !isJumping && isJumpingThisFrame;
        bool isMovingThisFrame = Input.GetKey(right) || Input.GetKey(left);

        if (Input.GetKey(right))
        {
            move.Invoke(0, Time.deltaTime * speedModifier);
        }
        if (Input.GetKey(left))
        {
            move.Invoke(Time.deltaTime * speedModifier, 0);
        }
        if (!isMovingThisFrame) move.Invoke(0, 0);

        if (isNewJumpingThisFrame)
        {
            isJumping = true;
            jump.Invoke(true, false);
        }
        else if (isJumping && !isJumpingThisFrame)
        {
            isJumping = false;
            jump.Invoke(false, true);
        }


        if (Input.GetKey(KeyCode.Space))
        {
            restart.Invoke();
        }
    }
}
