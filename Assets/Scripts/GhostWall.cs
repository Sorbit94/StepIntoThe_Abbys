using UnityEngine;

public class GhostWall : MonoBehaviour
{
    private Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void Update()
    {
        if (health.GetCurrentHealth() <= 0)
        {
            Destroy(gameObject);
        }
    }
}
