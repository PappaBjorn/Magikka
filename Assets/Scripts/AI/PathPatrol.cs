using UnityEngine.AI;
using UnityEngine;

public class PathPatrol : MonoBehaviour
{
    public GameObject[] PathGoals = new GameObject[5];
    GameObject CurrentPatrolPoint;

    private NavMeshAgent nav;

    MeeleAIBehavior aiBehavior;

    private void Start()
    {
        aiBehavior = GetComponent<MeeleAIBehavior>();
        nav = GetComponent<NavMeshAgent>();
        CurrentPatrolPoint = PathGoals[0];
        nav.SetDestination(CurrentPatrolPoint.transform.position);
    }

    private void Update()
    {
        MoveToNextPatrolPoint();
    }

    public void MoveToNextPatrolPoint()
    {
        float distance = Vector3.Distance(transform.position, CurrentPatrolPoint.transform.position);

        if(distance < 1f && aiBehavior.bIsAttacking == false)
        {
            if (CurrentPatrolPoint == null || CurrentPatrolPoint == PathGoals[4])
                CurrentPatrolPoint = PathGoals[0];

            else if (CurrentPatrolPoint == PathGoals[0])
                CurrentPatrolPoint = PathGoals[1];

            else if (CurrentPatrolPoint == PathGoals[1])
                CurrentPatrolPoint = PathGoals[2];

            else if (CurrentPatrolPoint == PathGoals[2])
                CurrentPatrolPoint = PathGoals[3];

            else if (CurrentPatrolPoint == PathGoals[3])
                CurrentPatrolPoint = PathGoals[4];

            nav.SetDestination(CurrentPatrolPoint.transform.position);
        }
    }

}
