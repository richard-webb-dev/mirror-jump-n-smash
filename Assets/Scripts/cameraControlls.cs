using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class cameraControlls : MonoBehaviour
{
    public float shiftAmount = 1f; // Distance to shift
    public float shiftDuration = 0.5f; // Duration of the shift
    public float targetX = 0f;
    public UnityEvent<float> onPositionShift;

    public void shiftLeft()
    {
        targetX -= shiftAmount;
        ShiftPosition();
    }
    public void shiftRight()
    {
        targetX += shiftAmount;
        ShiftPosition();
    }

    private void ShiftPosition()
    {
        transform.DOMoveX(targetX, shiftDuration).SetEase(Ease.OutQuart);
        onPositionShift.Invoke(targetX);
    }
}
