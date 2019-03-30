using UnityEngine;
using UnityEngine.AI;

namespace Test
{
    public class Player : MonoBehaviour
    {
        [System.NonSerialized] public int index = -1;

        private NavMeshAgent agent;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        private void OnEnable()
        {
            index = GameManager.Instance.RegisterActivePlayer(this);
        }

        private void OnDisable()
        {
            GameManager.Instance.UnregisterActivePlayer(index);
        }

        private void Update()
        {
            if (agent.remainingDistance < 1f)
            {
                agent.SetDestination(Random.insideUnitSphere * 50f);
            }
        }
    }
}
