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
                Debug.Log("�E�o�����I�N���A�V�[���ցI");
                SceneManager.LoadScene("ClearScene"); // �N���A��ʂ֑J��
            }
            else
            {
                Debug.Log("�����K�v�ł��I");
            }
        }
    }
}
