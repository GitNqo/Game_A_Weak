using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool hasKey = false;

    void Start()
    {
        UIManager.UpdateKeyDisplay(hasKey);
    }

    public void AddKey()
    {
        hasKey = true;
        Debug.Log("������肵�܂����I");
        UIManager.UpdateKeyDisplay(hasKey);
    }
}
