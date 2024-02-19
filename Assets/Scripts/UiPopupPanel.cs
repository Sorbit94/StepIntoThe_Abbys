using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiPopupPanel : MonoBehaviour
{
    [SerializeField] private GameObject uiPanel;
    [SerializeField] private ChestCollector chestCollector;
    [SerializeField] private Text chestsText;
    [SerializeField] private Text killsText;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource soundSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            uiPanel.SetActive(true);
            Time.timeScale = 0f;
            musicSource.Stop();
            soundSource.Play();
            UpdateKills();
        }
    }

    private void Update()
    {
        UpdateScore();
        UpdateKills();
    }

    private void UpdateScore()
    {
        if (chestCollector != null && chestsText != null)
        {
            chestsText.text = "Chests collected: " + chestCollector.score;
        }
    }

    private void UpdateKills()
    {
        if (killsText != null && uiPanel.activeSelf)
        {
            killsText.text = "Enemies killed: " + EnemyManager.countDeadEnemies;
        }
    }

    public void OnRestartButtonClicked()
    {
        EnemyManager.ResetCountDeadEnemies();
        soundSource.Stop();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
