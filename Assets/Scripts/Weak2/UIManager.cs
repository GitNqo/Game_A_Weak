using UnityEngine;
using TMPro; // TextMeshPro を使う場合

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI keyText; // UIの参照
    private static UIManager instance;

    void Awake()
    {
        instance = this;
    }

    public static void UpdateKeyDisplay(bool hasKey)
    {
        if (instance == null || instance.keyText == null) return;
        instance.keyText.text = hasKey ? "Key：having" : "Key：none";
    }
}
