using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class High_and_Low : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI resultText;
    public Button highButton;
    public Button lowButton;
    public Button restartButton;

    private int currentNumber;
    private int score;

    void Start()
    {
        restartButton.gameObject.SetActive(false);
        highButton.onClick.AddListener(() => OnGuess(true));
        lowButton.onClick.AddListener(() => OnGuess(false));
        restartButton.onClick.AddListener(StartGame);

        StartGame();
    }

    void StartGame()
    {
        score = 0;
        scoreText.text = "Score: " + score;
        resultText.text = "";
        highButton.gameObject.SetActive(true);
        lowButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(false);

        currentNumber = Random.Range(1, 101);
        numberText.text = currentNumber.ToString();
    }

    void OnGuess(bool guessHigh)
    {
        int nextNumber = Random.Range(1, 101);
        numberText.text = nextNumber.ToString();

        bool correct = guessHigh ? nextNumber > currentNumber : nextNumber < currentNumber;

        if (correct)
        {
            score++;
            scoreText.text = $"Score: {score} times";
            resultText.text = "Correct! Keep going!";
            currentNumber = nextNumber;
        }
        else
        {
            resultText.text = $"Miss! Game Over! Final Score: {score} times";
            highButton.gameObject.SetActive(false);
            lowButton.gameObject.SetActive(false);
            restartButton.gameObject.SetActive(true);
        }
    }
}
