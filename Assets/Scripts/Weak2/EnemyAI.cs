using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;         // プレイヤーの参照
    public float chaseRange = 10f;   // 追跡開始距離
    public float catchDistance = 1.5f; // 捕まえ距離
    public Transform[] patrolPoints; // 巡回ポイント（任意）

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

        // プレイヤーが近い → 追跡開始
        if (distance <= chaseRange)
        {
            chasing = true;
            agent.SetDestination(player.position);
        }
        else if (chasing && distance > chaseRange * 1.5f)
        {
            // プレイヤーが遠ざかったら追跡解除
            chasing = false;
            GoToNextPatrolPoint();
        }
        else if (!chasing && !agent.pathPending && agent.remainingDistance < 0.5f)
        {
            // 巡回中：次ポイントへ
            GoToNextPatrolPoint();
        }

        // 捕まえ判定
        if (distance <= catchDistance)
        {
            Debug.Log("プレイヤー捕獲！ゲームオーバー！");
            // TODO: ゲームオーバー処理をここに
        }
    }

    void GoToNextPatrolPoint()
    {
        if (patrolPoints == null || patrolPoints.Length == 0) return;
        currentPoint = (currentPoint + 1) % patrolPoints.Length;
        agent.SetDestination(patrolPoints[currentPoint].position);
    }
}
