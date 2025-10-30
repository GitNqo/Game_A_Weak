using UnityEngine;

public class MiniMapCamera : MonoBehaviour
{
    public float height = 20f;           // カメラの高さ
    public MazeGenerator3D mazeGenerator; // 動的に迷路サイズを取得

    void Start()
    {
        if (mazeGenerator == null)
        {
            Debug.LogWarning("MazeGenerator3D が設定されていません。");
            return;
        }

        // 迷路中央に固定
        float centerX = (mazeGenerator.width - 1) * mazeGenerator.cellSize * 0.5f;
        float centerZ = (mazeGenerator.depth - 1) * mazeGenerator.cellSize * 0.5f;
        transform.position = new Vector3(centerX, height, centerZ);
        transform.rotation = Quaternion.Euler(90f, 0f, 0f); // 真下を向く

        // カメラのオルソサイズ調整
        Camera cam = GetComponent<Camera>();
        if (cam != null)
        {
            cam.orthographic = true;
            float mazeSize = Mathf.Max(mazeGenerator.width, mazeGenerator.depth) * mazeGenerator.cellSize;
            cam.orthographicSize = mazeSize * 0.5f + 1f; // 余白を追加
        }
    }
}
