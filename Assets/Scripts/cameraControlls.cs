using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControlls : MonoBehaviour
{
    public float shiftAmount = 1f; // Distance to shift
    public float shiftDuration = 0.5f; // Duration of the shift


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void shiftLeft()
    {
        StartCoroutine(ShiftPosition(new Vector3(transform.position.x - shiftAmount, transform.position.y, transform.position.z), shiftDuration));
    }
    public void shiftRight()
    {
        StartCoroutine(ShiftPosition(new Vector3(transform.position.x + shiftAmount, transform.position.y, transform.position.z), shiftDuration));
    }

    IEnumerator ShiftPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        // Ensure the position is set to the target position
        transform.position = targetPosition;
    }
}
