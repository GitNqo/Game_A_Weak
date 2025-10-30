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
        Debug.Log("Œ®‚ğ“üè‚µ‚Ü‚µ‚½I");
        UIManager.UpdateKeyDisplay(hasKey);
    }
}
