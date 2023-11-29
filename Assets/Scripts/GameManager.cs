using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameOverPanelController gameOverPanel;
    public TMP_Text gameOverText;

    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void showGameOverScreen(bool playerOneWin)
    {
        gameOverPanel.AnimateGameOverText(playerOneWin ? player.one : player.two);
        Debug.Log("Game Over");
        // can't set timescale immediately to 0, otherwise lose music doesn't play
        DOTween.To(() => Time.timeScale, x => Time.timeScale = x, 0f, 2f).SetUpdate(true);  // Ensure the tween updates even when Time.timeScale is 0
    }
    public void RestartGame()
    {
        DOTween.To(() => Time.timeScale, x => Time.timeScale = x, 1f, 1f).SetUpdate(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void changeScore(int change)
    {
        score += change;
    }
}
