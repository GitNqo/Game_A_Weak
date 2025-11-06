using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float gameTime = 60f; // 制限時間（秒）
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI messageText; // ← 「TIME UP!」表示用

    private bool isTimeUp = false;

    void Update()
    {
        if (isTimeUp) return;

        gameTime -= Time.deltaTime;

        if (gameTime <= 0)
        {
            gameTime = 0;
            TimeUp();
        }

        timerText.text = "Time: " + Mathf.CeilToInt(gameTime).ToString();
    }

    void TimeUp()
    {
        isTimeUp = true;
        FindObjectOfType<Spawner>().enabled = false;
        DestroyAllObjects();

        // 「TIME UP!」を表示
        if (messageText != null)
        {
            messageText.text = "TIME UP!";
            messageText.gameObject.SetActive(true);
        }

        // スコアを表示（デバッグ用）
        Debug.Log("TIME UP! Score: " + ScoreManager.instance.GetScore());
    }

    void DestroyAllObjects()
    {
        foreach (var obj in GameObject.FindGameObjectsWithTag("Target"))
        {
            Destroy(obj);
        }
    }
}
