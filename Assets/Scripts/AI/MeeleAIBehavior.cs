using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class MeeleAIBehavior : MonoBehaviour
{
    public TestPlayer player;
    public bool bIsAttacking = false;

    PathPatrol pathPatrol;
    Vector3 offset = new Vector3(2, 2, 2);
    NavMeshAgent nav;
    float distance;

    private void Awake()
    {
        pathPatrol = GetComponent<PathPatrol>();
        nav = GetComponent<NavMeshAgent>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        player = collision.gameObject.GetComponent<TestPlayer>();

        player.HealthComp -= 1;
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
