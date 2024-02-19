using System.Collections;
using UnityEngine;

public class HealingFountain : MonoBehaviour
{
    [SerializeField] private float healingAmount = 50;
    [SerializeField] private Animator fountainAnimator;
    [SerializeField] private string healTrigger = "Heal";

    private bool isUsed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isUsed) return;

        if (collision.CompareTag("Player"))
        {
            StartCoroutine(WaitForHealInput(collision.gameObject));
        }
    }

    private IEnumerator WaitForHealInput(GameObject player)
    {
        while (!Input.GetKeyDown(KeyCode.E))
        {
            yield return null;
        }

        HealPlayer(player);
    }

    private void HealPlayer(GameObject player)
    {
        if (isUsed) return;

        Health playerHealth = player.GetComponent<Health>();
        if (playerHealth != null)
        {
            float healthToRestore = Mathf.Min(healingAmount, playerHealth.MaxHealth - playerHealth.CurrentHealth);
            playerHealth.TakeDamage(-healthToRestore);
            fountainAnimator.SetTrigger(healTrigger);
            isUsed = true;
        }
    }
}
