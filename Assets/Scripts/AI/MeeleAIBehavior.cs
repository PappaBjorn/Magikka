using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class MeeleAIBehavior : MonoBehaviour
{
    public TestPlayer player;
    public bool bIsAttacking = false;

    PathPatrol pathPatrol;
    Vector3 offset = new Vector3(0.5f, 0.5f, 0.5f);
    NavMeshAgent nav;
    Rigidbody myRigidBody;
    float distance;

    private void Awake()
    {
        pathPatrol = GetComponent<PathPatrol>();
        nav = GetComponent<NavMeshAgent>();
        myRigidBody = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        //if (player == null)
        //{
        //    return;
        //}


        if (player == null)
        {
            bIsAttacking = false;
            nav.SetDestination(pathPatrol.CurrentPatrolPoint.transform.position);

            pathPatrol.MoveToNextPatrolPoint();
        }
        else
        {
            distance = Vector3.Distance(transform.position, player.transform.position);

            Debug.Log(distance);
            StartAttack();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < 10; i++)
        {
            player.HealthComp -= 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        player = other.gameObject.GetComponent<TestPlayer>();
    }

    private void StartAttack()
    {
        if (distance < 5f)
        {
            bIsAttacking = true;
            nav.SetDestination(player.transform.position + offset);
        }
    }
}
