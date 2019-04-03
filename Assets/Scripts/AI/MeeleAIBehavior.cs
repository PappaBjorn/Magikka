using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class MeeleAIBehavior : MonoBehaviour
{
    [SerializeField] GameObject player;
    public bool bIsAttacking = false;

    PathPatrol pathPatrol;
    Vector3 offset = new Vector3(2, 2, 2);
    NavMeshAgent nav;
    float distance;

    private void Awake()
    {
        pathPatrol = GetComponent<PathPatrol>();
        player = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);

        StartAttack();
    }

    private void StartAttack()
    {
        if(distance < 5f)
        {
            bIsAttacking = true;
            nav.SetDestination(player.transform.position + offset);
        }
        else
        {
            bIsAttacking = false;
            pathPatrol.MoveToNextPatrolPoint();
        }
    }
}
