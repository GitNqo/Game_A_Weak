using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager2 : MonoBehaviour
{
    public void SetDifficultyEasy()
    {
        DifficultyManager.instance.currentDifficulty = Difficulty.Easy;
        StartGame();
    }

    public void SetDifficultyNormal()
    {
        DifficultyManager.instance.currentDifficulty = Difficulty.Normal;
        StartGame();
    }

    public void SetDifficultyHard()
    {
        DifficultyManager.instance.currentDifficulty = Difficulty.Hard;
        StartGame();
    }

    void StartGame()
    {
        // ゲームシーンをロード（同じシーンでもOK）
        SceneManager.LoadScene("Weak3");
    }
}
