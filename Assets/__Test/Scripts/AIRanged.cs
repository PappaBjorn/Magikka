using UnityEngine;
using UnityEngine.AI;

public class AIRanged : MonoBehaviour
{

    public float lookRadius = 10f;

    public Transform target;
    NavMeshAgent agent;

    void Start()
    {
        target = GameManager.Instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        
    }

    private void Update()
    {

        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {

            agent.SetDestination(target.position);

        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

}
