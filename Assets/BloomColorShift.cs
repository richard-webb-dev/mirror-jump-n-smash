using UnityEngine;
using UnityEngine.Rendering;
using DG.Tweening;

public class BloomColorShift : MonoBehaviour
{
    public Volume postProcessVolume;
    public float animationDuration = 1.0f;
    public Gradient gradient;

    private UnityEngine.Rendering.Universal.Bloom bloom;

    void Start()
    {
        if (postProcessVolume == null)
        {
            Debug.LogError("PostProcessVolume is not assigned!");
            return;
        }

        // Get the Bloom component from the post-processing volume
        postProcessVolume.profile.TryGet(out bloom);

        if (bloom == null)
        {
            Debug.LogError("Bloom component not found in the PostProcessVolume!");
            return;
        }
    }

    public void ShiftBloomColor(float t)
    {
        Color targetColor = InterpolateWithGradient(t);
        DOTween.To(() => bloom.tint.value, x => bloom.tint.value = x, targetColor, animationDuration);
    }

    private Color InterpolateWithGradient(float t)
    {
        // Use the gradient to interpolate between colors
        var clamped = Mathf.Clamp01(t);
        if (t != clamped) Debug.Log($"{t} was clamped to {clamped}");
        return gradient.Evaluate(clamped);
    }
}
