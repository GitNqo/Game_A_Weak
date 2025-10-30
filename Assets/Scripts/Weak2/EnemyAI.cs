using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;         // �v���C���[�̎Q��
    public float chaseRange = 10f;   // �ǐՊJ�n����
    public float catchDistance = 1.5f; // �߂܂�����
    public Transform[] patrolPoints; // ����|�C���g�i�C�Ӂj

    private NavMeshAgent agent;
    private int currentPoint = 0;
    private bool chasing = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (patrolPoints != null && patrolPoints.Length > 0)
        {
            agent.SetDestination(patrolPoints[0].position);
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        // �v���C���[���߂� �� �ǐՊJ�n
        if (distance <= chaseRange)
        {
            chasing = true;
            agent.SetDestination(player.position);
        }
        else if (chasing && distance > chaseRange * 1.5f)
        {
            // �v���C���[��������������ǐՉ���
            chasing = false;
            GoToNextPatrolPoint();
        }
        else if (!chasing && !agent.pathPending && agent.remainingDistance < 0.5f)
        {
            // ���񒆁F���|�C���g��
            GoToNextPatrolPoint();
        }

        // �߂܂�����
        if (distance <= catchDistance)
        {
            Debug.Log("�v���C���[�ߊl�I�Q�[���I�[�o�[�I");
            // TODO: �Q�[���I�[�o�[������������
        }
    }

    void GoToNextPatrolPoint()
    {
        if (patrolPoints == null || patrolPoints.Length == 0) return;
        currentPoint = (currentPoint + 1) % patrolPoints.Length;
        agent.SetDestination(patrolPoints[currentPoint].position);
    }
}
