using UnityEngine;
using UnityEngine.AI;

public class AIRanged : MonoBehaviour
{
    [Header("Stats")]
    public float lookRadius = 10f;
    public float inRange = 5f;
    public float speed;
    public float stopDistance;
    public float nearDistance;
    public float timeBtwShoots;

    [Header("References")]
    public Transform target;
    public NavMeshAgent agent;
    public GameObject shoots;

    private Transform bulletSpawner;

    void Start()
    {
        target = GameManager.Instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        bulletSpawner = transform.Find("BulletSpawn");
    }

    private void Update()
    {

        float distance = Vector3.Distance(target.position, transform.position);

        if (distance > lookRadius)
        {

            agent.SetDestination(target.position);

        }
        float distanceBetween = Vector3.Distance(target.position, transform.position);

        if (Input.GetButtonDown("Fire1"))
        {

            GameObject go = Instantiate(shoots, bulletSpawner.position, Quaternion.identity) as GameObject;
            Rigidbody rigiBod = go.GetComponent<Rigidbody>();
            rigiBod.AddForce(transform.forward * 5000f);

        }

    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

}
