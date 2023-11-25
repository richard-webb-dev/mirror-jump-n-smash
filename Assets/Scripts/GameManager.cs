using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TMP_Text gameOverText;

    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(score >= 7)
        {
            showGameOverScreen(true);
        }
        if(score <= -7)
        {
            showGameOverScreen(false);
        }
    }

    public void showGameOverScreen(bool playerOneWin)
    {
        if (playerOneWin)
        {
            gameOverText.text = "Playey One WINS!";

        }
        if (!playerOneWin)
        {
            gameOverText.text = "Player Two WINS!";
        }
        
        gameOverPanel.SetActive(true);
        Debug.Log("Game Over");
        Time.timeScale = 0f;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void changeScore(int change)
    {
        score += change;
    }
}
