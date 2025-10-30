using UnityEngine;

public class PlayerCameraFollow : MonoBehaviour
{
    public Transform target;   // ÉvÉåÉCÉÑÅ[
    public Vector3 offset = new Vector3(0, 5f, -7f);
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (!target) return;

        Vector3 desiredPos = target.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPos;

        transform.LookAt(target.position + Vector3.up * 1.5f); // è≠Çµè„Çë_Ç§
    }
}
