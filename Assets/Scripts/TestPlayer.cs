using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    public int HealthComp = 10;
    public bool bIsDead = false;

    private void Update()
    {
        //Debug.Log(HealthComp);

        if (HealthComp == 0)
        {
            Destroy(gameObject);
        }
    }
}
