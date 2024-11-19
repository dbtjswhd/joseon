using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NPCMove : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public PlayerMove playerMove;

    public GameObject flag;
    public bool isWalk = false;
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
        float rndx = Random.Range(0,100);
        float rndz = Random.Range(0,100);
        Vector3 rndPlace = new Vector3(rndx,0,rndz);
        flag.transform.position = rndPlace;
        while (true)
        {
            if(isWalk) 
            {
                //이동중
                if(!navMeshAgent.pathPending)
                {
                    //if(navMeshAgent.remainingDistance<=navMeshAgent.stoppingDistance)
                    
                    if(navMeshAgent.remainingDistance<=navMeshAgent.stoppingDistance)
                    {
                        //Debug.Log("도착");
                        navMeshAgent.velocity = Vector3.zero;
                        navMeshAgent.isStopped = true;

                        isWalk = false;
                    }
                }
                //- 처음에 지정한 좌표로 이공
                //(trigger) 도착했는지 확인 -> 이동중이 아니다 로 전환(가만히 있게함)
            }
            else
            {
                //도착시
                //Debug.Log("대기 시작");
                yield return new WaitForSeconds(1f);
                //Debug.Log("대기 끝 랜덤이동 시작");

                navMeshAgent.isStopped = false;
                rndPlace = new Vector3(Random.Range(0,100),0,Random.Range(0,100));
                

                NavMeshHit hit;
                NavMesh.SamplePosition(rndPlace, out hit, 100f, navMeshAgent.areaMask);

                rndPlace = hit.position;

                flag.transform.position = rndPlace;
                navMeshAgent.SetDestination(rndPlace);

                isWalk = true;
            } 

            yield return new WaitForSeconds(0.25f);
        }
    }
}
