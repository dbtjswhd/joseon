using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMove : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    public PlayerMove playerMove;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        if (playerMove != null)
        {
            StartCoroutine(UpdatePath());
        }
        else
        {
            Debug.LogError("플레이어 없음");
        }
    }

    private IEnumerator UpdatePath()
    {
        while (true)
        {
            if (playerMove != null)
            {
                navMeshAgent.isStopped = false;
                navMeshAgent.SetDestination(playerMove.transform.position);
            }
            else
            {
                navMeshAgent.isStopped = true;
            }
            yield return new WaitForSeconds(0.25f);
        }
    }
}
