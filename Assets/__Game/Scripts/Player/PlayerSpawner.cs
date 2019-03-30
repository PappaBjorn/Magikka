using UnityEngine;
using UnityEngine.Assertions;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject prefab;
    public bool spawnOnStart = true;

    private void Start()
    {
        if (spawnOnStart)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        Assert.IsNotNull(prefab, "Spawn prefab is not set.");
        Instantiate(prefab, transform.position, transform.rotation);
    }

    private void OnDrawGizmos()
    {
        Color oldColor = Gizmos.color;
        Vector3 position = Vector3.zero;
        position.y += 1f;

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.forward * 2f);

        Gizmos.color = Color.magenta;
        Gizmos.matrix = transform.localToWorldMatrix;//MMatrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
        
        Gizmos.DrawWireCube(position, new Vector3(1f, 2f, 1f));

        Gizmos.color = oldColor;
        Gizmos.DrawIcon(transform.position + new Vector3(0f, 2.5f, 0f), "nav.png", true);
    }
}
