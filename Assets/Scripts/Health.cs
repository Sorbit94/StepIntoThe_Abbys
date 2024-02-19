using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float currentHealth;
    private Animator animator;

    private bool isCounted = true;
    private bool isDead = false;

    private void Awake()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if (currentHealth <= 0 && !isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        if (!isDead)
        {
            isDead = true;
            Destroy(gameObject, 1f);
            if (isCounted)
            {
                EnemyManager enemyManager = FindObjectOfType<EnemyManager>();
                if (enemyManager != null)
                {
                    EnemyManager.AddDeadEnemies();
                }
            }
            animator.SetBool("IsDeath", true);
        }
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public void SetIsCounted(bool value)
    {
        isCounted = value;
    }

    public float CurrentHealth
    {
        get { return currentHealth; }
    }

    public float MaxHealth
    {
        get { return maxHealth; }
    }
}
