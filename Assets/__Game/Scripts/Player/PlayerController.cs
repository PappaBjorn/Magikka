using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Assert.IsNotNull(agent, "<color=#FF0000><b>Error</b></color>Error: Failed to locate NavMeshAgent for Player.");
    }

    private void Update()
    {
        if (Input.GetAxis(Horizontal))
        {

        }
    }
}
