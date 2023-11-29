using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class GameOverPanelController : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public float animationDuration = 1.0f;

    private Color player1WinColour = new Color(252, 255, 0);
    private Color player2WinColour = new Color(0, 223, 215);

    public void AnimateGameOverText(player winningPlayer)
    {
        // Initial properties (you can customize these)
        gameOverText.text = winningPlayer == player.one ? "Left wins! Space to restart" : "Right wins! Space to restart";
        float startScale = 0.5f;
        Vector3 startPos = new Vector3(0, -180, 0);

        // Set initial properties
        gameOverText.transform.localScale = new Vector3(startScale, startScale, 1f);
        gameOverText.transform.localPosition = startPos;
        gameOverText.alpha = 0f;

        // Use DOTween to animate the Game Over text
        Sequence sequence = DOTween.Sequence();

        sequence.Insert(0, gameOverText.DOColor(winningPlayer == player.one ? player1WinColour : player2WinColour, animationDuration * 2f).SetEase(Ease.OutBounce));

        // Scale up
        sequence.Join(gameOverText.transform.DOScale(1.5f, animationDuration * 0.3f).SetEase(Ease.OutBounce));

        // Move up
        sequence.Join(gameOverText.transform.DOLocalMoveY(0, animationDuration * 0.7f).SetEase(Ease.OutExpo));

        // Fade in
        sequence.Join(GetComponent<CanvasGroup>().DOFade(1f, animationDuration * 0.5f));

        // Rotate a bit for a lively effect
        sequence.Join(gameOverText.transform.DORotate(new Vector3(0, 0, 10), animationDuration * 0.2f).SetLoops(-1, LoopType.Yoyo));
        sequence.SetUpdate(true);
    }
}
