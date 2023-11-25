using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public Transform ObjA;
    public Vector2 Origin; // Origin point for mirroring

    private void Update()
    {
        // Mirroring ObjA's position on the X-axis about Origin.x
        float mirroredX = Origin.x - (ObjA.position.x - Origin.x);
        float sameY = ObjA.position.y; // Keeping the Y-coordinate the same

        // Applying the mirrored position to this GameObject
        transform.position = new Vector2(mirroredX, sameY);
    }
}
