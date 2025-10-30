using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if (inventory != null && inventory.hasKey)
            {
                Debug.Log("脱出成功！クリアシーンへ！");
                SceneManager.LoadScene("ClearScene"); // クリア画面へ遷移
            }
            else
            {
                Debug.Log("鍵が必要です！");
            }
        }
    }
}
