using UnityEngine;
using UnityEngine.UI;

public class SlotManager : MonoBehaviour
{
    public ReelController reel1;
    public ReelController reel2;
    public ReelController reel3;
    public Button spinButton;
    public Text resultText;
    public Text coinText;

    private int coins = 100;

    void Start()
    {
        spinButton.onClick.AddListener(Spin);
        UpdateCoinText();
    }

    public void Spin()
    {
        if (coins <= 0) return;

        coins -= 10; // スピンコスト
        UpdateCoinText();

        resultText.text = "Spinning...";

        reel1.StartSpin();
        reel2.StartSpin();
        reel3.StartSpin();

        Invoke(nameof(CheckResult), 3f);
    }

    void CheckResult()
    {
        SymbolType s1 = reel1.GetResult();
        SymbolType s2 = reel2.GetResult();
        SymbolType s3 = reel3.GetResult();

        if (s1 == s2 && s2 == s3)
        {
            int reward = 0;
            switch (s1)
            {
                case SymbolType.BAR: reward = 100; break;
                case SymbolType.Seven: reward = 50; break;
                case SymbolType.Cherry: reward = 20; break;
                default: reward = 10; break;
            }
            coins += reward;
            resultText.text = $"{s1} ×3！ +{reward}枚！";
        }
        else
        {
            resultText.text = "ハズレ…";
        }

        UpdateCoinText();
    }

    void UpdateCoinText()
    {
        coinText.text = $"COINS: {coins}";
    }
}
