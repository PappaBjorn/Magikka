using UnityEngine.AI;
using UnityEngine;

public class PathPatrol : MonoBehaviour
{
    public Vector3[] PathGoals = new Vector3[5];
    [SerializeField] Vector3 CurrentPatrolPoint;

    private NavMeshAgent nav;

    private void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    private void MoveToNextPatrolPoint()
    {
        if (CurrentPatrolPoint == null || CurrentPatrolPoint == PathGoals[5])
            CurrentPatrolPoint = PathGoals[0];

        else if (CurrentPatrolPoint == PathGoals[0])
            CurrentPatrolPoint = PathGoals[1];

        else if (CurrentPatrolPoint == PathGoals[1])
            CurrentPatrolPoint = PathGoals[2];

        else if (CurrentPatrolPoint == PathGoals[2])
            CurrentPatrolPoint = PathGoals[3];

        else if (CurrentPatrolPoint == PathGoals[3])
            CurrentPatrolPoint = PathGoals[4];

        else if (CurrentPatrolPoint == PathGoals[4])
            CurrentPatrolPoint = PathGoals[5];

        nav.SetDestination(CurrentPatrolPoint);
    }

}
