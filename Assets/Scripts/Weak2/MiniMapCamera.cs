using UnityEngine;

public class MiniMapCamera : MonoBehaviour
{
    public float height = 20f;           // �J�����̍���
    public MazeGenerator3D mazeGenerator; // ���I�ɖ��H�T�C�Y���擾

    void Start()
    {
        if (mazeGenerator == null)
        {
            Debug.LogWarning("MazeGenerator3D ���ݒ肳��Ă��܂���B");
            return;
        }

        // ���H�����ɌŒ�
        float centerX = (mazeGenerator.width - 1) * mazeGenerator.cellSize * 0.5f;
        float centerZ = (mazeGenerator.depth - 1) * mazeGenerator.cellSize * 0.5f;
        transform.position = new Vector3(centerX, height, centerZ);
        transform.rotation = Quaternion.Euler(90f, 0f, 0f); // �^��������

        // �J�����̃I���\�T�C�Y����
        Camera cam = GetComponent<Camera>();
        if (cam != null)
        {
            cam.orthographic = true;
            float mazeSize = Mathf.Max(mazeGenerator.width, mazeGenerator.depth) * mazeGenerator.cellSize;
            cam.orthographicSize = mazeSize * 0.5f + 1f; // �]����ǉ�
        }
    }
}
