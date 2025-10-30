using UnityEngine;
using TMPro; // TextMeshPro ���g���ꍇ

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI keyText; // UI�̎Q��
    private static UIManager instance;

    void Awake()
    {
        instance = this;
    }

    public static void UpdateKeyDisplay(bool hasKey)
    {
        if (instance == null || instance.keyText == null) return;
        instance.keyText.text = hasKey ? "Key�Fhaving" : "Key�Fnone";
    }
}
