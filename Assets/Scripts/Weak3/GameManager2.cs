using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager2 : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private float score = 0f;
    private bool isGameOver = false;

    void Update()
    {
        if (!isGameOver)
        {
            score += Time.deltaTime;
            scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
        }

        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        scoreText.text += "\nGAME OVER\nPress R to Retry";
        Time.timeScale = 0f;
    }
}
