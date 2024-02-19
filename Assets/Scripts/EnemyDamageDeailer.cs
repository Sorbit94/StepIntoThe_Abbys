using UnityEngine;

public class EnemyDamageDeailer : MonoBehaviour
{
    [SerializeField] private float damage;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Health healthComponent = collision.gameObject.GetComponent<Health>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(damage);
            }
        }
    }
}
