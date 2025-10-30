using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    public Transform player; // プレイヤー本体
    public Vector3 offset = new Vector3(0, 10, -10); // 上方＆後方からの位置
    public float followSpeed = 5f; // カメラ追従の滑らかさ

    void LateUpdate()
    {
        if (player == null) return;

        // カメラの目標位置
        Vector3 targetPos = player.position + offset;

        // スムーズに追従
        transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);

        // プレイヤーを常に見る
        transform.LookAt(player.position);
    }
}
