using System.Collections;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private float panelDelay = 2f;
    [SerializeField] private Animator animator;
    private bool isDeath = false;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource soundSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!isDeath)
            {
                isDeath = true;
                animator.SetBool("IsDeath", true);
                StartCoroutine(ShowDeathPanelDelayed());
                musicSource.Stop();
                soundSource.Play();
            }
        }
    }

    private IEnumerator ShowDeathPanelDelayed()
    {
        yield return new WaitForSeconds(panelDelay);
        gameOverPanel.SetActive(true);
    }
}
