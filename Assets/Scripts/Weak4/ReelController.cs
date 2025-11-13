using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReelController : MonoBehaviour
{
    public List<Image> symbols; // リール上の画像
    public List<Sprite> symbolSprites; // シンボル画像セット
    public bool isSpinning = false;
    private float speed = 800f;
    private float stopTime;

    private SymbolType resultSymbol;

    void Update()
    {
        if (isSpinning)
        {
            foreach (var symbol in symbols)
            {
                symbol.transform.Translate(Vector3.down * speed * Time.deltaTime);
                if (symbol.transform.localPosition.y < -300)
                    symbol.transform.localPosition += new Vector3(0, 900, 0);
            }
        }
    }

    public void StartSpin()
    {
        isSpinning = true;
        stopTime = Time.time + Random.Range(1.0f, 2.0f);
        StartCoroutine(StopAfterDelay());
    }

    private IEnumerator StopAfterDelay()
    {
        yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));
        isSpinning = false;

        // 位置を中央にスナップ
        foreach (var symbol in symbols)
        {
            float y = symbol.rectTransform.anchoredPosition.y;
            float snappedY = Mathf.Round(y / 200f) * 200f; // 200単位で丸める
            symbol.rectTransform.anchoredPosition = new Vector2(0, snappedY);
        }

        // ランダムで中央の絵柄を決定
        int randomIndex = Random.Range(0, symbolSprites.Count);
        symbols[1].sprite = symbolSprites[randomIndex];
        resultSymbol = (SymbolType)randomIndex;
    }



    public SymbolType GetResult()
    {
        return resultSymbol;
    }
}
