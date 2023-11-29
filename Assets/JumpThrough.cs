using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private string transitionLayerName;
    [SerializeField] private string passThroughTag = "Player";

    private Collider2D physicsCollider;
    private Collider2D triggerCollider; // must be on this game object for the OnTrigger* to work

    // Store the original layer of the player - if multiple players can use the same platform, this would need to be turned into a dict with the player's instance ID
    // Alternatively, you could force the player always back onto the same layer (there's currently no reason they'd be on any other layer)
    private int originalLayer;

    /** The trigger should be slightly smaller, and to the south of the main platform collider
     * when a player jumps into the trigger from the bottom, this hook will be called
     */
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering object is a player
        if (other.CompareTag(passThroughTag))
        {
            PassGameObjectThroughPlatform(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(passThroughTag) && other.gameObject.layer == LayerMask.NameToLayer(transitionLayerName))
        {
            LogLayerTransition(other.gameObject, LayerMask.LayerToName(originalLayer));
            other.gameObject.layer = originalLayer;
        }
    }

    public void PassGameObjectThroughPlatform(GameObject go) {
        originalLayer = go.layer;
        LogLayerTransition(go, transitionLayerName);
        go.layer = LayerMask.NameToLayer(transitionLayerName);
    }

    private void LogLayerTransition(GameObject go, string to)
    {
        Debug.Log($"transitioning {go.name} from layer {LayerMask.LayerToName(go.layer)} to {to}");
    }
}
