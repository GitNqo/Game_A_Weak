using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickableObject : MonoBehaviour
{
    void OnMouseDown()
    {
        ScoreManager.instance.AddScore(10);
        Destroy(gameObject);
    }
}
