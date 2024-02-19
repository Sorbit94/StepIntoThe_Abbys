using UnityEngine;

public class DaggerDestroy : MonoBehaviour
{
    private EnemyController enemyController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Rigidbody2D>() != null)
        {
            enemyController = other.GetComponent<EnemyController>();

            if (enemyController != null)
            {
                Destroy(gameObject);
            }
        }

        Destroy(gameObject, 10f);
    }
}
