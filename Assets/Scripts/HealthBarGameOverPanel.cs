using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBarGameOverPanel : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image healthBar;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private Button restartButton;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource gameOverSound;

    private void Awake()
    {
        if (playerHealth == null)
        {
            playerHealth = GetComponent<Health>();
        }

        restartButton.onClick.AddListener(() => RestartScene());
    }

    private void Update()
    {
        healthBar.fillAmount = playerHealth.GetCurrentHealth() / playerHealth.GetMaxHealth();

        if (playerHealth.GetCurrentHealth() <= 0)
        {
            StartCoroutine(ShowDeathPanelDelayed());
        }
    }

    private IEnumerator ShowDeathPanelDelayed()
    {
        yield return new WaitForSeconds(1f);

       

        GameOverPanel.SetActive(true);

        Time.timeScale = 0f;

        musicSource.Stop();
        gameOverSound.Play();
    }

    private void RestartScene()
    {
        EnemyManager.countDeadEnemies = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
}

