using UnityEngine;

public enum Difficulty
{
    Easy,
    Normal,
    Hard
}

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager instance;
    public Difficulty currentDifficulty = Difficulty.Normal;

    void Awake()
    {
        instance = this;
    }

    public float GetSpawnInterval()
    {
        switch (currentDifficulty)
        {
            case Difficulty.Easy: return 2.0f;
            case Difficulty.Normal: return 1.0f;
            case Difficulty.Hard: return 0.5f;
            default: return 1.0f;
        }
    }

    public float GetObjectLifetime()
    {
        switch (currentDifficulty)
        {
            case Difficulty.Easy: return 3.0f;
            case Difficulty.Normal: return 2.0f;
            case Difficulty.Hard: return 1.0f;
            default: return 2.0f;
        }
    }
}
