using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerPowerUp : MonoBehaviour
{
    public Vector3 shrinkToSize = new Vector3(0.4f, 0.25f, 1f);
    public Vector3 defaultSize = new Vector3(0.6f, 0.4f, 1f); /** should probably be 1, but left for backwards compatibility */
    private Sequence scaleSequence;

    void Start()
    {
        scaleSequence = DOTween.Sequence();
        scaleSequence.Insert(0, transform.DOScale(shrinkToSize, 0.3f).SetEase(Ease.OutElastic));
        scaleSequence.Insert(0,
            DOTween.To(
                () => GetComponent<characterGround>().colliderOffset,
                x => GetComponent<characterGround>().colliderOffset = x,
                new Vector3(0, 0.2f, 0)
                , 0.3f
            ).SetEase(Ease.OutElastic)
        );
        scaleSequence.AppendInterval(1.0f);
        scaleSequence.SetLoops(2, LoopType.Yoyo);
        scaleSequence.Pause();
    }

    public void ShrinkForSeconds(float seconds)
    {
        scaleSequence.Restart();
        scaleSequence.timeScale = 1/seconds; // this is approx - was trying to be clever and re-use the tween, rather than killing it and recreating each time, but didn't really work
        scaleSequence.Play();
    }

}
