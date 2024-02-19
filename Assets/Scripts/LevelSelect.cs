using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public void LoadNextScene()
    {
        EnemyManager.countDeadEnemies = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    public void RestartScene()
    {
        EnemyManager.countDeadEnemies = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void LoadFirstScene()
    {
        EnemyManager.countDeadEnemies = 0;
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
