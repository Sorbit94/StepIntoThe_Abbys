using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    [SerializeField] private Health healthBoss;
    [SerializeField] private Image healthBar;
    [SerializeField] private GameObject healthBarObject;

    private void Update()
    {
        healthBar.fillAmount = healthBoss.GetCurrentHealth() / healthBoss.GetMaxHealth();

        if (healthBar.fillAmount <= 0)
        {
            Destroy(healthBarObject);
        }
    }
}
